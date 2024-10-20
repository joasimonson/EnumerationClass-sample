namespace EnumerationClassSample.Tests;

public class EnumerationTests
{
    public class ExampleType : Enumeration
    {
        public static readonly ExampleType Unit = new(0, "Unit Tests");
        public static readonly ExampleType Integration = new(1, "Integration Tests");
        public static readonly ExampleType E2E = new(2, "End to End Tests");

        private ExampleType(int value, string name) : base(value, name) { }
    }

    [Fact]
    public void ShouldHaveCorrectName()
    {
        Assert.Equal("Unit Tests", ExampleType.Unit.Name);
    }

    [Fact]
    public void EqualityShouldWork()
    {
        Assert.Equal(ExampleType.Unit, ExampleType.Unit);
        Assert.NotEqual(ExampleType.Unit, ExampleType.Integration);
    }

    [Fact]
    public void GetAll_ShouldReturnAllValues()
    {
        var allTypes = Enumeration.GetAll<ExampleType>().ToList();
        Assert.Equal(3, allTypes.Count);
        Assert.Contains(ExampleType.Unit, allTypes);
        Assert.Contains(ExampleType.Integration, allTypes);
        Assert.Contains(ExampleType.E2E, allTypes);
    }

    [Fact]
    public void FromValue_ShouldReturnCorrectInstance()
    {
        var result = Enumeration.FromValue<ExampleType>(1);
        Assert.Equal(ExampleType.Integration, result);
    }

    [Fact]
    public void FromValue_ShouldThrowOnInvalidValue()
    {
        var ex = Assert.Throws<ArgumentException>(() => Enumeration.FromValue<ExampleType>(99));
        Assert.Equal("'99' is not a valid value for ExampleType", ex.Message);
    }

    [Fact]
    public void FromName_ShouldReturnCorrectInstance()
    {
        var result = Enumeration.FromName<ExampleType>("End to End Tests");
        Assert.Equal(ExampleType.E2E, result);
    }

    [Fact]
    public void FromName_ShouldThrowOnInvalidName()
    {
        var ex = Assert.Throws<ArgumentException>(() => Enumeration.FromName<ExampleType>("Invalid Name"));
        Assert.Equal("'Invalid Name' is not a valid name for ExampleType", ex.Message);
    }

    [Fact]
    public void CompareTo_ShouldWorkCorrectly()
    {
        Assert.True(ExampleType.Unit.CompareTo(ExampleType.Integration) < 0);
        Assert.True(ExampleType.E2E.CompareTo(ExampleType.Unit) > 0);
    }

    [Fact]
    public void CompareTo_ShouldHandleNulls()
    {
        var result = ExampleType.Unit.CompareTo(null);
        Assert.Equal(1, result);
    }

    [Fact]
    public void Equals_ShouldReturnTrueForSameReference()
    {
        var unitTest1 = ExampleType.Unit;
        var unitTest2 = ExampleType.Unit;

        Assert.True(unitTest1.Equals(unitTest2));
    }

    [Fact]
    public void Equals_ShouldReturnFalseForDifferentValues()
    {
        var unitTest = ExampleType.Unit;
        var integrationTest = ExampleType.Integration;

        Assert.False(unitTest.Equals(integrationTest));
    }

    [Fact]
    public void Equals_ShouldReturnFalseForNullComparison()
    {
        var unitTest = ExampleType.Unit;

        Assert.False(unitTest.Equals(null));
    }

    [Fact]
    public void Equals_ShouldReturnFalseForDifferentType()
    {
        var unitTest = ExampleType.Unit;

        Assert.False(unitTest.Equals(new object()));
    }

    [Fact]
    public void GetHashCode_ShouldReturnSameHashCodeForEqualObjects()
    {
        var unitTest1 = ExampleType.Unit;
        var unitTest2 = ExampleType.Unit;

        Assert.Equal(unitTest1.GetHashCode(), unitTest2.GetHashCode());
    }

    [Fact]
    public void GetHashCode_ShouldReturnDifferentHashCodesForDifferentValues()
    {
        var unitTest = ExampleType.Unit;
        var integrationTest = ExampleType.Integration;

        Assert.NotEqual(unitTest.GetHashCode(), integrationTest.GetHashCode());
    }
}
