namespace _5.Builder.Builders
{
   public abstract class VehichleBuilder
    {
        public Vehichle Vehichkle { get; set; }

        public abstract void BuildFrame();

        public abstract void BuildWheels();

        public abstract void BuildEngine();

        public abstract void BuildDoors();

    }
}
