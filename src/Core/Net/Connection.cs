using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Authnet.Core.Extensions;
using System.IO;
using Authnet.Core.Exceptions;

namespace Authnet.Core.Net {
    public class Connection {

        string _endPoint { get; set; }

        const int OPEN_TIMEOUT = 10 * 1000;
        const int READ_TIMEOUT = 10 * 1000;
        const bool VERIFY_PEER = true;
        const bool RETRY_SAFE = false;
        Encoding _encoding;
        //const int RUBY_184_POST_HEADERS = { "Content-Type" => "application/x-www-form-urlencoded" };

        public Connection( string endpoint ) {
            _endPoint = endpoint;
            _encoding = Encoding.UTF8;
            Logger.Debug( string.Format( "Connecting to {0}", _endPoint ) );
        }

        public string Request( string method, string body, IDictionary<string, string> headers ) {
            method = method.ToUpper();
            string result = null;
            HttpWebResponse response = null;
            try {
                if ( method == "GET" ) {
                    response = httpGet( headers );
                }
                else if ( method == "POST" ) {
                    Logger.Debug( body );
                    response = httpPost( body, headers );
                }
                else {
                    throw new ArgumentException( string.Format( "Unsupported request method {0}", method ) );
                }
            } catch ( WebException ex ) {
                throw new ConnectionException( "Encountered a web exception while making a request", ex );
            }

            result = extractBody( response );
            return result;
        }

        string extractBody( HttpWebResponse response ) {
            string body = null;

            using ( var sr = new StreamReader( response.GetResponseStream(), _encoding ) )
                body = sr.ReadToEnd();

            var status = ( int ) response.StatusCode;
            if ( status >= 200 && status < 300 )
                return body;

            throw new ResponseException( string.Format( "STATUS:\n{0}\n\nBODY:\n{1}", status, body ) );
        }

        HttpWebResponse httpGet( IDictionary<string, string> headers ) {
            var request = http( headers );
            request.Method = "GET";
            return ( HttpWebResponse ) request.GetResponse();
        }

        HttpWebResponse httpPost( string body, IDictionary<string, string> headers ) {
            var request = http( headers );
            request.Method = "POST";

            byte[] bytes = _encoding.GetBytes( body );
            request.ContentLength = bytes.Length;

            using ( var requestStream = request.GetRequestStream() )
                requestStream.Write( bytes, 0, bytes.Length );

            return ( HttpWebResponse ) request.GetResponse();
        }

        HttpWebRequest http( IDictionary<string, string> headers ) {
            var request = ( HttpWebRequest ) WebRequest.Create( _endPoint );
            request.Timeout = OPEN_TIMEOUT;
            request.ReadWriteTimeout = READ_TIMEOUT;
            request.ContentType = "text/xml";

            headers.ForEach( ( name, value ) => request.Headers.Add( name, value ) );

            return request;
        }
    }
}
