namespace Cron.Models;

public class CronParser
{
    public static CronExpression Parse(string expression)
    {
        var fields = expression.Split(" ");
        
        if (fields.Length != 5) throw new ArgumentException("Invalid cron expression");
        
        return new CronExpression
        {
            Minutes = ExtractFields(fields[0], 0, 59),
            Hours = ExtractFields(fields[1], 0, 23),
            DaysOfMonth = ExtractFields(fields[2], 1, 31),
            Months = ExtractFields(fields[3], 1, 12),
            DaysOfWeek = ExtractFields(fields[4], 0, 6)
        };
    }
    
    private static List<int> ExtractFields(string field, int min, int max)
    {
        var fieldValues = new HashSet<int>();

        if (field == "*")
        {
            return Enumerable.Range(min, max - min + 1).ToList();
        }

        var sections = field.Split(',');

        foreach (var section in sections)
        {
            if (section.Contains('/'))
            {
                AddSteppedRange(fieldValues, section, min, max);
            }
            else if (section.Contains('-'))
            {
                AddRange(fieldValues, section);
            }
            else
            {
                fieldValues.Add(int.Parse(section));
            }
        }

        return fieldValues.OrderBy(n => n).ToList();
    }

    private static void AddSteppedRange(HashSet<int> fieldValues, string section, int min, int max)
    {
        var parts = section.Split('/');
        var rangePart = parts[0];
        var step = int.Parse(parts[1]);

        int start = min, end = max;

        if (rangePart.Contains('-'))
        {
            var range = rangePart.Split('-');
            start = int.Parse(range[0]);
            end = int.Parse(range[1]);
        }
        else if (rangePart != "*")
        {
            start = int.Parse(rangePart);
        }

        for (var i = start; i <= end; i += step)
        {
            fieldValues.Add(i);
        }
    }

    private static void AddRange(HashSet<int> fieldValues, string section)
    {
        var parts = section.Split('-');
        var start = int.Parse(parts[0]);
        var end = int.Parse(parts[1]);

        for (var i = start; i <= end; i++)
        {
            fieldValues.Add(i);
        }
    }
}
    