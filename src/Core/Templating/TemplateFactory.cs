using Spark.FileSystem;
using Spark;

namespace Authnet.Core.Templating {
    public class TemplateFactory {
        public TemplateView GetInstance( string templateName ) {
            // Find the full path to the template file, 
            // using current directory if argument isn't fully qualified
            var templatePath = @"G:\repositories\os\authnet_processor\src\Tests\TestData\TestTemplate.spark";
            var templateDirPath = @"G:\repositories\os\authnet_processor\src\Tests\TestData\";

            var viewFolder = new FileSystemViewFolder( templateDirPath );

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

            return view;
        }
    }
}
