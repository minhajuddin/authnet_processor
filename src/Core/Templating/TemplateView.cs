using Spark;
using System.IO;

namespace Authnet.Core.Templating {
    public abstract class TemplateView : AbstractSparkView {
        public object Model { get; set; }

        public string Render( object model ) {
            Model = model;
            using ( var writer = new StringWriter() ) {
                this.RenderView( writer );
                return writer.ToString();
            }
        }
    }
}