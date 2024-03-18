using Xunit.Abstractions;

namespace CSharp12ExamplesTest;

public class CollectionExpressionExamples(ITestOutputHelper output)
{
    [Fact]
    public void Define_an_int_array()
    {
        // The original way to define an array of ints
        var i1 = new int[] { 1, 2, 3 };

        // The C#12 way using collection expressions
        int[] i2 = [1, 2, 3];
    }

    [Fact]
    public void Define_a_list()
    {
        // Originally...
        var l1 = new List<int> { 1, 2, 3 };
        // Using collection expressions...
        List<int> l2 = [1, 2, 3];
    }

    [Fact]
    public void Using_the_spread_operator()
    {
        int[] i1 = [1, 2, 3];
        int[] i2 = [4, 5, 6];

        int[] joined = [..i1, ..i2];

        output.WriteLine("Joined array is {0}", string.Join(",", joined));
    }
}
