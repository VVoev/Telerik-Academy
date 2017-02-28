namespace Code.Formatting.StyleCop.NotCool
{
    using System.Threading;

    public enum MonkeyType
    {
        PygmyMarmoset,
        SpiderMonkey,
        HowlerMonkey,
        SilverbackGorrila
    }

    public static class DataGenerator
    {
        private static int currentId;

        public static int GenerateId()
        {
            return Interlocked.Increment(ref currentId);
        }
    }

    public class Monkey
    {
        public Monkey(string name, MonkeyType type)
        {
            this.Id = DataGenerator.GenerateId();
            this.Name = name;
            this.Type = type;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public MonkeyType Type { get; set; }

        public void MonkeyDance()
        {
            // Dancing
            // to the rhythm of the night
        }
    }
}
