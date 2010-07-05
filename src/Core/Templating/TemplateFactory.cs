using Spark.FileSystem;
using Spark;
using System.IO;
using System;

namespace Authnet.Core.Templating {
    public class TemplateFactory {

        SparkViewEngine _engine;
        string _templateDirectoryPath;

        public TemplateFactory( string templateDirectoryPath ) {
            if ( !Directory.Exists( templateDirectoryPath ) )
                throw new ArgumentException( string.Format( "The directory {0} does not exist", templateDirectoryPath ) );

            _templateDirectoryPath = templateDirectoryPath;
            var viewFolder = new FileSystemViewFolder( templateDirectoryPath );

            // Create an engine using the templates path as the root location
            // as well as the shared location
            _engine = new SparkViewEngine
                             {
                                 DefaultPageBaseType = typeof( TemplateView ).FullName,
                                 ViewFolder = viewFolder
                             };
        }

        //TODO:should probably cache the compiled views
        public ITemplateView GetInstance( string templateName ) {
            if ( !File.Exists( Path.Combine( _templateDirectoryPath, templateName ) ) )
                throw new ArgumentException( string.Format( "The template:{0} does not exist in the directory:{1}", templateName, _templateDirectoryPath ) );
            return ( TemplateView ) _engine.CreateInstance(
                                  new SparkViewDescriptor()
                                      .AddTemplate( templateName ) );
        }
    }
}
