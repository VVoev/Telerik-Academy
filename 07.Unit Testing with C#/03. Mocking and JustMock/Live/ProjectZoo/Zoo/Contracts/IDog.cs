using Zoo.Enumerations;

namespace Zoo.Contracts
{
   public interface IDog
    {
        DogBreed Breed { get; }

        bool IsitPuppy { get; }

        bool CanByte { get; set; }
    }
}
