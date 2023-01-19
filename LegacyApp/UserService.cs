using System;
using LegacyApp.Models;
using LegacyApp.Credits;
using LegacyApp.Services;
using LegacyApp.Validators;
using LegacyApp.Repositories;
using LegacyApp.Helpers.DateTimeHelpers;
using LegacyApp.Helpers.DataAccessHelpers;


namespace LegacyApp
{
    public class UserService
    {
        private readonly UserValidator _userValidator;
        private readonly IClientRepository _clientRepository;
        private readonly IUserDataAccessHelper _userDataAccessHelper;
        private readonly CreditLimitProviderFactory _creditLimitProviderFactory;

        private UserService(
            UserValidator userValidator,
            IClientRepository clientRepository,
            IUserDataAccessHelper userDataAccessHelper,
            CreditLimitProviderFactory creditLimitProviderFactory)

        {
            _userValidator = userValidator;
            _clientRepository = clientRepository;
            _userDataAccessHelper = userDataAccessHelper;
            _creditLimitProviderFactory = creditLimitProviderFactory;
        }

        public UserService() : this(
            new UserValidator(new DateTimeHelper()),
            new ClientRepository(),
            new UserDataAccessHelper(),
            new CreditLimitProviderFactory(new UserCreditServiceClient()))
        {
        }

        public bool AddUser(string firstname, string surname, string email, DateTime dateOfBirth, int clientId)
        {
            if (!_userValidator.ValidateUserCreate(firstname, surname, email, dateOfBirth))
            {
                return false;
            }

            Client client = _clientRepository.GetById(clientId);
            User user = new User(client, dateOfBirth, email, firstname, surname);

            ICreditLimit creditLimit = _creditLimitProviderFactory.GetProviderByClientName(client.Name);

            (bool hasLimit, int limit) = creditLimit.GetLimits(user);
            user.CreditLimit = limit;
            user.HasCreditLimit = hasLimit;

            if (_userValidator.UserHasCreditLimit(user))
            {
                return false;
            }

            _userDataAccessHelper.AddUser(user);

            return true;
        }
    }
}