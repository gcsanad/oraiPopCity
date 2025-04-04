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
            string varos;
            bool containsCity = false;

            do
            {
                Console.WriteLine("Adjon meg egy várost: ");
                varos = Console.ReadLine();
                containsCity = cities.Any(x => x.CityName == varos);
                if (!containsCity)
                {
                    Console.WriteLine("A megadott város nem létezik, próbálja újra!");
                }
            } while (!containsCity);

            City selectedCity = cities.First(x => x.CityName.Equals(varos, StringComparison.OrdinalIgnoreCase));
            List<int> evek = new List<int> { selectedCity.Y2010, selectedCity.Y2020, selectedCity.Y2030, selectedCity.Y2040, selectedCity.Y2050 };

            if (methods.IsContinuousGrowing(evek))
            {
                Console.WriteLine("Ennek a városnak a lakossága folyamatosan növekedett!");
            }
            else
            {
                Console.WriteLine("Ennek a városnak nem növekedett folyamatosan a lakossága!");
            }

            Console.WriteLine(new string('*', 80));

            Console.WriteLine("6.Feladat");
            List<City> bigCities = cities.Where(c => c.Y2020 > 1000000).ToList();
            methods.SaveToCSV("bigCities.csv", bigCities);
            Console.WriteLine("A 2020-ban 1 millió főnél nagyobb népességgel rendelkező városok elmentve a bigCities.csv fájlba.");


            Console.WriteLine(new string('*', 80));

            Console.WriteLine("7.Feladat");
            var decreasingCities = cities
                .Where(c => c.Y2050 < c.Y2010)
                .Select(c => new { c.CityName, PopulationChange = c.Y2010 - c.Y2050 })
                .OrderBy(c => c.PopulationChange)
                .ToList();

            foreach (var city in decreasingCities)
            {
                Console.WriteLine($"{city.CityName}: {city.PopulationChange}");
            }
        }
    }   
}
