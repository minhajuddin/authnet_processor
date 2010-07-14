using Authnet.Model;

namespace Authnet.Templating {
    public interface ITemplateView {
        Authentication Authentication { get; set; }
        object Model { get; set; }
        string Render(object data);
    }
}