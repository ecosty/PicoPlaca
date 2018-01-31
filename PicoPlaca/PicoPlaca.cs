using System;
using System.Globalization;

namespace PicoPlaca
{
    /// <summary>
    /// Class Pico y Placa
    /// Contains the Plate Number, Date, Time properties
    /// Contains the CheckPicoPlaca method to validate Pico y Placa
    /// Contains private methods to validate the Day of Pico y Placa and the Time of the day.
    /// </summary>
    public class PicoPlaca
    {
        /// <summary>
        /// Public properties
        /// </summary>
        public string PlateNumber { get; set; }
        public string CheckDate { get; set; }
        public string CheckTime { get; set; }
        
        //No need to declare a basic constructor in C#.

        /// <summary>
        /// General method that validates Pico y Placa functionality.
        /// </summary>
        /// <param name="checkPlateNumber">Plate Number</param>
        /// <param name="checkDate">Date</param>
        /// <param name="checkTime">Time</param>
        /// <returns>Result message</returns>
        public string CheckPicoPlaca(string checkPlateNumber, string checkDate, string checkTime)
        {
            try
            {
                DateTime dt = Convert.ToDateTime(checkDate);
                DayOfWeek dayToCheck = dt.DayOfWeek;

                if (dayToCheck == DayOfWeek.Saturday || dayToCheck == DayOfWeek.Sunday)
                {
                    return "The car can be on the road all day because is weekend";
                }
                
                return CheckPlateNumberDay(checkPlateNumber, dayToCheck, checkTime);
            }
            catch (Exception)
            {
                return "Invalid Date format.";
            }
        }

        /// <summary>
        /// Method that validates plate number length and gets last digit to validate with Pico y Placa restrictions
        /// </summary>
        /// <param name="checkPlateNumber">Plate Number</param>
        /// <param name="dayToCheck">Day of the Week</param>
        /// <param name="checkTime">Time</param>
        /// <returns>Result message</returns>
        private string CheckPlateNumberDay(string checkPlateNumber, DayOfWeek dayToCheck, string checkTime)
        {
            if (checkPlateNumber.Length != 7)
            {
                return "Plate Number Size is incorrect";
            }
            
            string lastDigitPlate = checkPlateNumber.Substring(checkPlateNumber.Length - 1, 1);

            //Map Pico y Placa Dates with last digit of the Plate Number
            int lastDigit;
            if (int.TryParse(lastDigitPlate, out lastDigit))
            {
                DayOfWeek dayOfWeekPlate = DayWeekPlate(lastDigit);

                if (dayToCheck == dayOfWeekPlate)
                {
                    //chequear horas
                    return CheckTimeOfDay(checkTime);
                }

                return "Car can be on the road all day because Pico y Placa does not apply this day.";
            }

            return "Last digit of Plate Number is not a valid number.";
        }

        /// <summary>
        /// Returns the Day of the Week based on Pico y Placa last digit restrictions.
        /// </summary>
        /// <param name="dayToCheck">Last digit of the Plate Number</param>
        /// <returns>Day of the Week according to the last digit in the plate number</returns>
        private DayOfWeek DayWeekPlate(int dayToCheck)
        {
            switch (dayToCheck)
            {
                case 1:
                case 2:
                    return DayOfWeek.Monday;
                case 3:
                case 4:
                    return DayOfWeek.Tuesday;
                case 5:
                case 6:
                    return DayOfWeek.Wednesday;
                case 7:
                case 8:
                    return DayOfWeek.Thursday;
                case 9:
                case 0:
                    return DayOfWeek.Friday;
            }

            return DayOfWeek.Monday;
        }

        /// <summary>
        /// Check if time let's the car be on the road according to Pico y Placa restrictions.
        /// </summary>
        /// <param name="checkTime">Time</param>
        /// <returns>Result message</returns>
        private string CheckTimeOfDay(string checkTime)
        {
            try
            {
                DateTime plateTime = DateTime.ParseExact(checkTime, "HH:mm", CultureInfo.InvariantCulture);

                TimeSpan startMorning = new TimeSpan(07, 0, 0);
                TimeSpan endMorning = new TimeSpan(09, 30, 0);

                TimeSpan startNight = new TimeSpan(16, 0, 0);
                TimeSpan endNight = new TimeSpan(19, 30, 0);
                TimeSpan timeToCheck = plateTime.TimeOfDay;


                if ((timeToCheck >= startMorning && timeToCheck <= endMorning) ||
                    (timeToCheck >= startNight && timeToCheck <= endNight))
                {
                    return "The car cannot be on the road because time is inside the Pico y Placa restrictions.";
                }

                return "The car can be on the road because time is not inside the Pico y Placa restrictions.";
            }
            catch (Exception)
            {
                return "Invalid time format";
            }
        }
    }
}
