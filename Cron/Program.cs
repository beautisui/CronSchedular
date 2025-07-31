using Cron.Models;

namespace Cron;

class Program
{
    public async Task Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide a cron expression");
            return;
        }
        
        var cron = CronParser.Parse(args[0]);
        Console.WriteLine($"Parsed Cron -> Minutes: [{string.Join(",", cron.Minutes)}], Hours: [{string.Join(",", cron.Hours)}], DaysOfMonth: [{string.Join(",", cron.DaysOfMonth)}], Months: [{string.Join(",", cron.Months)}], DaysOfWeek: [{string.Join(",", cron.DaysOfWeek)}]");
        
        var schedular = new CronScheduler();
        await RunSchedulerLoop(schedular, cron);
    }


    private async Task RunSchedulerLoop(CronScheduler scheduler, CronExpression cron)
    {
        while (true)
        {
            var now = DateTime.Now;
            var nextTime = scheduler.GetNextExecutionTime(cron, now);
            var delay = nextTime - now;

            Console.WriteLine($" Next Execution: {nextTime} | Now: {now} | Delay: {delay}");

            if (delay.TotalMilliseconds > 0) await Task.Delay(delay);
            
            Console.WriteLine(" Time reached! Executing your command...");
            scheduler.Execute();
        }
    }
}