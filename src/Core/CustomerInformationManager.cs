using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Authnet.Model;
using Authnet.Net;
using Authnet.Templating;

namespace Authnet.Core {
    public class CustomerInformationManager : ICustomerInformationManager {

        string _url = "https://apitest.authorize.net/xml/v1/request.api";
        TemplateFactory _templateFactory;
        Authentication _authentication;

        public CustomerInformationManager(TemplateFactory templateFactory, Authentication authentication) {
            _templateFactory = templateFactory;
            _authentication = authentication;
        }

        public long[] GetCustomerProfileIds() {
            var connection = new Connection(_url);

            var template = _templateFactory.GetInstance("getCustomerProfileIds.spark");

            template.Authentication = _authentication;
            var response = connection.Request("post", template.Render(null), null);
            //Console.WriteLine(response);
            return new long[] { };
        }
    }

    public interface ICustomerInformationManager {
    }
}
