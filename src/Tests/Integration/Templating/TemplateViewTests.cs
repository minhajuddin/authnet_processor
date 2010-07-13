using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Authnet.Templating;
using NUnit.Framework;
using Tests.Integration.Gateways;

namespace Tests.Integration.Templating {
    [TestFixture]
    public class TemplateTests {

        private TemplateFactory _factory;

        [SetUp]
        public void Setup() {
            _factory = TestHelper.TestTemplateFactory;
        }

        [Test]
        public void RenderRendersTheTemplateWithTheInputData() {
            var template = _factory.GetInstance("TestTemplate.spark");
            var result = template.Render("replacement string");
            Assert.AreEqual("<output>replacement string</output>", result);

        }

        [Test]
        public void RenderRendersTheTemplateWithTheInputData2() {
            var template = _factory.GetInstance("TestTemplate.spark");
            var result = template.Render("Khaja Minhajuddin");
            Assert.AreEqual("<output>Khaja Minhajuddin</output>", result);

        }

        [Test]
        public void RenderRendersPartialsProperly() {
            var template = _factory.GetInstance("partialTestTemplate.spark");
            var result = template.Render("Khaja Minhajuddin");
            Assert.AreEqual("<auth>Khaja</auth>\r\n<output>Khaja Minhajuddin</output>", result);

        }

        [Test]
        public void RenderRendersTheTemplateWithTheModelSetToCustomer() {
            var customer = new Customer { Description = "test profile one", Email = "test@cosmicvent.com" };
            var templateView = _factory.GetInstance("modelTestTemplate.spark");
            var result = templateView.Render(customer);
            Assert.AreEqual("\r\n\r\n<description>test profile one</description>\r\n<email>test@cosmicvent.com</email>", result);
        }
    }
}