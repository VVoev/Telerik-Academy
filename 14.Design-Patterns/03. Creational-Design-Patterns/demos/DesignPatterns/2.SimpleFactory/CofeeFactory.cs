using System;

namespace SimpleFactory
{
    public class CofeeFactory
    {
        public Cofee GetCofee(CofeeType cofeeType)
        {
            switch (cofeeType)
            {
                case CofeeType.Capuchinno:
                    return new Cofee(CofeeType.Capuchinno,0, 150);
                case CofeeType.Double:
                    return new Cofee(CofeeType.Double,0, 300);
                case CofeeType.Regular:
                    return new Cofee(CofeeType.Regular,0, 100);
                default:
                    throw new ArgumentException();
            }
        }
    }
}