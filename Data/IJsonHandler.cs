namespace Data;

public interface IJsonHandler
{
    void Save(Dictionary<string, object> data);
    Dictionary<string, object>? Load();
}