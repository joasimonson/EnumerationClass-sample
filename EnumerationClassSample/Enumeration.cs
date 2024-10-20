using System.Reflection;

namespace EnumerationClassSample;

public abstract class Enumeration(int value, string Name) : IComparable
{
    public int Value { get; } = value;
    public string Name { get; } = Name;

    public override string ToString() => Name;

    public static IEnumerable<T> GetAll<T>() where T : Enumeration
        => typeof(T)
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
            .Select(f => f.GetValue(null))
            .Cast<T>();

    public override bool Equals(object? obj)
    {
        if (obj is not Enumeration otherValue)
            return false;

        return GetType().Equals(obj.GetType()) && Value.Equals(otherValue.Value);
    }

    public override int GetHashCode() => Value.GetHashCode();

    public int CompareTo(object? other)
    {
        if (other is not Enumeration obj)
            return 1;

        return Value.CompareTo(obj.Value);
    }

    public static T FromValue<T>(int value) where T : Enumeration =>
        GetAll<T>().FirstOrDefault(e => e.Value == value) ??
        throw new ArgumentException($"'{value}' is not a valid value for {typeof(T).Name}");

    public static T FromName<T>(string name) where T : Enumeration =>
        GetAll<T>().FirstOrDefault(e => e.Name == name) ??
        throw new ArgumentException($"'{name}' is not a valid name for {typeof(T).Name}");
}