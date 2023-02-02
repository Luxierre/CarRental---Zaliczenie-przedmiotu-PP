﻿using CarRental.Services;

namespace CarRental.Controllers
{
    internal class CarRentalController
    {

        private CarRentalService carRentalService;

        public CarRentalController()
        {
            carRentalService = new CarRentalService();
        }

        public void MainMenu()
        {
            MainMenuOptions();
            ReadMainMenuOptions();
        }

        private void MainMenuOptions()
        {
            Console.WriteLine(@"
WYBIERZ OPCJĘ:
    1 => LISTA KLIENTÓW I SAMOCHODÓW
    2 => WYPOŻYCZENIE SAMOCHODU
    3 => ZAKOŃCZ PROGRAM
WYBIERZ 1,2 LUB 3
");
        }

        private void ReadMainMenuOptions()
        {
            try
            {
                int option = Convert.ToInt32(Console.ReadLine());
                string result = option switch
                {
                    1 => GetClientsAndCarsView(),
                    2 => RentCarClientMenu(),
                    3 => "",
                    _ => "Incorrect menu number.\n"
                };

                Console.WriteLine(result);
                if(!String.IsNullOrEmpty(result)) MainMenu();
            }
            catch (Exception)
            {
                Console.WriteLine("Choose option is not number from menu.\n");
                MainMenu();
            }
        }

        public string RentCarClientMenu()
        {
            int clientId = 0;

            Console.WriteLine("PROSZĘ PODAĆ ID KLIENTA, KTÓRY WYPOŻYCZA SAMOCHÓD:");
            try
            {
                clientId = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("NIEPRAWIDŁOWE ID.\n");
                MainMenu();
                return "";
            }

            int segmentId;

            Console.WriteLine("PODAJ SEGMENT SAMOCHODU:");
            Console.WriteLine(carRentalService.GetPossibleSegments(clientId));
            try
            {
                segmentId = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("NIEPRAWIDŁOWY SEGMENT.\n");
                MainMenu();
                return "";
            }

            int fuelTypeId;

            Console.WriteLine("PODAJ PREFEROWANY RODZAJ PALIWA:");
            Console.WriteLine(carRentalService.GetPossibleFuelTypes());
            try
            {
                fuelTypeId = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("NIEPRAWIDŁOWY RODZAJ PALIWA.\n");
                MainMenu();
                return "";
            }

            int days;

            Console.WriteLine("PODAJ ILOŚĆ DNI WYNAJMU POJAZDU:");
            try
            {
                days = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("NIEPOPRAWNA ILOŚĆ.\n");
                MainMenu();
                return "";
            }

            Console.WriteLine(carRentalService.RentCar(clientId, segmentId, fuelTypeId, days));

            MainMenu();

            return "";
        }

        private string GetClientsAndCarsView()
        {
            return carRentalService.GetClientsView() + carRentalService.GetCarsView();
        }

    }
}
