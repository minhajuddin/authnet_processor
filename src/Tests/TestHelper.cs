using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Authnet.Templating;

namespace Tests {
    static class TestHelper {

        internal static TemplateFactory TemplateFactory {
            get {
                //return new TemplateFactory(@"G:\repositories\os\authnet_processor\src\Core\Templates\");
                return new TemplateFactory(@"D:\Repos\authnet_processor\src\Core\Templates\");
            }
        }

        internal static TemplateFactory TestTemplateFactory {
            get {
                //return new TemplateFactory(@"G:\repositories\os\authnet_processor\src\Tests\TestData\");
                return new TemplateFactory(@"D:\Repos\authnet_processor\src\Tests\TestData\");
            }
        }

    }
}
