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

        public static ICustomer GetMockCustomer(Action<ICustomer> constructor) {
            return GetMock(constructor);
        }

        public static ITransaction GetMockTransaction(Action<ITransaction> constructor) {
            return GetMock(constructor);
        }

        public static IAddressAttributes GetMockCustomerAddress(Action<IAddressAttributes> constructor) {
            return GetMock(constructor);
        }

        public static T GetMock<T>(Action<T> constructor) where T : class {
            var mock = new Mock<T>();
            mock.SetupAllProperties();
            constructor(mock.Object);
            return mock.Object;
        }

        public static ICustomer GetMockCustomer() {
            var cust = new Mock<ICustomer>();
            cust.SetupAllProperties();
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