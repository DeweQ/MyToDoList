namespace MyToDoList.Infrastructure;

class TypeNameSerializationBinder : ISerializationBinder
{
    public void BindToName(Type serializedType,
                           out string? assemblyName,
                           out string? typeName)
    {
        assemblyName = null;
        typeName = serializedType.AssemblyQualifiedName;
    }

    public Type? BindToType(string assemblyName, string typeName)
    {
        var resolvedTypeName = string.Format("{0}, {1}", typeName, assemblyName);
        return Type.GetType(resolvedTypeName, true);
    }
}
