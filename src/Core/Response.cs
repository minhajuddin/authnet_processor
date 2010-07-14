namespace Authnet {
    public class Response : IResponse {

        public bool Success {
            get {
                return ResultCode == "Ok" ? true : false;
            }
        }

        public string Message { get; set; }
        public ParameterSet ParameterSet { get; set; }

        public string ResultCode { get; set; }
    }

    public interface IResponse {
        bool Success { get; }
        string Message { get; }
        ParameterSet ParameterSet { get; set; }
    }
}
