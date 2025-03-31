namespace PopCityOrai
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //A kapott CSV állomány Európa nagyobb városainak a korábbi és a jövőbeli becsült népességszámait tartalmazza.
            // CITY_CODE;CITY_NAME;Y2010;Y2020;Y2030;Y2040;Y2050
            List<City> cities = new List<City>();


            //todo: 1F Készítsen osztályt egy város adatainak tárolására! (City)
            //todo: 2F Készítsen osztályt a városok adatainak kezelésére! (CitiesMethods), ami a megadott interfészt implementálja!

            //todo: Válaszoljon a következő kérdésekre a korábban létrehozott osztályok felhasználásával!

            //todo: 3F Hány város adatait tartalmazza a CSV fájl? (CitiesMethods)
            //todo: 4F Melyik 10 város volt a legnépesebb 2020-ban? (CitiesMethods)
            //todo: 5F Kérje be billentyűzetről egy város nevét! Ha nem létezik, akkor jelezze azt és kérje be újra! (CitiesMethods)
            //         Miután létező nevet adott meg, döntse el, hogy a város lakossága folyamatosan növekedett-e az évek alatt?
            //todo: 6F Írja (bigCities.CSV) fájlba a 2020-ban 1 millió főnél nagyobb népességgel rendelkező városokat! (CitiesMethods)
            //todo: 7F Írassa képernyőre azoknak a városoknak a nevét és népességváltozását, ahol 2050-ben kevesebben lesznek mint 2010-ben voltak!
            //todo:    A kiíratás népességcsökkenés szerint növevően rendezetten történjen! 
            //todo:    Tipp: Érdemes megfelelő metódussal vagy property-vel bővíteni az osztályt! (CitiesMethods)
            CitiesMethods methods = new();
            methods.LoadFromCSV("pop_city.csv");
            cities = methods.cityLista;
            Console.WriteLine("3.Feladat");
            Console.WriteLine($"Városok:");
            foreach (City city in cities)
            {
                Console.WriteLine(city.CityName);
            }

            Console.WriteLine(new string('*',80));

            Console.WriteLine("4.Feladat");
            Console.WriteLine("Top 10 város 2020: ");

            foreach (var item in methods.Top10City(2020))
            {
                Console.WriteLine(item.CityName);
            }

            Console.WriteLine(new string('*', 80));

            Console.WriteLine("5.Feladat");
            Console.WriteLine("Adjon meg egy várost: ");
            string varos = Console.ReadLine();
            bool containsCity = false;
            do
            {
                if (cities.Select(x => x.CityName).Contains(varos))
                {
                   containsCity = true;
                }
            }
            while (!containsCity);

            List<int> evek = new();
            foreach (var item in cities)
            {
                if (item.CityName == varos)
                {
                    evek.Add(item.Y2010);
                    evek.Add(item.Y2020);
                    evek.Add(item.Y2030);
                    evek.Add(item.Y2040);
                    evek.Add(item.Y2050);
                }
            }
            if (methods.IsContinuousGrowing(evek))
            {
                Console.WriteLine("Ennek a városnak a lakossága folyamatosan növekedett!");
            }
            else
            {
                Console.WriteLine("Ennek a városnak nem növekedett folyamatosan a lakossága!");
            }
        }
    }   
}
