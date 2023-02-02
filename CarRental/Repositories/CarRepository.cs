using CarRental.Domain;
using CarRental.Enums;

namespace CarRental.Repositories
{
    internal class CarRepository
    {
        public List<Car> Cars { get; private set; }

        public CarRepository()
        {
            Cars = new List<Car>
            {
                new Car{ Id = 1, Model = "Škoda Citigo", Segment = Segment.mini, FuelType = FuelType.benzyna, Price = 70, Status = Status.dostępny },
                new Car{ Id = 1, Model = "Toyota Aygo", Segment = Segment.mini, FuelType = FuelType.benzyna, Price = 90, Status = Status.dostępny },
                new Car{ Id = 1, Model = "Fiat 500", Segment = Segment.mini, FuelType = FuelType.elektryczny, Price = 110, Status = Status.dostępny },
                new Car{ Id = 1, Model = "Ford Focus", Segment = Segment.kompakt, FuelType = FuelType.diesel, Price = 160, Status = Status.dostępny },
                new Car{ Id = 1, Model = "Kia Ceed", Segment = Segment.kompakt, FuelType = FuelType.benzyna, Price = 150, Status = Status.dostępny },
                new Car{ Id = 1, Model = "Volkswagen Golf", Segment = Segment.kompakt, FuelType = FuelType.benzyna, Price = 160, Status = Status.dostępny },
                new Car{ Id = 1, Model = "Hyundai Kona Electric", Segment = Segment.kompakt, FuelType = FuelType.elektryczny, Price = 180, Status = Status.dostępny },
                new Car{ Id = 1, Model = "Audi A6 Allroad", Segment = Segment.premium, FuelType = FuelType.diesel, Price = 290, Status = Status.dostępny },
                new Car{ Id = 1, Model = "Mercedes E270 AMG", Segment = Segment.premium, FuelType = FuelType.benzyna, Price = 320, Status = Status.dostępny },
                new Car{ Id = 1, Model = "Tesla Model S", Segment = Segment.premium, FuelType = FuelType.elektryczny, Price = 350, Status = Status.dostępny }
            };
        }

    }
}
