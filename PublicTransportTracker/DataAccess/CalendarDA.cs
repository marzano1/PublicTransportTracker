using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PublicTransportTracker.Entities;
using PublicTransportTracker.Business;

namespace PublicTransportTracker.DataAccess
{
    public class CalendarDA
    {

        public static void InsertCalendarList(List<Calendar> calendarList)
        {
            List<List<object>> values = new List<List<object>>();
            foreach(Calendar c in calendarList)
            {
                List<object> objList = new List<object>();
                objList.Add(c.serviceID);
                objList.Add(c.weekDays);
                objList.Add(UtilBusiness.ConvertToTimestamp(c.startDate));
                objList.Add(UtilBusiness.ConvertToTimestamp(c.endDate));
                objList.Add(c.cityID);
                values.Add(objList);                
            }
            BaseDB.executeInsert("calendar", values);

        }


    }
}