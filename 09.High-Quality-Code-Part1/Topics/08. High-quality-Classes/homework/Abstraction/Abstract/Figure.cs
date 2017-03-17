using System.Text;
using Abstraction.Contracts;

namespace Abstraction.Abstract
{
    public abstract class Figure : IFigure
    {
        protected Figure()
        {
        }

        public abstract double CalcPerimeter();

        public abstract double CalcSurface();

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(string.Format($@"I am {this.GetType().Name} with perimeter {CalcPerimeter():f2} and with surcafe {CalcSurface():f2}"));
            return sb.ToString();
        }
    }
}
