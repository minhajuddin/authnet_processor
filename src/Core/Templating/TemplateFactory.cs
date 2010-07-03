using Spark.FileSystem;
using Spark;

namespace Authnet.Core.Templating {
    public class TemplateFactory {

        SparkViewEngine _engine;

        public TemplateFactory( string templateDirectoryPath ) {

            var viewFolder = new FileSystemViewFolder( templateDirectoryPath );

            // Create an engine using the templates path as the root location
            // as well as the shared location
            _engine = new SparkViewEngine
                             {
                                 DefaultPageBaseType = typeof( TemplateView ).FullName,
                                 ViewFolder = viewFolder.Append( new SubViewFolder( viewFolder, "shared" ) )
                             };
        }

        //TODO:should probably cache the compiled views
        public ITemplateView GetInstance( string templateName ) {
            return ( TemplateView ) _engine.CreateInstance(
                                  new SparkViewDescriptor()
                                      .AddTemplate( templateName ) );
        }
    }
}
