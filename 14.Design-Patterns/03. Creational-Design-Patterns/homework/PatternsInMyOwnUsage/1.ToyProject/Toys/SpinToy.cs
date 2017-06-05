namespace _1.ToyProject.Factories
{
    public class SpinToy
    {
        protected string name;

        public SpinToy(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return $@"i am {this.name} the best {this.GetType().Name}";
        }
    }
}