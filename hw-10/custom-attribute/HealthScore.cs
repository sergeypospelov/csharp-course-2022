namespace custom_attribute;

[Custom("Joe", 2, "Class to work with health data.", "Arnold", "Bernard")]
public class HealthScore
{
    [Custom("Andrew", 3, "Method to collect health data.", "Sam", "Alex")]
    public static long CalcScoreData()
    {
        return 1;
    }

    public static long NoAtribute()
    {
        return 2;
    }
} 