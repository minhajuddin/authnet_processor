namespace Authnet.Serializers {
    public interface ISerializer {
        Response Serialize(string rawXml);
    }
}