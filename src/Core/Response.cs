namespace Authnet {
    public class Response : IResponse {

        public bool Success {
            get {
                throw new System.NotImplementedException();
            }
            set {
                throw new System.NotImplementedException();
            }
        }

        public string Message {
            get {
                throw new System.NotImplementedException();
            }
            set {
                throw new System.NotImplementedException();
            }
        }

    }

    public interface IResponse {
        bool Success { get; set; }
        string Message { get; set; }
    }
}
