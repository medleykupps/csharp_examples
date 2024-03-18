using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace CSharpExamplesTest;

public class PatternMatchingExamples(ITestOutputHelper output)
{
    [Fact]
    public void Pattern_matching_for_null_checks()
    {
        int? maybe = 12;

        Assert.True(maybe is not null);
    }

    [Fact]
    public void Pattern_matching_with_declaration()
    {
        PatternMatchingHelper helper = new();

        var result = helper.FormatNumber(12);
        output.WriteLine(result);

        result = helper.FormatNumber(null);
        output.WriteLine(result);
    }

    [Fact]
    public void Pattern_matching_using_switch_keyword()
    {
        PatternMatchingHelper helper = new();

        var result = helper.ExecuteOperation(Operation.Addition, 10.0, 5.0);
        Assert.Equal(15.0, result);

        result = helper.ExecuteOperation(Operation.Subtraction, 20.0, 7.0);
        Assert.Equal(13.0, result);

        // Not implemented operation produces a 0 result instead
        result = helper.ExecuteOperation(Operation.Division, 100.0, 5.0);
        Assert.Equal(0.0, result);
    }

    [Fact]
    public void Pattern_matching_using_relation_patterns()
    {
        string temperatureDescription(double temperature)
        {
            // The `switch` expression resolves to a specific type
            string result = temperature switch
            {
                < 2.0 => "Freezing",
                < 15.0 => "Cold",
                (> 28.0) and (< 48.0) => "Hot",
                >= 48.0 => "Damn Hot!",
                _ => "Dunno"
            };

            return result;
        }

        Assert.Equal("Freezing", temperatureDescription(-1.0));
        Assert.Equal("Cold", temperatureDescription(5.0));
        Assert.Equal("Hot", temperatureDescription(30.0));
        Assert.Equal("Damn Hot!", temperatureDescription(50.0));
        Assert.Equal("Dunno", temperatureDescription(22.0));
    }


}

class PatternMatchingHelper
{
    public string FormatNumber(int? i)
    {
        if (i is int num)
        {
            return $"The number is {num}";
        }
        else
        {
            return "No number";
        }
    }

    public double ExecuteOperation(Operation operation, double argument1, double argument2)
    {
        return operation switch
        {
            Operation.Addition => argument1 + argument2,
            Operation.Subtraction => argument1 - argument2,
            _ => 0 // Produces a compiler warning if this is missing
        };
    }
}

enum Operation
{
    Addition,
    Subtraction,
    Division,
}

