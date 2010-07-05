using Spark.FileSystem;
using Spark;
using Authnet.Core.Model;

namespace Authnet.Core.Templating {
    public interface ITemplateView {
        Authentication Authentication { get; set; }
        object Model { get; set; }
        string Render( object data );
    }
}
