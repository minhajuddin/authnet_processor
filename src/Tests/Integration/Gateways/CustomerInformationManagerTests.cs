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
            Assert.NotNull(response.ParameterSet["customerProfileId"]);
        }

        [Test]
        public void CanCreatePaymentProfile() {
            var cim = new CustomerInformationManager(TestHelper.TemplateFactory, ObjectMother.TestAuthentication);
            var createProfileResponse = cim.CreateCustomerProfile(_customer);

            _customer.ProfileId = createProfileResponse.ParameterSet["customerProfileId"];

            var createPaymentProfileResponse = cim.CreatePaymentProfile(_customer);


            Assert.IsTrue(createPaymentProfileResponse.Success);
            Assert.NotNull(createPaymentProfileResponse.ParameterSet["customerPaymentProfileId"].ToString());
        }

        [Test]
        public void CanCreatePaymentProfileTransaction() {

            var cim = new CustomerInformationManager(TestHelper.TemplateFactory, ObjectMother.TestAuthentication);
            var createProfileResponse = cim.CreateCustomerProfile(_customer);

            var profileid = createProfileResponse.ParameterSet["customerProfileId"];
            _customer.ProfileId = profileid;

            var createPaymentProfileResponse = cim.CreatePaymentProfile(_customer);

            _transaction.ProfileId = profileid;
            _transaction.PaymentProfileId = createPaymentProfileResponse.ParameterSet["customerPaymentProfileId"].ToString();
            var createPaymentProfileTransactionResponse = cim.CreateCustomerProfileTransaction(_transaction);


            Assert.IsTrue(createPaymentProfileTransactionResponse.Success);
            Assert.NotNull(createPaymentProfileTransactionResponse.ParameterSet["directResponse"].ToString());
        }

    }

}

