using Cron.Models;

namespace Cron;

class Program
{
    private static async Task Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide a cron expression");
            return;
        }
        
        
        var cron = CronParser.Parse(args[0]);
        Console.WriteLine($"Parsed Cron -> Minutes: [{string.Join(",", cron.Minutes)}], Hours: [{string.Join(",", cron.Hours)}], DaysOfMonth: [{string.Join(",", cron.DaysOfMonth)}], Months: [{string.Join(",", cron.Months)}], DaysOfWeek: [{string.Join(",", cron.DaysOfWeek)}]");
        
        var now = DateTime.Now;
        
        var cronSchedular = new CronScheduler();
        var nextTime = cronSchedular.GetNextExecutionTime(cron, now);
        
        Console.WriteLine($"🌼 Next execution call --------> {nextTime} And now is --------------------->  {now}");
    }
}