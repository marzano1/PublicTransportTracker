using PublicTransportTracker.DataAccess;
using PublicTransportTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportTracker.Business
{
    public class CalendarBusiness
    {
        public static void InsertCalendarList(List<Calendar> calendarList)
        {
            CalendarDA.InsertCalendarList(calendarList);
        }
    }
}