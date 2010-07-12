using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Authnet.Extensions {
    public static class ObjectExtensions {
        public static TReturn As<TReturn>(this object obj) where TReturn : class {
            return obj as TReturn;
        }
    }
}