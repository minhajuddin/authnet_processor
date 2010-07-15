using System;
using Authnet;
using NUnit.Framework;

namespace Tests.Integration.Gateways {
    [TestFixture]
    public class CustomerInformationManagerTests {
        ICustomer _customer;
        ITransaction _transaction;

        [SetUp]
        public void Setup() {

            var random = new Random();
            _customer = ObjectMother.GetMockCustomer();


            _customer.Description = "test profile" + random.Next();
            _customer.Email = "test@cosmicvent.com";
            _customer.FirstName = "Rafi";
            _customer.LastName = "Sk";
            _customer.Address = "Rajendranagar";
            _customer.City = "Hyderabad";
            _customer.State = "AP";
            _customer.Zip = "500048";
            _customer.Company = "cosmicvent";
            _customer.Country = "India";
            _customer.CardNumber = "4111111111111111";
            _customer.ExpirationDate = DateTime.Now.AddMonths(1).ToString("yyyy-MM");


            var next = random.Next(1, 5000);

            _transaction = ObjectMother.GetMockTransaction(x =>
            {
                x.Amount = next;
                x.Description = "Transaction" + next;
                x.InVoiceNumber = "IN" + next;
                x.PurchaseOrderNumber = "PO" + next;
                x.RecurringBilling = false;
                x.TaxExempt = false;
            });

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
            var customer = ObjectMother.GetMockCustomer(x =>
                                                            {
                                                                x.Description = "test profile" + random.Next();
                                                                x.Email = "test2@cosmicvent.com";
                                                            });
            var cim = new CustomerInformationManager(TestHelper.TemplateFactory, ObjectMother.TestAuthentication);
            var response = cim.CreateCustomerProfile(customer);
            Assert.IsTrue(response.Success);
            Assert.NotNull(response.Params["customerProfileId"]);
        }

        [Test]
        public void CanCreatePaymentProfile() {
            var cim = new CustomerInformationManager(TestHelper.TemplateFactory, ObjectMother.TestAuthentication);
            var createProfileResponse = cim.CreateCustomerProfile(_customer);

            _customer.ProfileId = createProfileResponse.Params["customerProfileId"];

            var createPaymentProfileResponse = cim.CreatePaymentProfile(_customer);


            Assert.IsTrue(createPaymentProfileResponse.Success);
            Assert.NotNull(createPaymentProfileResponse.Params["customerPaymentProfileId"].ToString());
        }

        [Test]
        public void CanCreatePaymentProfileTransaction() {

            var cim = new CustomerInformationManager(TestHelper.TemplateFactory, ObjectMother.TestAuthentication);
            var createProfileResponse = cim.CreateCustomerProfile(_customer);

            var profileid = createProfileResponse.Params["customerProfileId"];
            _customer.ProfileId = profileid;

            var createPaymentProfileResponse = cim.CreatePaymentProfile(_customer);

            _transaction.ProfileId = profileid;
            _transaction.PaymentProfileId = createPaymentProfileResponse.Params["customerPaymentProfileId"].ToString();
            var createPaymentProfileTransactionResponse = cim.CreateCustomerProfileTransaction(_transaction);


            Assert.IsTrue(createPaymentProfileTransactionResponse.Success);
            Assert.NotNull(createPaymentProfileTransactionResponse.Params["directResponse"].ToString());
        }

        [Test]
        public void CanCreateCustomerShippingAddress() {
            var cim = new CustomerInformationManager(TestHelper.TemplateFactory, ObjectMother.TestAuthentication);
            //var createProfileResponse = cim.CreateCustomerProfile(_customer);

            var customerAddress = ObjectMother.GetMockCustomerAddress(x =>
            {
                var random = new Random();
                x.FirstName = "Rafi" + random.Next(1, 5000);
                x.LastName = "Sk";
                x.Address = "Rajendranagar";
                x.City = "Hyderabad";
                x.State = "AP";
                x.Zip = "500048";
                x.Company = "cosmicvent";
                x.Country = "India";
                x.PhoneNumber = "9951313930";
            });

            //customerAddress.ProfileId = createProfileResponse.Params["customerProfileId"];
            var createShippingAddressResponse = cim.CreateCustomerShippingAddress(customerAddress);
            Assert.IsTrue(createShippingAddressResponse.Success);
            Assert.NotNull(createShippingAddressResponse.Params["customerAddressId"].ToString());
        }

    }

}

