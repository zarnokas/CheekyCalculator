using System;
using System.Collections.Generic;

namespace MajaTest
{
    //static class to calculate toll fees. Only returns the fee for a given DateTime.
    public static class TollFee
    {
        private static readonly List<KeyValuePair<int, int>> DateList = new List<KeyValuePair<int, int>>();
        private static readonly int MinFee, MaxFee, MedFee, NoFee;

        //Should be private since we dont want anyone changing our dates! Also it's static so it shouldn't even be initialised more than once.
        static TollFee()
        {
            //Define toll fee amount in one convenient place
            NoFee = 0;
            MinFee = 9;
            MedFee = 16;
            MaxFee = 22;

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
                //Could probably be changed to a switch statement for better efficiency!
                if ((hour == 18 && minute >= 30) || hour >= 19 || hour <= 5) return NoFee;

                //second longest time span in case we can avoid unecessary if-checks
                if ((hour == 8 && minute >= 30) || (hour >= 9 && hour <= 14)) return MinFee;

                if (hour == 6 && minute <= 29) return MinFee;

                if (hour == 6 && minute >= 30) return MedFee;

                if (hour == 7) return MaxFee;

                if (hour == 8 && minute <= 29) return MedFee;

                if (hour == 15 && minute <= 29) return MedFee;

                if ((hour == 15 && minute >= 30) || hour == 16) return MaxFee;

                if (hour == 17) return MedFee;

                if (hour == 18 && minute <= 29) return MinFee;
            }

            //if the day is free return 0
            return NoFee;
        }
    }
}
