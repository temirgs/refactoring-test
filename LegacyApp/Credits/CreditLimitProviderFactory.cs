using System.Collections.Generic;
using LegacyApp.Services;

namespace LegacyApp.Credits
{
    public class CreditLimitProviderFactory
    {
        private readonly Dictionary<string, ICreditLimit> _creditLimits = new();

        public CreditLimitProviderFactory(IUserCreditService userCreditService)
        {
            _creditLimits["Base"] = new BaseCreditLimit(userCreditService);
            _creditLimits["VeryImportantClient"] = new VeryImportantClientCreditLimit();
            _creditLimits["ImportantClient"] = new ImportantClientCreditLimit(userCreditService);
        }

        public ICreditLimit GetProviderByClientName(string name)
        {
            return string.IsNullOrEmpty(name) ? _creditLimits["base"] : _creditLimits[name];
        }
    }
}