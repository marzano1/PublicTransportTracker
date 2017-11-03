using Npgsql;
using PublicTransportTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportTracker.DataAccess
{
    public class CityDA
    {
        public static City InsertCity(string cityName, int countryID, string timezone)
        {
            //deletar todos os registros relacionados aquela cidade;
            BaseDB.executeQuery("INSERT INTO City  VALUES (nextval('city_sequence')," + countryID + ",'" + cityName + "','" + timezone + "')");
            City city = new City();
            string query = "Select * from City where CityName = '" + cityName + "'";
            List<object[]> result = BaseDB.executeSelect(query);
            city.cityID = (int)result.FirstOrDefault()[0];
            city.countryID = (int)result.FirstOrDefault()[1];
            city.cityName = (string)result.FirstOrDefault()[2];
            city.timezone = (string)result.FirstOrDefault()[3];
            return city;
        }

        public static void DeleteCityData()
        {
            string query = "delete from City";
            BaseDB.executeQuery(query);
        }
    }
}