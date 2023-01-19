using LegacyApp.Models;
using LegacyApp.Services;

namespace LegacyApp.Credits
{
    public class BaseCreditLimit : ICreditLimit
    {
        public string ClientName => string.Empty;
        private readonly IUserCreditService _userCreditService;

        public BaseCreditLimit(IUserCreditService userCreditService)
        {
            _userCreditService = userCreditService;
        }

        public (bool hasLimit, int limit) GetLimits(User user)
        {
            int limit = _userCreditService.GetCreditLimit(user.Firstname, user.Surname, user.DateOfBirth);

            return (true, limit);
        }
    }
}