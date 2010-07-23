namespace Authnet {
    public class Response : IResponse {

        public Response() {
            Params = new Hash();
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public string Code { get; set; }
        public Hash Params { get; set; }


    }

    public interface IResponse {
        bool Success { get; }
        string Message { get; }
        string Code { get; }
        Hash Params { get; set; }
    }
}
