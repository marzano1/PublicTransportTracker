using PublicTransportTracker.Entities;
using PublicTransportTracker.Models;
using PublicTransportTracker.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportTracker.Business
{
    public class UploadBusiness
    {
        public static int PersistTransportData(UploadModel model)
        {
            try
            {

                #region Código funcionando

                Country country = CountryBusiness.getCountryByName(model.countryName);
                string cityTimezone = AgencyParser.getTimeZone(model.agencyFile);
                //falta procurar a cidade no banco e caso exista, exluir todos os registros relacionados à ela.
                UtilBusiness.DeleteAllData(); // provisorio
                City city = CityBusiness.InsertCity(model.cityName, country.countryID, cityTimezone);
                //List<Calendar> calendarList = CalendarParser.getCalendarList(city.cityID, model.calendarFile);
                //CalendarBusiness.InsertCalendarList(calendarList);
                //List<Route> routes = RoutesParser.getRouteList(city.cityID, model.routesFile);
                //RouteBusiness.InsertRouteList(routes);
                //List<Stop> stops = StopsParser.getStopList(city.cityID, model.stopsFile);
                //StopBusiness.InsertStopList(stops);
                //List<Trip> trips = TripsParser.getTripList(model.tripsFile, model.shapesFile);
                //TripBusiness.InsertTripList(trips);
                //List<StopTime> stopTimes = StopTimesParser.getStopTimesList(model.stopTimesFile);
                //StopTimeBusiness.InsertStopTimeList(stopTimes);
                #endregion











            }
            catch (Exception e)
            {
                return 1;
            }

            return 0;
        }

    }
}