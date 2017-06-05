using _5.Builder.Builders;

namespace _5.Builder.Directors
{
    public class VehicleConstructor : IVehicleConstructor
    {
        public void Construct(VehichleBuilder builder)
        {
            builder.BuildFrame();
            builder.BuildEngine();
            builder.BuildWheels();
            builder.BuildDoors();
        }
    }
}
