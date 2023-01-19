using LegacyApp.Models;

namespace LegacyApp.Credits
{
    public class VeryImportantClientCreditLimit : ICreditLimit
    {
        public string ClientName => "VeryImportantClient";

        public (bool hasLimit, int limit) GetLimits(User user)
        {
            return (false, 0);
        }
    }
}