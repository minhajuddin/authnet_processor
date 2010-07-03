using Spark.FileSystem;
using Spark;

namespace Authnet.Core.Templating {
    public interface ITemplate {
        string Render( object data );
    }
}
