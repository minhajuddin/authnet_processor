using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Spark.FileSystem;
using Spark;

namespace Authnet.Core.Templating {
    public class Template : ITemplate {
        public string Render( string data ) {

            // Find the full path to the template file, 
            // using current directory if argument isn't fully qualified
            var templatePath = @"G:\repositories\os\authnet_processor\src\Tests\TestData\TestTemplate.spark";
            var templateName = @"TestTemplate.spark";
            var templateDirPath = @"G:\repositories\os\authnet_processor\src\Tests\TestData\";

            var viewFolder = new FileSystemViewFolder( templateDirPath );

            Console.WriteLine( viewFolder.BasePath );

            // Create an engine using the templates path as the root location
            // as well as the shared location
            var engine = new SparkViewEngine
                             {
                                 DefaultPageBaseType = typeof( TemplateView ).FullName,
                                 ViewFolder = viewFolder.Append( new SubViewFolder( viewFolder, "Shared" ) )
                             };

            TemplateView view;
            // compile and instantiate the template
            view = ( TemplateView ) engine.CreateInstance(
                                  new SparkViewDescriptor()
                                      .AddTemplate( templateName ) );


            // load the second argument, or default to reading stdin
            view.Model = data;


            // write out to the third argument, or default to writing stdout
            var writer = new StringWriter();
            view.RenderView( writer );
            return writer.ToString();
            return "<output>Hello world</output>";
        }
    }

    public interface ITemplate {
        string Render( string data );
    }

    public abstract class TemplateView : AbstractSparkView {
        public object Model { get; set; }
    }
}
