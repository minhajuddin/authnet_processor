using Spark.FileSystem;
using Spark;

namespace Authnet.Core.Templating {
    public interface ITemplateView {
        object Model { get; set; }
        string Render( object data );
    }
}
