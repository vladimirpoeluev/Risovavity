
using InteractiveApiRisovaviti.HttpIntegration;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.ControllerIntegration
{
	internal abstract class PostControllerIntegration<T> : ControlerIntegration
	{
		private T _value;
		public PostControllerIntegration(IAuthenticationUser user, T value) : base(user) 
		{
			_value = value;
		}

		protected override IApiRequest SettingApiRequest()
		{
			return new ApiPost<T>(User, _value);
		}
	}
}
