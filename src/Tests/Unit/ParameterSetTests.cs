using Authnet;
using NUnit.Framework;

namespace Tests.Unit {
    [TestFixture]
    public class ParameterSetTests {

        [Test]
        public void CanInstantiateAParameterSet() {
            var set = new ParameterSet();
            Assert.NotNull(set);
        }

        [Test]
        public void CanAddDataToParameterSets() {
            var set = new ParameterSet();
            set["key"] = "XyfooKab";
            Assert.AreEqual("XyfooKab", set["key"].ToString());
        }

        [Test]
        public void CanAddMultiplePairsToParameterSets() {
            var set = new ParameterSet();
            set["key"] = "XyfooKab";
            set["other"] = "new value";
            Assert.AreEqual("XyfooKab", set["key"].ToString());
            Assert.AreEqual("new value", set["other"].ToString());
        }

        [Test]
        public void CanConvertStringsToParamters() {
            ParameterSet set = "some value";
            Assert.NotNull(set);
        }

        [Test]
        public void CanConvertParameterSetsToStrings() {
            string foo = new ParameterSet("some string");
            Assert.AreEqual("some string", foo);
        }

        [Test]
        public void CanAddParamterSetToParameterSets() {
            var set = new ParameterSet();
            var auth = new ParameterSet();
            auth["user"] = "Khaja";
            auth["pwd"] = "test";
            set["auth"] = auth;
            Assert.AreEqual("Khaja", set["auth"]["user"].ToString());
        }

    }
}