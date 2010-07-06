using System;
namespace Tests {
    public interface IParameterSet {
        IParameterSet this[string index] { get; set; }
        string ToString();
    }
}
