using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Authnet.Core.Templating;
using System.IO;

namespace Tests {
    [TestFixture]
    public class TemplateFactoryTests {

        [Test]
        public void CanGetATemplateView() {
            ITemplateView view = TestHelper.TestTemplateFactory.GetInstance( "TestTemplate.spark" );
            var result = view.Render( "test" );
            Assert.AreEqual( "<output>test</output>", result );

        }
    }

}
