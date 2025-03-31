using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopCityOrai
{
    internal class City
    {
        string cityCode;
        string cityName;
        int y2010;
        int y2020;
        int y2030;
        int y2040;
        int y2050;

        public City(string sor)
        {
            string[] splitteltSor = sor.Split(';');

            this.CityCode = splitteltSor[0];
            this.CityName = splitteltSor[1];
            this.Y2010 = int.Parse(splitteltSor[2]);
            this.Y2020 = int.Parse(splitteltSor[3]);
            this.Y2030 = int.Parse(splitteltSor[4]);
            this.Y2040 = int.Parse(splitteltSor[5]);
            this.Y2050 = int.Parse(splitteltSor[6]);
        }

        public string CityCode { get => cityCode; set => cityCode = value; }
        public string CityName { get => cityName; set => cityName = value; }
        public int Y2010 { get => y2010; set => y2010 = value; }
        public int Y2020 { get => y2020; set => y2020 = value; }
        public int Y2030 { get => y2030; set => y2030 = value; }
        public int Y2040 { get => y2040; set => y2040 = value; }
        public int Y2050 { get => y2050; set => y2050 = value; }
    }
}
