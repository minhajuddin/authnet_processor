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

        public static IProfileAttributes GetMockProfileAttributes(Action<IProfileAttributes> constructor) {
            return GetMock(constructor);
        }

        public static IPaymentProfileAttributes GetMockPaymentProfileAttributes(Action<IPaymentProfileAttributes> constructor) {
            return GetMock(constructor);
        }

        public static ITransaction GetMockTransaction(Action<ITransaction> constructor) {
            return GetMock(constructor);
        }

        public static IAddressAttributes GetMockAddressAttributes(Action<IAddressAttributes> constructor) {
            return GetMock(constructor);
        }

        public static ICreditCardAttributes GetMockCreditCardAttributes(Action<ICreditCardAttributes> constructor) {
            return GetMock(constructor);
        }

        public static IOrder GetMockOrder(Action<IOrder> constructor) {
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

        public static IPaymentProfileAttributes GetMockPaymentProfileAttributes() {
            var cust = new Mock<IPaymentProfileAttributes>();
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
