using InteractiveApiRisovaviti.HttpIntegration;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.ControllerIntegration
{
	internal abstract class PostControllerIntegration<T> : ControlerIntegration
	{
		public T Value { get; set; }
		public PostControllerIntegration(IAuthenticationUser user, T value) : base(user) 
		{
			Value = value;
		}

		protected override IApiRequest SettingApiRequest()
		{
			return new ApiPost<T>(User, Value);
		}
	}
}
