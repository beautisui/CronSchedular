namespace Cron.Models;

public class CronScheduler
{
    public DateTime GetNextExecutionTime(CronExpression cron, DateTime fromTime)
    {
        var next = new DateTime(fromTime.Year, fromTime.Month, fromTime.Day, fromTime.Hour, fromTime.Minute, 0).AddMinutes(1);

        while (true)
        {
            if (!cron.Months.Contains(next.Month))
            {
                next = next.AddMonths(1);
                next = new DateTime(next.Year, next.Month, 1, 0, 0, 0);
                continue;
            }

            if (!cron.DaysOfMonth.Contains(next.Day) || !cron.DaysOfWeek.Contains((int)next.DayOfWeek))
            {
                next = next.AddDays(1);
                next = new DateTime(next.Year, next.Month, next.Day, 0, 0, 0);
                continue;
            }

            if (!cron.Hours.Contains(next.Hour))
            {
                next = next.AddHours(1);
                next = new DateTime(next.Year, next.Month, next.Day, next.Hour, 0, 0);
                continue;
            }

            if (cron.Minutes.Contains(next.Minute)) return next;
            
            next = next.AddMinutes(1);
        }
    }

    public void Execute()
    {
        Console.WriteLine("✅ Executing the command...");
    }
}