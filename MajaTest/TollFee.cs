using System;
using System.Collections.Generic;

namespace MajaTest
{
    //static class to calculate toll fees. Only returns the fee for a given DateTime.
    public static class TollFee
    {
        private static readonly List<KeyValuePair<int, int>> DateList = new List<KeyValuePair<int, int>>();
        private static int minFee, maxFee, medFee, noFee;

        //Should be private since we dont want anyone changing our dates! Also it's static so it shouldn't even be initialised more than once.
        static TollFee()
        {
            //Define toll fee amount in one convenient place
            noFee = 0;
            minFee = 9;
            medFee = 16;
            maxFee = 22;

            //Add exempt dates
            DateList.Add(new KeyValuePair<int, int>(1, 2));
            DateList.Add(new KeyValuePair<int, int>(3, 4));
            DateList.Add(new KeyValuePair<int, int>(5, 6));
            DateList.Add(new KeyValuePair<int, int>(7, 8));
            DateList.Add(new KeyValuePair<int, int>(9, 10));
        }

        public static bool IsTollFreeDate(DateTime date)
        {
            //caheck if its no charge month, else return if the date is on the exempt list or not
            return date.Month == 7 || DateList.Contains(new KeyValuePair<int, int>(date.Month, date.Day));
        }

        public static int GetFee(DateTime timeStamp)
        {
            //Check if the date is free by default
            if (!IsTollFreeDate(timeStamp))
            {
                //set hour and minute for easier readability
                int hour = timeStamp.Hour;
                int minute = timeStamp.Minute;

                //Check what fee is applicable for the specified time
                //start with longest time span to potentially skip additional if-checks
                if ((hour == 18 && minute >= 30) || hour >= 19 || hour <= 5) return noFee;

                //second longest time span in case we can avoid unecessary if-checks
                if ((hour == 8 && minute >= 30) || (hour >= 9 && hour <= 14)) return minFee;

                if (hour == 6 && minute <= 29) return minFee;

                if (hour == 6 && minute >= 30) return medFee;

                if (hour == 7) return maxFee;

                if (hour == 8 && minute <= 29) return medFee;

                if (hour == 15 && minute <= 29) return medFee;

                if ((hour == 15 && minute >= 30) || hour == 16) return maxFee;

                if (hour == 17) return medFee;

                if (hour == 18 && minute <= 29) return minFee;
            }

            //if the day is free return 0
            return noFee;
        }
    }
}
