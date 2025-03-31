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
            if (populationDatas[0] < populationDatas[1] && populationDatas[1] < populationDatas[2] && populationDatas[2] < populationDatas[3] && populationDatas[3] < populationDatas[4] && populationDatas[4] < populationDatas[5])
            {
                return true;
            }
            else
            return false;
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
            
        }

        public List<City> Top10City(int year)
        {
            List<City> topCities = new List<City>();
            switch (year)
            {
                case 2010:

                    topCities = cityLista.OrderByDescending(x => x.Y2010).Take(10).ToList();
                    
                    return topCities;
                case 2020:
                    topCities = cityLista.OrderByDescending(x => x.Y2020).Take(10).ToList();
                    return topCities;
                case 2030:
                    topCities = cityLista.OrderByDescending(x => x.Y2030).Take(10).ToList();
                    return topCities;
                case 2040:
                    topCities = cityLista.OrderByDescending(x => x.Y2040).Take(10).ToList();
                    return topCities;
                case 2050:
                    topCities = cityLista.OrderByDescending(x => x.Y2050).Take(10).ToList();
                    return topCities;
                default:
                    return topCities;
            }
        }
    }
}
