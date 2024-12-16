using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.ControllerIntegration
{
	public abstract class FabricAutoControllerIntegraion
	{
		public abstract IPostAutoControllerIntegraion CreatePostPatser<T>(IAuthenticationUser user, T obj);
		public abstract IGetAutoControllerIntegraion CreateGetPatser(IAuthenticationUser user);
	}
}
