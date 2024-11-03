using InteractiveApiRisovaviti.HttpIntegration;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.ControllerIntegration
{
    internal abstract class GetControllerIntegration : ControlerIntegration
    {
        protected GetControllerIntegration(IAuthenticationUser user) : base(user) {}

        protected override IApiRequest SettingApiRequest() => new ApiGet(User);
    }
}
