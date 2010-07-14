using System;
using Authnet;
using NUnit.Framework;
using Tests.Integration.Templating;

namespace Tests.Integration.Gateways {
    [TestFixture]
    public class CustomerInformationManagerTests {
        [Test]
        public void CanGetAllCustomersIds() {
            var cim = new CustomerInformationManager(TestHelper.TemplateFactory, ObjectMother.TestAuthentication);
            var ids = cim.GetCustomerProfileIds();
            Assert.NotNull(ids);
            //Assert.Greater(ids.Length, 0);
        }

        [Test]
        public void CanCreateCustomerProfile() {
            var random = new Random();
            var customer = new Customer { Description = "test profile" + random.Next(), Email = "test2@cosmicvent.com" };
            var cim = new CustomerInformationManager(TestHelper.TemplateFactory, ObjectMother.TestAuthentication);
            var response = cim.CreateCustomerProfile(customer);
            Assert.IsTrue(response.Success);
            Assert.NotNull(response.ParameterSet["customerProfileId"]);
        }

        [Test]
        public void CanCreatePaymentProfile() {
            var random = new Random();
            var customer = new Customer
                               {
                                   Description = "test profile" + random.Next(),
                                   Email = "test@cosmicvent.com",
                                   FirstName = "Rafi",
                                   LastName = "Sk",
                                   Address = "Rajendranagar",
                                   City = "Hyderabad",
                                   State = "AP",
                                   Zip = "500048",
                                   Company = "cosmicvent",
                                   Country = "India",
                                   CardNumber = "4111111111111111",
                                   ExpirationDate = DateTime.Now.AddMonths(1).ToString("yyyy-MM")

                               };

            var cim = new CustomerInformationManager(TestHelper.TemplateFactory, ObjectMother.TestAuthentication);
            var createProfileResponse = cim.CreateCustomerProfile(customer);

            customer.ProfileId = createProfileResponse.ParameterSet["customerProfileId"];

            var createPaymentProfileResponse = cim.CreatePaymentProfile(customer);


            Assert.IsTrue(createPaymentProfileResponse.Success);
            Assert.NotNull(createPaymentProfileResponse.ParameterSet["customerPaymentProfileId"].ToString());
        }

        [Test]
        public void CanCreatePaymentProfileTransaction() {
            var random = new Random();

            var next = random.Next(1,5000);
            var customer = new Customer
            {
                Description = "test profile" + next,
                Email = "test@cosmicvent.com",
                FirstName = "Rafi",
                LastName = "Sk",
                Address = "Rajendranagar",
                City = "Hyderabad",
                State = "AP",
                Zip = "500048",
                Company = "cosmicvent",
                Country = "India",
                CardNumber = "4111111111111111",
                ExpirationDate = DateTime.Now.AddMonths(1).ToString("yyyy-MM")

            };

            var transaction = new Transaction
            {
                Amount = next,
                Description = "Transaction" + next,
                InVoiceNumber = "IN" + next,
                PurchaseOrderNumber = "PO" + next,
                RecurringBilling = false,
                TaxExempt = false
            };

            var cim = new CustomerInformationManager(TestHelper.TemplateFactory, ObjectMother.TestAuthentication);
            var createProfileResponse = cim.CreateCustomerProfile(customer);

            var profileid = createProfileResponse.ParameterSet["customerProfileId"];
            customer.ProfileId = profileid;

            var createPaymentProfileResponse = cim.CreatePaymentProfile(customer);

            transaction.ProfileId = profileid;
            transaction.PaymentProfileId = createPaymentProfileResponse.ParameterSet["customerPaymentProfileId"].ToString();
            var createPaymentProfileTransactionResponse = cim.CreateCustomerProfileTransaction(transaction);


            Assert.IsTrue(createPaymentProfileTransactionResponse.Success);
            Assert.NotNull(createPaymentProfileTransactionResponse.ParameterSet["directResponse"].ToString());
        }

    }

    public class Customer : ICustomer {
        public string ProfileId {
            get;
            set;
        }

        public string Description { get; set; }
        public string Email { get; set; }
        public string FirstName {
            get;
            set;
        }

        public string LastName {
            get;
            set;
        }

        public string Company {
            get;
            set;
        }

        public string Address {
            get;
            set;
        }

        public string City {
            get;
            set;
        }

        public string State {
            get;
            set;
        }

        public string Zip {
            get;
            set;
        }

        public string Country {
            get;
            set;
        }

        public string PhoneNumber {
            get;
            set;
        }

        public string FaxNumber {
            get;
            set;
        }

        public string CardNumber {
            get;
            set;
        }

        public string ExpirationDate {
            get;
            set;
        }
    }
}

