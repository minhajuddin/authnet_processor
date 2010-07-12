using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Authnet.Extensions {
    static class DictionaryExtensions {
        internal static void ForEach<TName, TValue>(this IDictionary<TName, TValue> dictionary, Action<TName, TValue> action) {
            if (dictionary == null) return;
            foreach (var pair in dictionary) {
                action(pair.Key, pair.Value);
            }
        }
    }
}