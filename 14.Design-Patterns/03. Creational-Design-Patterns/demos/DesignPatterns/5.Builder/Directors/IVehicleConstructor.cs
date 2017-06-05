using _5.Builder.Builders;

namespace _5.Builder.Directors
{
    public interface IVehicleConstructor
    {
        void Construct(VehichleBuilder builder);
    }
}