using Xunit.Abstractions;

namespace CSharpExamplesTest;

public class DateHelperTestFixture(ITestOutputHelper output)
{
    [Fact]
    public void Test_DateHelper()
    {
        var helper = new DateHelper();
        DateTime start = new(DateTime.Now.Year, 1, 1);
        DateTime end = new(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 11, 59, 59);
        var numberOfDays = helper.CalculateNumberOfDaysBetweenDates(start, end);
        output.WriteLine("Number of days between {0} and {1} is {2}", start, end, numberOfDays);
    }
}
