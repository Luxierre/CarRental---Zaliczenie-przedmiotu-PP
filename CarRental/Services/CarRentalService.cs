using CarRental.Domain;
using CarRental.Enums;
using CarRental.Repositories;

namespace CarRental.Services
{
    internal class CarRentalService
    {
        private ClientRepository clientRepository;
        private CarRepository carRepository;

        public CarRentalService()
        {
            clientRepository = new ClientRepository();
            carRepository = new CarRepository();
        }

        public string GetClientsView()
        {
            string result =
                @"LISTA KLIENTÓW:
---------------------------
Id | Imię i nazwisko | Data wydania prawa jazdy";

            clientRepository.Clients.ForEach(client => result += $"{client.Id} | {client.Name} | {client.DrivingLicenceDate.ToString("d")}\n");

            return result;
        }

        public string GetCarsView()
        {
            string result =
                @"LISTA SAMOCHODÓW:
---------------------------
Id | Model | Segment | Rodzaj paliwa | Cena za dobę";

            carRepository.Cars.ForEach(car => result += $"{car.Id} | {car.Model} | {car.FuelType} | {car.Price} PLN\n");

            return result;
        }



        public string GetPossibleSegments(long clientId)
        {
            String result = $"1. {Segment.mini}\n2. {Segment.kompakt}\n";
            Client client = clientRepository.Clients.First(c => c.Id == clientId);
            if(DateTime.Now.Year - client.DrivingLicenceDate.Year >= 4)
            {
                result += $"3. {Segment.premium}\n";
            }
            return result;
        }

        public string GetPossibleFuelTypes()
        {
            return $"1. {FuelType.benzyna}\n2. {FuelType.elektryczny}\n3. {FuelType.diesel}\n";
        }

        public string RentCar(long clientId, long segmentId, long fuelTypeId, long days)
        {
            Client client = clientRepository.Clients.First(c => c.Id == clientId);
            Boolean newDriver = DateTime.Now.Year - client.DrivingLicenceDate.Year < 4;
            Segment segment = segmentId switch
            {
                1 => Segment.mini,
                2 => Segment.kompakt,
                _ => Segment.premium
            };
            FuelType fuelType = fuelTypeId switch
            {
                1 => FuelType.benzyna,
                2 => FuelType.elektryczny,
                _ => FuelType.diesel
            };


            Car car = carRepository.Cars.First(c => c.Segment == segment && c.FuelType == fuelType && c.Status == Status.dostępny);
            Decimal finalPrice = newDriver ? car.Price * days * 1.2m : car.Price * days;
            days = days > 7 && days <= 30 ? days + 1 : days > 30 ? days + 3 : days;

            return @$"UMOWA WYNAJMU POJAZDU
DATA ZAWARCIA: {DateTime.Now.ToString("d")}

-----------------------------------
WYNAJMUJĄCY: {client.Name}

RODZAJ POJAZDU: {car.Model}

RODZAJ PALIWA: {car.FuelType}

SEGMENT: {car.Segment}

-----------------------------------

DATA ZWROTU POJAZDU: {DateTime.Now.AddDays(days).ToString("d")}

OPŁATA: {finalPrice} PLN";
        }
    }
}
