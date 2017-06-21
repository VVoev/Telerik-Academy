namespace List_Simple_Example
{
    using System;
    using System.Collections.Generic;

    public static class ListSimpleExample
    {
        public static void Main()
        {
            var list = new List<string> { "C#", "Java" };
            list.Add("SQL");
            list.Add("Python");
            foreach (string item in list)
            {
                Console.WriteLine(item);
            }

            // Result:
            //   C#
            //   Java
            //   SQL
            //   Python
        }
    }
}
