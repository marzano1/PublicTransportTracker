using Npgsql;
using PublicTransportTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportTracker.DataAccess
{

    public class CountryDA
    {    



        private static void InsertCountry(string countryName)
        {
            BaseDB.executeQuery("INSERT INTO Country  VALUES (nextval('country_sequence'),'"+ countryName + "')");
        }

        public static Country GetCountryByName(string countryName)
        {
            Country country = new Country();
            string query = "Select * from Country where CountryName = '"+ countryName + "'";
            List<object[]> result = BaseDB.executeSelect(query);
            if(result.Count == 0)
            {
                InsertCountry(countryName);
                return GetCountryByName(countryName);
            }
            else
            {
                country.countryID = (int)result.FirstOrDefault()[0];
                country.countryName = (string)result.FirstOrDefault()[1];
                return country;
            }
        }

        public static void DeleteCountryData()
        {
            string query = "delete from Country";
            BaseDB.executeQuery(query);
        }
    }
}