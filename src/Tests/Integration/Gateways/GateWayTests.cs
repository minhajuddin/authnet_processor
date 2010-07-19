using System;
using Authnet;
using Authnet.Gateways;
using NUnit.Framework;

namespace Tests.Integration.Gateways {
    [TestFixture]
    public class GateWayTests {

        private IProfileAttributes _profileAttributes;
        private IAddressAttributes _addressAttributes;
        private ICreditCardAttributes _creditCardAttributes;
        private IPaymentProfileAttributes _paymentProfileAttributes;
        private ITransaction _transaction;
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

            _transaction = ObjectMother.GetMockTransaction(x => { x.Type = TransactionType.AuthCapture; });

        }

        [Test]
        public void CanCreatePaymentProfileTransactionAuthCapture() {

            var cim = new CustomerInformationManager(TestHelper.TemplateFactory, ObjectMother.TestAuthentication);
            var createProfileResponse = cim.Create(_profileAttributes);

            _profileAttributes.GateWayId = createProfileResponse.Params["customerProfileId"];


            var createPaymentProfileResponse = cim.CreatePaymentProfile(_profileAttributes, _addressAttributes, _creditCardAttributes);


            _paymentProfileAttributes.GateWayId = createPaymentProfileResponse.Params["customerPaymentProfileId"].ToString();

            var gateway = new Gateway(TestHelper.TemplateFactory, ObjectMother.TestAuthentication);

            var createPaymentProfileTransactionResponse = gateway.Charge(_profileAttributes, _paymentProfileAttributes, _order);


            Assert.IsTrue(createPaymentProfileTransactionResponse.Success);
            Assert.NotNull(createPaymentProfileTransactionResponse.Params["directResponse"].ToString());

        }


        //[Test]
        //public void CanCreatePaymentProfileTransactionAuthCapture() {

        //    GetResult(() => TransactionType.AuthCapture);
        //}

        //[Test]
        //public void CanCreatePaymentProfileTransactionAuthOnly() {

        //    GetResult(() => TransactionType.AuthOnly);
        //}

        //[Test]
        //public void CanCreatePaymentProfileTransactionCaptureOnly() {
        //    GetResult(() => TransactionType.CaptureOnly);
        //}

        //private void GetResult(Func<TransactionType> action) {
        //    var cim = new CustomerInformationManager(TestHelper.TemplateFactory, ObjectMother.TestAuthentication);
        //    var createProfileResponse = cim.Create(_profileAttributes);

        //    _profileAttributes.GateWayId = createProfileResponse.Params["customerProfileId"];


        //    var createPaymentProfileResponse = cim.CreatePaymentProfile(_profileAttributes, _addressAttributes, _creditCardAttributes);


        //    _paymentProfileAttributes.GateWayId = createPaymentProfileResponse.Params["customerPaymentProfileId"].ToString();

        //    var gateway = new Gateway(TestHelper.TemplateFactory, ObjectMother.TestAuthentication);

        //    _transaction.Type = action();
        //    var createPaymentProfileTransactionResponse = gateway.Charge(_profileAttributes, _paymentProfileAttributes, _order);


        //    Assert.IsTrue(createPaymentProfileTransactionResponse.Success);
        //    Assert.NotNull(createPaymentProfileTransactionResponse.Params["directResponse"].ToString());
        //}
    }
}