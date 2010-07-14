namespace Authnet {
    public interface IParameterSet {
        IParameterSet this[string index] { get; set; }
        string ToString();
    }
}