using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlCovid.Models.BLL
{
    public class ValidacionesBLL
    {
        public static DateTime ProximoServicio(DateTime startDate, DayOfWeek desiredDay)
        {            
            DateTime nextDate = startDate;
            while (nextDate.DayOfWeek != desiredDay)
                nextDate = nextDate.AddDays(1D);
            return nextDate;
        }
    }
}