using PublicTransportTracker.Business;
using PublicTransportTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;


namespace PublicTransportTracker.DataAccess
{
    public class StopTimeDA
    {
        public static void InsertStopTimeList(List<StopTime> stopTimeList)
        {
            List<List<object>> values = new List<List<object>>();
            foreach (StopTime s in stopTimeList)
            {
                List<object> objList = new List<object>();
                objList.Add("nextval('stoptime_sequence')");                
                objList.Add(s.tripID);
                objList.Add(s.stopID);
                objList.Add(UtilBusiness.ConvertToTime(s.arrivalTime));
                objList.Add(UtilBusiness.ConvertToTime(s.departureTime));
                values.Add(objList);
            }
            BaseDB.executeInsert("stoptime", values);
        }
    }
}
