using Authnet.Templating;

namespace Tests {
    static class TestHelper {

        internal static TemplateFactory TemplateFactory {
            get {
                return new TemplateFactory(ObjectMother.TemplateDirectory);
            }
        }

        internal static TemplateFactory TestTemplateFactory {
            get {
                return new TemplateFactory(ObjectMother.TestDirectory);
            }
        }

    }
}
