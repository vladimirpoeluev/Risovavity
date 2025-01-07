using DataIntegration.Interface;
using DataIntegration.Interface.InterfaceOfModel;
using DomainModel.JwtModels;
using DomainModel.ResultsRequest;
using DomainModel.ResultsRequest.EmailResult;
using Logic.Interface;
using Logic.JwtBearerAuthentication.Interface;

namespace Logic.EmailIntegration.Interface
{
    public class UserConfirmation : IUserConfirmation
    {
        private IEntranceUser _entrancerUser;
        private IAutorizeServiceRefresh _autorizeServiceRefresh;
        private IRedisService _redisService;
        private IEmailService _emailService;
        private IUserDataBase _userDataBase;

        public UserConfirmation(IEntranceUser entranceUser,
                                IAutorizeServiceRefresh autorizeService,
                                IRedisService redisService,
                                IEmailService email,
                                IUserDataBase userData)
        {
            _entrancerUser = entranceUser;
            _autorizeServiceRefresh = autorizeService;
            _redisService = redisService;
            _emailService = email;
            _userDataBase = userData;
        }

        public async Task AddToPendingConfirmation(AuthenticationForm form)
        {
            UserResult user = await _entrancerUser.Login(form);
            TokensRefreshAndAccess tokens = await _autorizeServiceRefresh.RegistSession(user);
            string code = CodeGenerater.Generate();
            string email = _userDataBase.Users.First(entity => entity.Id == user.Id).Email;
            await _emailService.SendMessageAsync(email, code);
            await _redisService.AddObject($"userAwait:{form.Login}:{code}", tokens);
        }

        public async Task<TokensRefreshAndAccess> Verify(UserConfirmationResult userConfirmation)
        {
            var key = $"userAwait:{userConfirmation.Login}:{userConfirmation.Code}";
            TokensRefreshAndAccess tokens =
                await _redisService.GetObject<TokensRefreshAndAccess>(key);
            await _redisService.DeleteObject(key);
            return tokens;
        }
    }
}
