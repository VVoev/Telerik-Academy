using FurnitureManufacturer.Models;

namespace FurnitureManufacturer.Interfaces
{
    public interface IFurniture
    {
        string Model { get; }

        MaterialType Material { get; }

        decimal Price { get; set; }

        decimal Height { get; }
    }
}
