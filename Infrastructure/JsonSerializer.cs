namespace MyToDoList.Infrastructure;

public static class JsonSerializer
{
    private static ISerializationBinder _binder = new TypeNameSerializationBinder();

    public static void SetSerializationBinder(ISerializationBinder binder)
    {
        _binder = binder;
    }

    public static string Serialize<T>(T obj)
    {
        return JsonConvert.SerializeObject(obj, Formatting.Indented,
            new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                SerializationBinder = _binder
            });
    }

    public static List<IToDoList>? DeserealizeToDoLists(string json)
    {
        return JsonConvert.DeserializeObject<List<IToDoList>>(json,
            new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                SerializationBinder = _binder
            });
    }
}
