namespace _2.Composite
{
    public abstract class PersonComponent
    {
        protected PersonComponent(string name)
        {
            this.Name = name;
        }
        public abstract void Display(int deapth);

        protected string Name { get; set; }
    }
}
