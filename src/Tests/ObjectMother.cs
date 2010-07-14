using Authnet.Model;
using Authnet;
using Moq;
using System;
using System.IO;

namespace Tests {
    internal static class ObjectMother {
        public static Authentication TestAuthentication {
            get { return new Authentication("54PB5egZ", "48V258vr55AE8tcg"); }
        }

        public static ICustomer GetMockCustomer() {
            var cust = new Mock<ICustomer>();
            cust.SetupAllProperties();
            return cust.Object;
        }

        public static ICustomer GetMockCustomer(Action<ICustomer> constructor) {
            var cust = new Mock<ICustomer>();
            cust.SetupAllProperties();
            constructor(cust.Object);
            return cust.Object;
        }

        public static string TestDirectory {
            get {
                return Path.Combine(Environment.CurrentDirectory, "../../TestData");
            }
        }

        public static string TemplateDirectory {
            get {
                return Path.Combine(Environment.CurrentDirectory, "../../../Core/Templates");
            }
        }
    }
}