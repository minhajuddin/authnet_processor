using Authnet;
using NUnit.Framework;

namespace Tests.Integration.Templating {
    [TestFixture]
    public class CreateTransactionRequetTemplateViewTests {
        [Test]
        public void RenderCreateTransactionRequestTemplate() {

            var transaction = ObjectMother.GetMockTransaction(x =>
                                  {
                                      x.Amount = 100;
                                      x.Description = "First Transaction";
                                      x.InVoiceNumber = "DG43RK";
                                      x.PaymentProfileId = "829831";
                                      x.ProfileId = "123215";
                                      x.PurchaseOrderNumber = "PO1234";
                                      x.RecurringBilling = false;
                                      x.TaxExempt = false;
                                  });

            var factory = TestHelper.TemplateFactory;
            var template = factory.GetInstance("createCustomerProfileTransactionRequest.spark");
            template.Authentication = ObjectMother.TestAuthentication;
            var result = template.Render(transaction);
            var expectedXml =
                @"<?xml version=""1.0"" encoding=""utf-8"" ?>
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
        <invoiceNumber>DG43RK</invoiceNumber>
        <description>First Transaction</description>
        <purchaseOrderNumber>PO1234</purchaseOrderNumber>
      </order>
      <taxExempt>false</taxExempt>
      <recurringBilling>false</recurringBilling>
    </profileTransAuthCapture>
  </transaction>
</createCustomerProfileTransactionRequest>";
            Assert.AreEqual(expectedXml, result);

        }

    }

}