using PublicTransportTracker.DataAccess;
using PublicTransportTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportTracker.Business
{
    public class CountryBusiness
    {

        public static Country getCountryByName(string countryName)
        {
            return CountryDA.GetCountryByName(countryName);
        }


        public static void DeleteCountryData()
        {
            CountryDA.DeleteCountryData();
        }

    }


}