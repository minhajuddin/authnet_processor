using Authnet.Model;
using Authnet.Net;
using Authnet.Parsers;
using Authnet.Templating;

namespace Authnet {
    public abstract class GatewayBase {
        protected string _url = "https://apitest.authorize.net/xml/v1/request.api";
        protected TemplateFactory _templateFactory;
        protected Authentication _authentication;

        protected GatewayBase(TemplateFactory templateFactory, Authentication authentication) {
            _templateFactory = templateFactory;
            _authentication = authentication;
        }

        public Response GetResponse(object data, string templateName, IParser parser) {
            var connection = new Connection(_url);
            var template = _templateFactory.GetInstance(templateName);
            template.Authentication = _authentication;
            var requestBody = template.Render(data);
            var response = connection.Request("post", requestBody, null);
            return parser.Parse(response);
        }

    }
}