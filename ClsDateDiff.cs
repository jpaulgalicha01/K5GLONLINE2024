using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace K5GLONLINE
{
    class ClsDateDiff
    {
        public int GetMonths(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                throw new Exception("Start Date is greater than the End Date");
            }

            int months = ((endDate.Year * 12) + endDate.Month) - ((startDate.Year * 12) + startDate.Month)-1;

            if (endDate.Day >= startDate.Day)
            {
                months++;
            }

            return months+1;
        }
    }
}
