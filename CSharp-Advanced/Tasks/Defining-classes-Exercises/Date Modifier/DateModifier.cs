using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Markup;

namespace DefiningClasses
{
    public class DateModifier
    {
        //private int days;

        //public int Days
        //{
        //    get
        //    {
        //        return this.Days = days;
        //    }
        //    set 
        //    {
        //        this.days = value;
        //    }
        //}

        //public DateModifier()
        //{
        //    this.Days = days;
        //}
        public int GetDiffTwoDates(string firstdate, string secondDate)
        {
            DateTime startDate = DateTime.Parse(firstdate);
            DateTime endDate = DateTime.Parse(secondDate);

            int days = (endDate.Date - startDate.Date).Days;

            return days;
        }
    }
}
