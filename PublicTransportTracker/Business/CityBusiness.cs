using PublicTransportTracker.DataAccess;
using PublicTransportTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportTracker.Business
{
    public class CityBusiness
    {

        public static City InsertCity(string cityName, int countryID, string timezone)
        {
            return CityDA.InsertCity(cityName,countryID,timezone);
        }



        public static void DeleteCityData()
        {
            CityDA.DeleteCityData();
        }
    }
}