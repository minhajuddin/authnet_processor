using Authnet.Model;
using Spark;
using System.IO;

namespace Authnet.Templating {
    public abstract class TemplateView : AbstractSparkView, ITemplateView {
        public object Model { get; set; }
        public Authentication Authentication { get; set; }
        //public ICustomer Customer { get; set; }

        public string Render(object model) {
            Model = model;
            //  Customer = model as ICustomer;
            using (var writer = new StringWriter()) {
                this.RenderView(writer);
                return writer.ToString();
            }
        }
    }
}