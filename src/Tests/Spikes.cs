using NUnit.Framework;
using System.Collections.Generic;
using System.Collections;
namespace Tests {

    [TestFixture]
    public class Spikes {

        public void Test() {
            var hash = new Hashtable();
        }
    }

    public class ParameterSet {
        Hashtable _innerHash;
        Hashtable InnerHash {
            get {
                if ( _innerHash == null )
                    _innerHash = new Hashtable();
                return _innerHash;
            }
        }

        string _internalValue = "NO VALUE";

        public ParameterSet( string value ) {
            _internalValue = value;
        }

        public ParameterSet() {
        }

        public ParameterSet this[string index] {
            get {
                return ( ParameterSet ) InnerHash[index];
            }
            set {
                InnerHash[index] = value;
            }
        }

        public static implicit operator string( ParameterSet parameterSet ) {
            return parameterSet._internalValue;
        }

        public static implicit operator ParameterSet( string input ) {
            return new ParameterSet( input );
        }

        public override string ToString() {
            return _internalValue;
        }

    }

    [TestFixture]
    public class ParameterSetTests {

        [Test]
        public void CanInstantiateAParameterSet() {
            var set = new ParameterSet();
            Assert.NotNull( set );
        }

        [Test]
        public void CanAddDataToParameterSets() {
            var set = new ParameterSet();
            set["key"] = "XyfooKab";
            Assert.AreEqual( "XyfooKab", set["key"].ToString() );
        }

        [Test]
        public void CanAddMultiplePairsToParameterSets() {
            var set = new ParameterSet();
            set["key"] = "XyfooKab";
            set["other"] = "new value";
            Assert.AreEqual( "XyfooKab", set["key"].ToString() );
            Assert.AreEqual( "new value", set["other"].ToString() );
        }

        [Test]
        public void CanConvertStringsToParamters() {
            ParameterSet set = "some value";
            Assert.NotNull( set );
        }

        [Test]
        public void CanConvertParameterSetsToStrings() {
            string foo = new ParameterSet( "some string" );
            Assert.AreEqual( "some string", foo );
        }

        [Test]
        public void CanAddParamterSetToParameterSets() {
            var set = new ParameterSet();
            var auth = new ParameterSet();
            auth["user"] = "Khaja";
            auth["pwd"] = "test";
            set["auth"] = auth;
            Assert.AreEqual( "Khaja", set["auth"]["user"].ToString() );
        }

    }
}
