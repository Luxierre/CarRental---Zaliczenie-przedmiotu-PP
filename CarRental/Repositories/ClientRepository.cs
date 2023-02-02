using CarRental.Domain;

namespace CarRental.Repositories
{
    internal class ClientRepository
    {
        public List<Client> Clients { get; private set; }

        public ClientRepository()
        {
            Clients = new List<Client>
            {
                new Client{ Id = 1, Name = "Jan Nowak", DrivingLicenceDate = new DateTime(2021,03,04) },
                new Client{ Id = 2, Name = "Agnieszka Kowalska", DrivingLicenceDate = new DateTime(1999,01,15) },
                new Client{ Id = 3, Name = "Pan Robert Lewandowski", DrivingLicenceDate = new DateTime(2010,12,18) },
                new Client{ Id = 4, Name = "Zofia Plucińska", DrivingLicenceDate = new DateTime(2020,04,29) },
                new Client{ Id = 5, Name = "Grzegorz Braun", DrivingLicenceDate = new DateTime(2015,07,12) }
            };
        }
    }
}
