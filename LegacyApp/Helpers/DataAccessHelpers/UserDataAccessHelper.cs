using LegacyApp.DataAccess;
using LegacyApp.Models;

namespace LegacyApp.Helpers.DataAccessHelpers
{
    public class UserDataAccessHelper : IUserDataAccessHelper
    {
        public void AddUser(User user)
        {
            UserDataAccess.AddUser(user);
        }
    }
}