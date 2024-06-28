using System.Reflection;

namespace BotTrade;

[AttributeUsage(AttributeTargets.Field)]
public sealed class ReflectableEnumAttribute : Attribute
{
    public Type ReflectableType { get; init; }
    public IEnumerable<Type> ArgTypes { get; init; }

    public ReflectableEnumAttribute(Type reflectableType, params Type[]? argTypes)
    {
        ReflectableType = reflectableType;
        ArgTypes = argTypes ?? [];
    }

    public ReflectableEnumAttribute(string typeName, params Type[]? argTypes)
    {
        ReflectableType = Type.GetType(typeName, true) ?? typeof(object);
        ArgTypes = argTypes ?? [];
    }

    public ReflectableEnumAttribute(string assemblyName, string typeName, params Type[]? argTypes)
    {
        var assembly = Assembly.Load(assemblyName);
        ReflectableType = assembly.GetType(typeName, true) ?? typeof(object);
        ArgTypes = argTypes ?? [];
    }
}

public static class ReflectableEnum
{
    public static T? Reflection<T>(this Enum value, params object?[] args) where T : class
    {
        var type = value.GetType();
        var fieldInfo = type.GetField(Enum.GetName(type, value) ?? string.Empty);
        var attributes = fieldInfo?.GetCustomAttributes(typeof(ReflectableEnumAttribute), false);

        if (attributes?.FirstOrDefault() is not ReflectableEnumAttribute attribute)
            return null;

        var constructor = attribute.ReflectableType.GetConstructor(attribute.ArgTypes.ToArray());
        return constructor?.Invoke(args) as T;
    }
}
