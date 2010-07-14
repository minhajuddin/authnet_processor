using Authnet;
using NUnit.Framework;

namespace Tests.Integration.Templating {
    [TestFixture]
    public class CreateTransactionRequetTemplateViewTests {
        [Test]
        public void RenderCreateTransactionRequestTemplate() {

            var transaction = new Transaction
                                  {
                                      Amount = 100,
                                      Description = "First Transaction",
                                      InVoiceNumber = "DG43RK",
                                      PaymentProfileId = "829831",
                                      ProfileId = "123215",
                                      PurchaseOrderNumber = "PO1234",
                                      RecurringBilling = false,
                                      TaxExempt = false
                                  };

            var factory = TestHelper.TemplateFactory;
            var template = factory.GetInstance("CreateTransactionRequest.spark");
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

    public class Transaction : ITransaction {
        public double Amount {
            get;
            set;
        }

        public string ProfileId {
            get;
            set;
        }

        public string PaymentProfileId {
            get;
            set;
        }

        public string InVoiceNumber {
            get;
            set;
        }

        public string Description {
            get;
            set;
        }

        public string PurchaseOrderNumber {
            get;
            set;
        }

        public bool TaxExempt {
            get;
            set;
        }

        public bool RecurringBilling {
            get;
            set;
        }
    }
}