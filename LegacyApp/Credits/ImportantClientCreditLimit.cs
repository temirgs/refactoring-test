using LegacyApp.Models;
using LegacyApp.Services;

namespace LegacyApp.Credits
{
    public class ImportantClientCreditLimit : ICreditLimit
    {
        public string ClientName => "ImportantClient";
        private readonly IUserCreditService _userCreditService;

        public ImportantClientCreditLimit(IUserCreditService userCreditService)
        {
            _userCreditService = userCreditService;
        }

        public (bool hasLimit, int limit) GetLimits(User user)
        {
            int limit = _userCreditService.GetCreditLimit(user.Firstname, user.Surname, user.DateOfBirth);

            return (true, limit * 2);
        }
    }
}