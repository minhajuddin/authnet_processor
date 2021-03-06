﻿using System;
using Authnet;
using Authnet.Gateways;
using Moq;
using NUnit.Framework;

namespace Tests.Integration.Gateways {
    [TestFixture]
    public class CustomerInformationManagerTests {
        private IProfileAttributes _profileAttributes;
        private IAddressAttributes _addressAttributes;
        private ICreditCardAttributes _creditCardAttributes;
        private IPaymentProfileAttributes _paymentProfileAttributes;
        private IOrder _order;

        [SetUp]
        public void Setup() {

            var random = new Random();
            _profileAttributes = ObjectMother.GetMockProfileAttributes(x =>
           {
               x.CustomerId = random.Next().ToString();
               x.Email = "test2@cv.com";
           });

            _addressAttributes = ObjectMother.GetMockAddressAttributes(x =>
            {
                x.FirstName = "Rafi";
                x.LastName = "Sk";
                x.Address = "Rajendranagar";
                x.City = "Hyderabad";
                x.State = "AP";
                x.Zip = "500048";
                x.Company = "cosmicvent";
                x.Country = "India";
            });
            _creditCardAttributes = ObjectMother.GetMockCreditCardAttributes(x =>
            {
                x.CardNumber = "4111111111111111";
                x.ExpirationDate = DateTime.Now.AddMonths(1).ToString("yyyy-MM");
            });

            _paymentProfileAttributes = ObjectMother.GetMockPaymentProfileAttributes();

            _order = ObjectMother.GetMockOrder(x =>
                                                      {

                                                          x.Amount = random.Next(1, 5000);
                                                          x.Description = "amount of" + random.Next(1, 5000);
                                                      });

            //

            //var next = random.Next(1, 5000);

            //_transaction = ObjectMother.GetMockTransaction(x =>
            //{
            //    x.Amount = next;
            //    x.Description = "Transaction" + next;
            //    x.InVoiceNumber = "IN" + next;
            //    x.PurchaseOrderNumber = "PO" + next;
            //    x.RecurringBilling = false;
            //    x.TaxExempt = false;
            //});

        }


        [Test, Ignore("Takes a very long time")]
        public void CanGetAllCustomersIds() {
            var cim = new CustomerInformationManager(TestHelper.TemplateFactory, ObjectMother.TestAuthentication);
            var ids = cim.GetCustomerProfileIds();
            Assert.NotNull(ids);
            //Assert.Greater(ids.Length, 0);
        }

        [Test]
        public void CanCreateCustomerProfile() {
            var random = new Random();
            var profileAttributes = ObjectMother.GetMockProfileAttributes(x =>
                                                            {
                                                                x.CustomerId = random.Next().ToString();
                                                                x.Email = "test2@cosmicvent.com";
                                                            });
            var cim = new CustomerInformationManager(TestHelper.TemplateFactory, ObjectMother.TestAuthentication);
            var response = cim.Create(profileAttributes);
            Assert.IsTrue(response.Success);
            Assert.NotNull(response.Params["customerProfileId"]);
        }


        [Test]
        public void CanNotCreateCustomerProfileWithImproperInputData() {
            var random = new Random();
            var profileAttributes = ObjectMother.GetMockProfileAttributes(x =>
            {
                x.CustomerId = random.Next().ToString() + "...blahbalhbalhbalhbalhbalh";
                x.Email = "test2@cosmicvent.com";
            });
            var cim = new CustomerInformationManager(TestHelper.TemplateFactory, ObjectMother.TestAuthentication);
            var response = cim.Create(profileAttributes);
            Assert.IsFalse(response.Success);
            Assert.AreEqual("NO VALUE", response.Params.ToString());
        }

        [Test]
        public void CanCreatePaymentProfile() {
            var cim = new CustomerInformationManager(TestHelper.TemplateFactory, ObjectMother.TestAuthentication);
            var createProfileResponse = cim.Create(_profileAttributes);

            _profileAttributes.GateWayId = createProfileResponse.Params["customerProfileId"];

            var createPaymentProfileResponse = cim.CreatePaymentProfile(_profileAttributes, _addressAttributes, _creditCardAttributes);

            Assert.IsTrue(createPaymentProfileResponse.Success);
            Assert.NotNull(createPaymentProfileResponse.Params["customerPaymentProfileId"].ToString());
        }

        [Test]
        public void CanNotCreatePaymentProfileWithImproperInputData() {
            var cim = new CustomerInformationManager(TestHelper.TemplateFactory, ObjectMother.TestAuthentication);
            var createProfileResponse = cim.Create(_profileAttributes);

            _profileAttributes.GateWayId = createProfileResponse.Params["customerProfileId"];

            var createPaymentProfileResponse = cim.CreatePaymentProfile(_profileAttributes, new Mock<IAddressAttributes>().Object, _creditCardAttributes);

            Assert.IsFalse(createPaymentProfileResponse.Success);
            Assert.IsNotNull(createPaymentProfileResponse.Params["validationDirectResponseString"]);
        }



        [Test]
        public void CanCreateCustomerShippingAddress() {
            var cim = new CustomerInformationManager(TestHelper.TemplateFactory, ObjectMother.TestAuthentication);

            var createProfileResponse = cim.Create(_profileAttributes);
            _profileAttributes.GateWayId = createProfileResponse.Params["customerProfileId"];

            var createShippingAddressResponse = cim.Create(_profileAttributes, _addressAttributes);
            Assert.IsTrue(createShippingAddressResponse.Success);
            Assert.NotNull(createShippingAddressResponse.Params["customerAddressId"].ToString());
        }


        [Test]
        public void CanGetCustomerProfile() {

            var expectedDescrioption = _profileAttributes.CustomerId;
            var expectedEmail = _profileAttributes.Email;

            var cim = new CustomerInformationManager(TestHelper.TemplateFactory, ObjectMother.TestAuthentication);

            var createProfileResponse = cim.Create(_profileAttributes);
            _profileAttributes.GateWayId = createProfileResponse.Params["customerProfileId"];

            var getProfileResponse = cim.Get(_profileAttributes);
            Assert.IsTrue(getProfileResponse.Success);
            Assert.AreEqual(expectedDescrioption, getProfileResponse.Params["Description"].ToString());
            Assert.AreEqual(expectedEmail, getProfileResponse.Params["Email"].ToString());
        }

        [Test]
        public void CanGetPaymentProfile() {
            string expectedId;
            var cim = new CustomerInformationManager(TestHelper.TemplateFactory, ObjectMother.TestAuthentication);
            var createProfileResponse = cim.Create(_profileAttributes);

            _profileAttributes.GateWayId = createProfileResponse.Params["customerProfileId"];

            var createPaymentProfileResponse = cim.CreatePaymentProfile(_profileAttributes, _addressAttributes, _creditCardAttributes);

            _paymentProfileAttributes.GateWayId = createPaymentProfileResponse.Params["customerPaymentProfileId"];
            expectedId = createPaymentProfileResponse.Params["customerPaymentProfileId"];

            var getPaymentProfileResponse = cim.Get(_profileAttributes, _paymentProfileAttributes);
            Assert.IsTrue(getPaymentProfileResponse.Success);
            Assert.AreEqual(expectedId, getPaymentProfileResponse.Params["customerPaymentProfileId"].ToString());
        }

        [Test]
        public void CanGetCustomerShippingAddress() {
            string expectedId;
            var cim = new CustomerInformationManager(TestHelper.TemplateFactory, ObjectMother.TestAuthentication);

            var createProfileResponse = cim.Create(_profileAttributes);
            _profileAttributes.GateWayId = createProfileResponse.Params["customerProfileId"];

            var createShippingAddressResponse = cim.Create(_profileAttributes, _addressAttributes);
            _addressAttributes.GateWayId = createShippingAddressResponse.Params["customerAddressId"];
            expectedId = createShippingAddressResponse.Params["customerAddressId"];

            var response = cim.Get(_profileAttributes, _addressAttributes);
            Assert.IsTrue(createShippingAddressResponse.Success);
            Assert.AreEqual(expectedId, response.Params["customerAddressId"].ToString());
        }

        [Test]
        public void CanDeleteCustomerProfile() {

            var cim = new CustomerInformationManager(TestHelper.TemplateFactory, ObjectMother.TestAuthentication);
            var response = cim.Create(_profileAttributes);

            _profileAttributes.GateWayId = response.Params["customerProfileId"];

            var deleteResponse = cim.Delete(_profileAttributes);
            Assert.IsTrue(deleteResponse.Success);

        }

        [Test]
        public void CanDeletePaymentProfile() {

            var cim = new CustomerInformationManager(TestHelper.TemplateFactory, ObjectMother.TestAuthentication);
            var createProfileResponse = cim.Create(_profileAttributes);

            _profileAttributes.GateWayId = createProfileResponse.Params["customerProfileId"];

            var createPaymentProfileResponse = cim.CreatePaymentProfile(_profileAttributes, _addressAttributes, _creditCardAttributes);

            _paymentProfileAttributes.GateWayId = createPaymentProfileResponse.Params["customerPaymentProfileId"];


            var deletePaymentProfileResponse = cim.Delete(_profileAttributes, _paymentProfileAttributes);
            Assert.IsTrue(deletePaymentProfileResponse.Success);
        }


        [Test]
        public void CanShippingAddressProfile() {

            var cim = new CustomerInformationManager(TestHelper.TemplateFactory, ObjectMother.TestAuthentication);
            var createProfileResponse = cim.Create(_profileAttributes);

            _profileAttributes.GateWayId = createProfileResponse.Params["customerProfileId"];

            var createShippingAddressResponse = cim.Create(_profileAttributes, _addressAttributes);

            _addressAttributes.GateWayId = createShippingAddressResponse.Params["customerAddressId"];

            var deleteShippingAddressResponse = cim.Delete(_profileAttributes, _addressAttributes);
            Assert.IsTrue(deleteShippingAddressResponse.Success);
        }

        [Test]
        public void CanUpdateCustomerProfile() {
            var cim = new CustomerInformationManager(TestHelper.TemplateFactory, ObjectMother.TestAuthentication);
            var createProfileResponse = cim.Create(_profileAttributes);

            _profileAttributes.GateWayId = createProfileResponse.Params["customerProfileId"];

            _profileAttributes.CustomerId = _profileAttributes.CustomerId + "Chg";
            _profileAttributes.Email = "Chg" + _profileAttributes.Email;

            var updateCustomerProfileresponse = cim.Update(_profileAttributes);

            Assert.IsTrue(updateCustomerProfileresponse.Success);
        }

        [Test]
        public void CanUpdatePaymentProfile() {
            var cim = new CustomerInformationManager(TestHelper.TemplateFactory, ObjectMother.TestAuthentication);
            var createProfileResponse = cim.Create(_profileAttributes);

            _profileAttributes.GateWayId = createProfileResponse.Params["customerProfileId"];
            var createPaymentProfileResponse = cim.CreatePaymentProfile(_profileAttributes, _addressAttributes, _creditCardAttributes);
            _paymentProfileAttributes.GateWayId = createPaymentProfileResponse.Params["customerPaymentProfileId"];

            _profileAttributes.CustomerId = _profileAttributes.CustomerId + "chg";
            _profileAttributes.Email = "chg" + _profileAttributes.Email;

            var updateProfileresponse = cim.Update(_profileAttributes, _addressAttributes, _creditCardAttributes, _paymentProfileAttributes);

            Assert.IsTrue(updateProfileresponse.Success);
            Assert.IsNotNullOrEmpty(updateProfileresponse.Params["validationDirectResponse"]);
        }

        [Test]
        public void CanUpdateCustomerShippingAddress() {
            var cim = new CustomerInformationManager(TestHelper.TemplateFactory, ObjectMother.TestAuthentication);

            var createProfileResponse = cim.Create(_profileAttributes);
            _profileAttributes.GateWayId = createProfileResponse.Params["customerProfileId"];

            var createShippingAddressResponse = cim.Create(_profileAttributes, _addressAttributes);

            _addressAttributes.GateWayId = createShippingAddressResponse.Params["customerAddressId"];

            var response = cim.Update(_profileAttributes, _addressAttributes);
            Assert.IsTrue(response.Success);

        }



    }
}

