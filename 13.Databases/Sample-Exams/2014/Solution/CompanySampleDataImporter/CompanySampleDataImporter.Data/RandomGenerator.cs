using System;
using System.Text;

namespace CompanySampleDataImporter.Data
{
    public static class RandomGenerator
    {
        private static Random random = new Random();
        private const string alfabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        public static int GetRandomNumber(int min = 0 , int max = int.MaxValue / 2)
        {
            return random.Next(min, max+1);
        }

        public static string GetRandomString(int minLenght = 0 , int maxLenght = int.MaxValue / 2)
        {
            var len = random.Next(minLenght, maxLenght);

            var sb = new StringBuilder();
            for (int i = 0; i < len; i++)
            {
                sb.Append(alfabet[random.Next(0, alfabet.Length - 1)]);
            }

            return sb.ToString();
        }

        public static DateTime GetRandomDate(DateTime? after = null, DateTime? before = null)
        {
            var minDate = after ?? new DateTime(1990, 1, 1, 0, 0, 0);
            var maxDate = before ?? new DateTime(2050, 1, 1, 0, 0, 0);

            var seconds = GetRandomNumber(minDate.Second,maxDate.Second);
            var minutes = GetRandomNumber(minDate.Minute,maxDate.Minute);
            var hours = GetRandomNumber(minDate.Hour,maxDate.Hour);
            var days = GetRandomNumber(minDate.Day,maxDate.Day);
            var months = GetRandomNumber(minDate.Month,maxDate.Month);
            var years = GetRandomNumber(minDate.Year,maxDate.Year);

            return new DateTime(years,months,days,hours,minutes,seconds);
        }
    }
}
