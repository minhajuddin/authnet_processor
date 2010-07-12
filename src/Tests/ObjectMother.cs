using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Authnet.Model;

namespace Tests {
    internal static class ObjectMother {
        public static Authentication TestAuthentication {
            get { return new Authentication("54PB5egZ", "48V258vr55AE8tcg"); }
        }
    }
}