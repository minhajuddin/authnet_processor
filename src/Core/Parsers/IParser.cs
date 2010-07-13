namespace Authnet.Parsers {
    public interface IParser {
        Response Parse(string rawXml);
    }
}