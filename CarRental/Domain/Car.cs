using CarRental.Enums;

namespace CarRental.Domain
{
    internal class Car
    {
        public long Id { get; set; }
        public string Model { get; set; }
        public Segment Segment { get; set; }
        public FuelType FuelType { get; set; }
        public Decimal Price { get; set; }
        public Status Status { get; set; }

    }
}
