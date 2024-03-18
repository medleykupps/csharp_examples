namespace CSharpExamplesTest;

class DateHelper
{
    public int CalculateNumberOfDaysBetweenDates(DateTime start, DateTime end)
    {
        return DateTime.Now.Subtract(start).Days;
    }
}
