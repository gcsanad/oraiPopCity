using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopCityOrai
{
    internal class CitiesMethods : ICityMethods
    {
        public List<City> cityLista = new();

        public int CityCount()
        {
            return cityLista.Count;
        }

        public bool IsContinuousGrowing(List<int> populationDatas)
        {
            for (int i = 0; i < populationDatas.Count - 1; i++)
            {
                if (populationDatas[i] >= populationDatas[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        public void LoadFromCSV(string path)
        {
            //cityLista = File.ReadAllLines(path).Skip(1).Where(x => !x.Contains("null")).Select(x => new City(x.Split(";"))).ToList();
            foreach (var item in File.ReadAllLines(path).Skip(1).ToList())
            {
                if (!item.Contains("NaN"))
                {
                    cityLista.Add(new City(item));
                }
            } 
        }

        public void SaveToCSV(string path, List<City> cities, string charCode = "UTF-8")
        {
            File.WriteAllLines(path, cities.Select(x => x.ToString()), Encoding.GetEncoding(charCode));
        }

        public List<City> Top10City(int year)
        {
            List<City> topCities = new List<City>();
            switch (year)
            {
                case 2010:
                    return cityLista.OrderByDescending(x => x.Y2010).Take(10).ToList();
                case 2020:
                    return cityLista.OrderByDescending(x => x.Y2020).Take(10).ToList();
                case 2030:
                    return cityLista.OrderByDescending(x => x.Y2030).Take(10).ToList();
                case 2040:
                    return cityLista.OrderByDescending(x => x.Y2040).Take(10).ToList();
                case 2050:
                    return cityLista.OrderByDescending(x => x.Y2050).Take(10).ToList();
                default:
                    throw new ArgumentException("Nem létező év lett megadva!");
            }
        }
        
    }
}
