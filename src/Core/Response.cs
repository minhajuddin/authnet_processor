using System;

namespace Authnet {
    public class Response : IResponse {

        public bool Success {
            get {
                return ResultCode == "Ok" ? true : false;
            }
            set {
                throw new System.NotImplementedException();
            }
        }

        //public string Message {
        //    get {

        //    }
        //    set {

        //    }
        //}

        public string Message { get; set; }
        public ParameterSet ParameterSet { get; set; }

        //public ParameterSet ParameterSet {
        //    get { throw new NotImplementedException(); }
        //    set { throw new NotImplementedException(); }
        //}

        public string ResultCode { get; set; }
    }

    public interface IResponse {
        bool Success { get; set; }
        string Message { get; set; }
        ParameterSet ParameterSet { get; set; }
    }
}
