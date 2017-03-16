namespace StatisticProblem
{
    using StatisticProblem.Extensions;

    public class Statistic
    {
        public static void Main(string[] args)
        {
            var account = new[] { 6, 132.5, -30, 180, 23500 };
            account.PrintStatistics();
        }
    }
}
