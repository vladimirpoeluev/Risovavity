using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.ControllerIntegration
{
	internal abstract class FabricAutoControllerIntegraion
	{
		public abstract IPostAutoControllerIntegraion CreatePostPatser<T>(IAuthenticationUser user, T obj);
		public abstract IGetAutoControllerIntegraion CreateGetPatser<T>(IAuthenticationUser user);
	}
}
