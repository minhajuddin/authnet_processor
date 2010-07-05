using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Authnet.Core.Templating;

namespace Tests {
    [TestFixture]
    public class TemplateTests {

        private TemplateFactory _factory;

        [SetUp]
        public void Setup() {
            _factory = TestHelper.TestTemplateFactory;
        }

        [Test]
        public void RenderRendersTheTemplateWithTheInputData() {
            var template = _factory.GetInstance( "TestTemplate.spark" );
            var result = template.Render( "replacement string" );
            Assert.AreEqual( "<output>replacement string</output>", result );

        }

        [Test]
        public void RenderRendersTheTemplateWithTheInputData2() {
            var template = _factory.GetInstance( "TestTemplate.spark" );
            var result = template.Render( "Khaja Minhajuddin" );
            Assert.AreEqual( "<output>Khaja Minhajuddin</output>", result );

        }
    }
}
