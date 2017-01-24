namespace Utilitiess
{
    using System.Collections.Generic;
    using System.Linq;
    public class MathUtilities
    {
        public int Sum(IEnumerable<int> numbers)
        {
            var sum = numbers.Sum(x=>x);
            return sum;
        }
    }
}
