using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Authnet.Core.Templating;

namespace Tests {
    internal static class ObjectMother {
        public static TemplateFactory TemplateFactory {
            get {
                return new TemplateFactory();
            }
        }
    }
}
