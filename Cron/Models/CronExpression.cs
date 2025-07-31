namespace Cron.Models;

public class CronExpression
{
    public required List<int> Minutes;
    public required List<int> Hours;
    public required List<int> DaysOfMonth;
    public required List<int> Months;
    public required List<int> DaysOfWeek;
}