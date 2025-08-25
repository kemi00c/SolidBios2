using System.Text.Json;

namespace Data;

public class JsonHandler : IJsonHandler
{
    private string _filepath;

    public JsonHandler(string filepath)
    {
        _filepath = filepath;
    }
    
    public void Save(Dictionary<string, object> data)
    {
        var jsonData=JsonSerializer.Serialize(data);
        File.WriteAllText(_filepath, jsonData);
    }

    public Dictionary<string, object>? Load()
    {
        var jsonString = File.ReadAllText(_filepath);
        return JsonSerializer.Deserialize<Dictionary<string, object>>(jsonString);
    }
}