# Enumeration Class

This project demonstrates a custom `Enumeration` abstract class that provides an alternative to traditional C# enums, offering more flexibility and allowing behavior to be encapsulated within each enumeration value.

## Key Features:
- Each enumeration value is represented by an instance of a class, allowing the association of additional behavior and properties.
- Implements common operations like:
  - **Equality checks** (`Equals` and `GetHashCode`)
  - **Comparison** (`IComparable`)
  - **Static methods to fetch values by**:
    - Integer value (`FromValue`)
    - Display name (`FromDisplayName`)
  - **Retrieving all enumeration values** (`GetAll`)

## Libraries
- [XUnit](https://github.com/xunit/xunit)