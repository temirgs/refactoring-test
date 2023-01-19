using System;
using LegacyApp.Models;
using LegacyApp.Helpers.DateTimeHelpers;

namespace LegacyApp.Validators
{
    public class UserValidator
    {
        private readonly IDateTimeHelper _dateTimeHelper;

        public UserValidator(IDateTimeHelper dateTimeHelper)
        {
            _dateTimeHelper = dateTimeHelper;
        }

        private bool IsEmailValid(string email)
        {
            return email.Contains("@") && !email.Contains(".");
        }

        public bool UserHasCreditLimit(User user)
        {
            return user.HasCreditLimit && user.CreditLimit < 500;
        }

        private bool IsUser21YearsOld(DateTime dateOfBirth)
        {
            DateTime now = _dateTimeHelper.DateTime;
            int age = now.Year - dateOfBirth.Year;

            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day))
            {
                age--;
            }

            return age >= 21;
        }

        private bool IsFullnameValid(string firstname, string surname)
        {
            return !string.IsNullOrEmpty(firstname) && !string.IsNullOrEmpty(surname);
        }

        public bool ValidateUserCreate(string firstname, string surname, string email, DateTime dateOfBirth)
        {
            if (!IsFullnameValid(firstname, surname))
            {
                return false;
            }

            return IsEmailValid(email) && IsUser21YearsOld(dateOfBirth);
        }
    }
}