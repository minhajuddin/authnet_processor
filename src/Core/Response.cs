namespace Authnet {
    public class Response : IResponse {

        public Response() {
            Params = new Hash();
        }
        public bool Success {
            get {
                return ResultCode == "Ok" ? true : false;
            }
        }

        public string Message { get; set; }
        public Hash Params { get; set; }

        public string ResultCode { get; set; }
    }

    public interface IResponse {
        bool Success { get; }
        string Message { get; }
        Hash Params { get; set; }
    }
}
