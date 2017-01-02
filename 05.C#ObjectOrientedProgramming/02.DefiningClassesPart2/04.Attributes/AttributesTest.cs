namespace _04.Attributes
{
    using System;

    [Version("6","66")]
    public class AttributesTest
    {
        static void Main()
        {
            Type type = typeof(AttributesTest);
            object[] attributes = type.GetCustomAttributes(false);
            foreach (VersionAttribute attribute in attributes)
            {
                Console.WriteLine(attribute.ToString());
            }
        }
    }
}
