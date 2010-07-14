using Authnet.Templating;
using NUnit.Framework;

namespace Tests.Integration.Templating {
    [TestFixture]
    public class TemplateFactoryTests {

        [Test]
        public void CanGetATemplateView() {
            ITemplateView view = TestHelper.TestTemplateFactory.GetInstance("TestTemplate.spark");
            var result = view.Render("test");
            Assert.AreEqual("<output>test</output>", result);

        }
    }
}