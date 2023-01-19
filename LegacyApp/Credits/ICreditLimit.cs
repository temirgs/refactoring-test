using LegacyApp.Models;

namespace LegacyApp.Credits
{
    public interface ICreditLimit
    {
        public string ClientName { get; }
        (bool hasLimit, int limit) GetLimits(User user);
    }
}