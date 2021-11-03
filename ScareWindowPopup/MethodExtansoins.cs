using System;
using System.Collections.Generic;
using System.Text;

namespace ScareWindowPopup
{
    /// <summary>
    /// 
    /// NOTE: Yes, I am aware I don't really need any of these and that they really only add a small
    /// amount of functinality. Really I just wanted to practice with them becuase its fun and
    /// practacing with them will make me better. I could use them for mroe purposeful changes in the future!
    /// 
    /// </summary>
    public static class MethodExtansoins
    {
        /* add a random amount of hours (within 5 hours, 
         * this because of current design, may change later) to current time*/
        public static DateTime addRandomHours(this DateTime currentDateTimeNow)
        {
            //define hours to add variable
            int hoursTimeSpan;
            //instanciate and define a random class for use, only plan to use here
            Random rand = new Random();
            //set random value, use variable to simply be verbose (didn't need it)
            hoursTimeSpan = rand.Next(1, 6);
            //use custom extension method to add a random number of hours, MAY NEED TO EDIT LATER, FOR BETTER LOOKING CODE
            currentDateTimeNow = currentDateTimeNow.AddHours(hoursTimeSpan);
            //return the current date time object
            return currentDateTimeNow;
        }
        /* refreashes the current date time 
         * (becasue it may be differetn then when we initalized it originally*/
        public static DateTime refreshDateTime(this DateTime currentDateTimeNow)
        {
            //check current actual current date and return it
            currentDateTimeNow = DateTime.Now;
            return currentDateTimeNow;
        }
        /* adds random amount of days (within a range) */
        public static DateTime addRamdomDays(this DateTime currentDateTimeNow)
        {/* need to find a way to have this in startup folder then keep instance when computer restarted idk, but something like that, until then will just not use the add days extension method */
            //define int for amount of random days to add
            int daysRangeSpan;
            //define and instanciate a random class/object
            Random rand = new Random();
            //decide on a random amount of days (0-3)
            daysRangeSpan = rand.Next(3);
            //add the amount of random days to the currentDateTimeNow object
            currentDateTimeNow = currentDateTimeNow.AddDays(daysRangeSpan);
            //return the new DateTime object/class with a random amount of days added
            return currentDateTimeNow;
        }
    }
}
