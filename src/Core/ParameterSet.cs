using System.Collections;

namespace Authnet {
    public class ParameterSet {
        Hashtable _innerHash;
        Hashtable InnerHash {
            get {
                if (_innerHash == null)
                    _innerHash = new Hashtable();
                return _innerHash;
            }
        }

        string _internalValue = "NO VALUE";

        public ParameterSet(string value) {
            _internalValue = value;
        }

        public ParameterSet() {
        }

        public ParameterSet this[string index] {
            get {
                return (ParameterSet)InnerHash[index];
            }
            set {
                InnerHash[index] = value;
            }
        }

        public static implicit operator string(ParameterSet parameterSet) {
            return parameterSet._internalValue;
        }

        public static implicit operator ParameterSet(string input) {
            return new ParameterSet(input);
        }

        public override string ToString() {
            return _internalValue;
        }

    }
}