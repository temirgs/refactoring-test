using System;

namespace LegacyApp.Models
{
    public class User
    {
        public User()
        {
        }

        public User(Client client,
            DateTime dateOfBirth, string emailAddress,
            string firstname, string surname)
        {
            Client = client;
            DateOfBirth = dateOfBirth;
            EmailAddress = emailAddress;
            Firstname = firstname;
            Surname = surname;
        }

        public Client Client { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EmailAddress { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public bool HasCreditLimit { get; set; }
        public int CreditLimit { get; set; }
    }
}