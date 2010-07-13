using Authnet.Serializers;
using NUnit.Framework;

namespace Tests.Unit.Serializers {
    [TestFixture]
    public class CreateCustomerProfileSerializerTests {
        [Test]
        public void CanSerialize() {
            var serializer = new CreateCustomerProfileSerializer();

            var rawXml = @"<?xml version='1.0' encoding='utf-8'?>
                           <createCustomerProfileResponse xmlns='AnetApi/xml/v1/schema/AnetApiSchema.xsd'>
                                <messages>
                                    <resultCode>Ok</resultCode>
                                    <message>
                                        <code>I00001</code>
                                        <text>Successful.</text>
                                    </message>
                                </messages>
                                <customerProfileId>10000</customerProfileId>
                                <customerPaymentProfileIdList></customerPaymentProfileIdList>
                                <customerShippingAddressIdList></customerShippingAddressIdList>
                                <validationDirectResponseList></validationDirectResponseList>
                            </createCustomerProfileResponse>";

            var serializeResponse = serializer.Serialize(rawXml);

            Assert.AreEqual(true, serializeResponse.Success);
            Assert.AreEqual("Successful.", serializeResponse.Message);
            Assert.AreEqual(10000, serializeResponse.ParameterSet["customerProfileId"]);
        }
    }
}