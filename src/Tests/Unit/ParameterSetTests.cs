using Authnet;
using NUnit.Framework;

namespace Tests {
    [TestFixture]
    public class ParameterSetTests {

        [Test]
        public void CanInstantiateAParameterSet() {
            var set = new Hash();
            Assert.NotNull(set);
        }

        [Test]
        public void CanAddDataToParameterSets() {
            var set = new Hash();
            set["key"] = "XyfooKab";
            Assert.AreEqual("XyfooKab", set["key"].ToString());
        }

        [Test]
        public void CanAddMultiplePairsToParameterSets() {
            var set = new Hash();
            set["key"] = "XyfooKab";
            set["other"] = "new value";
            Assert.AreEqual("XyfooKab", set["key"].ToString());
            Assert.AreEqual("new value", set["other"].ToString());
        }

        [Test]
        public void CanConvertStringsToParamters() {
            Hash set = "some value";
            Assert.NotNull(set);
        }

        [Test]
        public void CanConvertParameterSetsToStrings() {
            string foo = new Hash("some string");
            Assert.AreEqual("some string", foo);
        }

        [Test]
        public void CanAddParamterSetToParameterSets() {
            var set = new Hash();
            var auth = new Hash();
            auth["user"] = "Khaja";
            auth["pwd"] = "test";
            set["auth"] = auth;
            Assert.AreEqual("Khaja", set["auth"]["user"].ToString());
        }

    }
}