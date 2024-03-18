using Xunit.Abstractions;

namespace CSharp12ExamplesTest;

/// <summary>
/// Primary constructors can be applied to classes or to structs.
/// The constructors parameters are in scope throughout the entire class definition.
/// </summary>

struct Circle(double cx, double cy, double radius)
{
    public double Area()
    {
        return Math.PI * radius * 2;
    }
}


public class PrimaryConstructorsExamples(ITestOutputHelper output)
{
    [Fact]
    public void Can_calculate_distance_from_Circle_primary_constructor()
    {
        Circle c = new(5.0, 5.0, 10.0);
        var area = c.Area();
        const double expected = 62.831;
        output.WriteLine("Area {0} expected {1}", area, expected);
        Assert.True(Math.Abs(area - expected) < 0.1);
    }
}