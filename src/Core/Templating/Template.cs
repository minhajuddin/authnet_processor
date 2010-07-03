using Spark.FileSystem;
using Spark;
using System.IO;

namespace Authnet.Core.Templating {
    public class Template : ITemplate {
        public string Render( object data ) {

            var view = ( new TemplateFactory() ).GetInstance( "TestTemplate.spark" );
            // load the second argument, or default to reading stdin
            view.Model = data;


            // write out to the third argument, or default to writing stdout
            var writer = new StringWriter();
            view.RenderView( writer );
            return writer.ToString();
        }
    }
}
