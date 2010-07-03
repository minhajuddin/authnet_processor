using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Authnet.Core.Templating;

namespace Tests {
    [TestFixture]
    public class TemplateTests {
        [Test]
        public void RenderRendersTheTemplateWithTheInputData() {

            var template = new Template();

            var result = template.Render( "replacement string" );
            Console.WriteLine( result );

            Assert.AreEqual( "<output>replacement string</output>", result );

        }
    }
}
