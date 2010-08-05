using System.Collections.Generic;
using Authnet;
using NUnit.Framework;

namespace Tests.Integration.Templating {
    [TestFixture]
    public class CreateTransactionRequetTemplateViewTests {
        private Dictionary<string, object> _chargeAttributes;
        private IProfileAttributes _profileAttributes;
        private IPaymentProfileAttributes _paymentProfileAttributes;
        private IOrder _order;
        private ITransaction _transaction;


        [SetUp]
        public void setup() {

            _profileAttributes = ObjectMother.GetMockProfileAttributes(x =>
            {
                x.GateWayId = "123215";
            });

            _paymentProfileAttributes = ObjectMother.GetMockPaymentProfileAttributes(x =>
            {
                x.GateWayId = "829831";
                x.MaskedCreditCard = "XXXX3333";
            });

            _order = ObjectMother.GetMockOrder(x =>
                                                   {
                                                       x.Amount = 100;
                                                       x.Description = "First Transaction";
                                                   });
            _transaction = ObjectMother.GetMockTransaction(x =>
                                                                  {
                                                                      x.GateWayId = "9999999";
                                                                  });

            _chargeAttributes = new Dictionary<string, object>();
            _chargeAttributes.Add("profile", _profileAttributes);
            _chargeAttributes.Add("paymentProfile", _paymentProfileAttributes);
            _chargeAttributes.Add("order", _order);
            _chargeAttributes.Add("transaction", _transaction);
            _chargeAttributes.Add("amount",(decimal)100);

        }

        [Test]
        public void RenderCreateTransactionRequestAuthCaptureTemplate() {

            var factory = TestHelper.TemplateFactory;
            var template = factory.GetInstance("createCustomerProfileTransactionRequest.spark");
            template.Authentication = ObjectMother.TestAuthentication;
            var result = template.Render(_chargeAttributes);

            var expectedXml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<createCustomerProfileTransactionRequest xmlns=""AnetApi/xml/v1/schema/AnetApiSchema.xsd"">  <merchantAuthentication>
    <name>54PB5egZ</name>
    <transactionKey>48V258vr55AE8tcg</transactionKey>
  </merchantAuthentication>
  <transaction>
    <profileTransAuthCapture>
      <amount>100</amount>
      <customerProfileId>123215</customerProfileId>
      <customerPaymentProfileId>829831</customerPaymentProfileId>
      <order>
        <invoiceNumber></invoiceNumber>
        <description>First Transaction</description>
        <purchaseOrderNumber></purchaseOrderNumber>
      </order>
      </profileTransAuthCapture>
  </transaction>
</createCustomerProfileTransactionRequest>";

            Assert.AreEqual(expectedXml, result);
        }


        [Test]
        public void RenderCreateTransactionRequestAuthOnlyTemplate() {

            var factory = TestHelper.TemplateFactory;
            var template = factory.GetInstance("createCustomerProfileTransactionRequestAuthOnly.spark");
            template.Authentication = ObjectMother.TestAuthentication;
            var result = template.Render(_chargeAttributes);

            var expectedXml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<createCustomerProfileTransactionRequest xmlns=""AnetApi/xml/v1/schema/AnetApiSchema.xsd"">  <merchantAuthentication>
    <name>54PB5egZ</name>
    <transactionKey>48V258vr55AE8tcg</transactionKey>
  </merchantAuthentication>
  <transaction>
    <profileTransAuthOnly>
      <amount>100</amount>
      <customerProfileId>123215</customerProfileId>
      <customerPaymentProfileId>829831</customerPaymentProfileId>
      <order>
        <invoiceNumber></invoiceNumber>
        <description>First Transaction</description>
        <purchaseOrderNumber></purchaseOrderNumber>
      </order>
      </profileTransAuthOnly>
  </transaction>
</createCustomerProfileTransactionRequest>";

            Assert.AreEqual(expectedXml, result);
        }

        [Test]
        public void RenderCreateTransactionRequestCaptureOnlyTemplate() {

            var factory = TestHelper.TemplateFactory;
            var template = factory.GetInstance("createCustomerProfileTransactionRequestCapchOnly.spark");
            template.Authentication = ObjectMother.TestAuthentication;
            var result = template.Render(_chargeAttributes);

            var expectedXml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<createCustomerProfileTransactionRequest xmlns=""AnetApi/xml/v1/schema/AnetApiSchema.xsd"">  <merchantAuthentication>
    <name>54PB5egZ</name>
    <transactionKey>48V258vr55AE8tcg</transactionKey>
  </merchantAuthentication>
  <transaction>
    <profileTransCaptureOnly>
      <amount>100</amount>
      <customerProfileId>123215</customerProfileId>
      <customerPaymentProfileId>829831</customerPaymentProfileId>
      <order>
        <invoiceNumber></invoiceNumber>
        <description>First Transaction</description>
        <purchaseOrderNumber></purchaseOrderNumber>
      </order>
      </profileTransCaptureOnly>
  </transaction>
</createCustomerProfileTransactionRequest>";

            Assert.AreEqual(expectedXml, result);
        }


        [Test]
        public void RenderCreateTransactionRequestRefundTemplate() {

            var factory = TestHelper.TemplateFactory;
            var template = factory.GetInstance("createCustomerProfileTransactionRequestRefund.spark");
            template.Authentication = ObjectMother.TestAuthentication;
            var result = template.Render(_chargeAttributes);

            var expectedXml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<createCustomerProfileTransactionRequest xmlns=""AnetApi/xml/v1/schema/AnetApiSchema.xsd"">  <merchantAuthentication>
    <name>54PB5egZ</name>
    <transactionKey>48V258vr55AE8tcg</transactionKey>
  </merchantAuthentication>
  <transaction>
    <profileTransRefund>
      <amount>100</amount>
      <customerProfileId>123215</customerProfileId>
      <customerPaymentProfileId>829831</customerPaymentProfileId>
      <creditCardNumberMasked>XXXX3333</creditCardNumberMasked>
      <order>
        <invoiceNumber></invoiceNumber>
        <description>refund</description>
        <purchaseOrderNumber></purchaseOrderNumber>
      </order>
      <transId>9999999</transId>
      </profileTransRefund>
  </transaction>
</createCustomerProfileTransactionRequest>";

            Assert.AreEqual(expectedXml, result);
        }


        [Test]
        public void RenderCreateTransactionRequestVoidTemplate() {
            var factory = TestHelper.TemplateFactory;
            var template = factory.GetInstance("createCustomerProfileTransactionRequestVoid.spark");
            template.Authentication = ObjectMother.TestAuthentication;
            var result = template.Render(_chargeAttributes);

            var expectedXml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<createCustomerProfileTransactionRequest xmlns=""AnetApi/xml/v1/schema/AnetApiSchema.xsd"">  <merchantAuthentication>
    <name>54PB5egZ</name>
    <transactionKey>48V258vr55AE8tcg</transactionKey>
  </merchantAuthentication>
  <transaction>
    <profileTransVoid>
	  <customerProfileId>123215</customerProfileId>
      <customerPaymentProfileId>829831</customerPaymentProfileId>
      <transId>9999999</transId>
    </profileTransVoid>
  </transaction>
</createCustomerProfileTransactionRequest>";
            Assert.AreEqual(expectedXml, result);
        }
    }

}

