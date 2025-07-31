
namespace Cron.Models;
public class CronScheduler
{
    // public static async Task Execute(CronExpression cron)
    // {
    //     var now = DateTime.Now;
    //     var next = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0).AddMinutes(1);
    //     
    //     // var nextTime = GetNextTime(cron, now);
    //
    //     Console.WriteLine($"Executing task at {now}");
    //     
    //     if (
    //         cron.Minutes.Contains(now.Minute) &&
    //         cron.Hours.Contains(now.Hour) &&
    //         cron.DaysOfMonth.Contains(now.Day) &&
    //         cron.Months.Contains(now.Month) &&
    //         cron.DaysOfWeek.Contains((int)now.DayOfWeek)
    //     )
    //     {
    //         Console.WriteLine($"✅ Task executed at {now}");
    //     }
    //
    //     Console.WriteLine("then here>>>>>>>>>>>>>>>>>>>>>>>>");
    //     // var next = now.AddMinutes(1);
    //     var delayTime = next - DateTime.Now;
    //
    //     Console.WriteLine($"now: {now}");
    //     Console.WriteLine($"Next execution call: {next}");
    //     Console.WriteLine($"Delay: {delayTime}"); 
    //     
    //     await Task.Delay(delayTime);
    //     await Execute(cron);
    // }

    // private bool Matches(DateTime dt, CronExpression cron)
    // {
    //     return cron.Minutes.Contains(dt.Minute) &&
    //            cron.Hours.Contains(dt.Hour) &&
    //            cron.DaysOfMonth.Contains(dt.Day) &&
    //            cron.Months.Contains(dt.Month) &&
    //            cron.DaysOfWeek.Contains((int)dt.DayOfWeek);
    // }

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

            if (!cron.Minutes.Contains(next.Minute))
            {
                next = next.AddMinutes(1);
                continue;
            }

            return next;
        }
    }


}