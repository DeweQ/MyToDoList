namespace MyToDoList.Infrastructure;

public static class ResourceManager
{
    static Dictionary<string, string> filePaths = new()
    {{"ToDoLists","Resources/ToDoLists.json"}};

    public static List<string> Keys { get => filePaths.Keys.ToList(); }

    public static string ReadFile(string key)
    {
        if (!CheckKey(key))
            throw new KeyNotFoundException($"There was no key '{key}' found in ResourceManager dictionary");

        var path = Directory.GetCurrentDirectory();
        var fullFileName = $"{path}/{filePaths[key]}";
        var output = "";
        if (!File.Exists(fullFileName))
            Directory.CreateDirectory("Resources");
        using (var stream = new FileStream(fullFileName, FileMode.OpenOrCreate))
        using (var sr = new StreamReader(stream))
            output = sr.ReadToEnd();
        return output;
    }

    public static void WriteFile(string key, string content)
    {
        if (!CheckKey(key))
            throw new KeyNotFoundException($"There was no key '{key}' found in ResourceManager dictionary");

        var path = Directory.GetCurrentDirectory();
        var fullFileName = $"{path}/{filePaths[key]}";
        using (var stream = new FileStream(fullFileName, FileMode.OpenOrCreate))
        using (var sw = new StreamWriter(stream))
            sw.WriteLine(content);
    }

    private static string GetFullName(string fileName) =>
        $"{Directory.GetCurrentDirectory()}/{fileName}";

    private static bool CheckKey(string key)
    {
        return filePaths.ContainsKey(key);
    }
}
