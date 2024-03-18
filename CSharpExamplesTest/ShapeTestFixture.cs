using Xunit.Abstractions;

namespace CSharpExamplesTest;

enum ShapeType
{
    Circle,
}

record Shape(ShapeType Type)
{
    public double Area() => 0;
}

record Circle(double CX, double CY, double Radius) : Shape(ShapeType.Circle)
{
}

class ShapeClass(ShapeType type)
{
    public ShapeType Type { get; init; } = type;
}

public class ShapeTestFixture(ITestOutputHelper output)
{
    [Fact]
    public void Test_Shape()
    {
        Shape s = new(ShapeType.Circle);
        output.WriteLine("Shape ToString {0}", s.ToString());
    }

    [Fact]
    public void When_Shape_has_same_property_values_They_are_equal()
    {
        Shape s1 = new(ShapeType.Circle);
        Shape s2 = new(ShapeType.Circle);
        Assert.Equal(s1, s2);
    }

    [Fact]
    public void When_ShapeClass_has_same_property_values_They_are_not_equal()
    {
        // Class use reference equality and not value equality like a record does
        ShapeClass s1 = new(ShapeType.Circle);
        ShapeClass s2 = new(ShapeType.Circle);
        Assert.NotEqual(s1, s2);
    }
}

public class CircleTestFixture(ITestOutputHelper output)
{
    [Fact]
    public void Circle_record_can_use_with_keyword()
    {
        Circle c = new(5.0, 5.0, 12.0);
        output.WriteLine("Original circle {0}", c);

        Circle c2 = c with { Radius = 24.0 };
        output.WriteLine("Modified circle {0}", c2);
    }
}
