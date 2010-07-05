using Spark;
using System.IO;
using Authnet.Core.Model;

namespace Authnet.Core.Templating {
    public abstract class TemplateView : AbstractSparkView, ITemplateView {
        public object Model { get; set; }
        public Authentication Authentication { get; set; }

        public string Render( object model ) {
            Model = model;
            using ( var writer = new StringWriter() ) {
                this.RenderView( writer );
                return writer.ToString();
            }
        }
    }
}