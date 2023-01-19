using System;

namespace LegacyApp.Helpers.DateTimeHelpers
{
    public class DateTimeHelper : IDateTimeHelper
    {
        public DateTime DateTime => DateTime.Now;
    }
}