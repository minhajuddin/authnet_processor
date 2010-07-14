using System;
using Authnet;
using NUnit.Framework;

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