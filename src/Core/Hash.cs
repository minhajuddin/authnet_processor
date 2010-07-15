using System.Collections;

namespace Authnet {
    public class Hash {
        Hashtable _innerHash;
        Hashtable InnerHash {
            get {
                if (_innerHash == null)
                    _innerHash = new Hashtable();
                return _innerHash;
            }
        }

        string _internalValue = "NO VALUE";

        public Hash(string value) {
            _internalValue = value;
        }

        public Hash() {
        }

        public Hash this[string index] {
            get {
                return (Hash)InnerHash[index];
            }
            set {
                InnerHash[index] = value;
            }
        }

        public static implicit operator string(Hash hash) {
            return hash._internalValue;
        }

        public static implicit operator Hash(string input) {
            return new Hash(input);
        }

        public override string ToString() {
            return _internalValue;
        }

    }
}