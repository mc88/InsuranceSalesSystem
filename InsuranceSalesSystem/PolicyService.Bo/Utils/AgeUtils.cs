using System;

namespace PolicyService.Bo.Utils
{
    public static class AgeUtils
    {
        public static int CalculateAgeFromPesel(string pesel)
        {
            DateTime today = DateTime.Today;
            DateTime birthDate = GetBirthDateFromPesel(pesel);

            int age = today.Year - birthDate.Year;

            // Go back to the year the person was born in case of a leap year
            if (birthDate > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }

        private static DateTime GetBirthDateFromPesel(string pesel)
        {
            int year = int.Parse(pesel.Substring(0, 2));
            int month = int.Parse(pesel.Substring(2, 2));
            int day = int.Parse(pesel.Substring(4, 2));

            if (month > 20)
            {
                //person was born after 31-12-1999
                year = year + 2000;
            }
            else
            {
                //person was born before 01-01-2000
                year = year + 1900;
            }

            return new DateTime(year, month, day);
        }
    }
}
