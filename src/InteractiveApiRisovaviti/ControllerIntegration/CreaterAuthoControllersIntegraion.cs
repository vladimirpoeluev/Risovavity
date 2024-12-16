using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.ControllerIntegration
{
	public class CreaterAuthoControllersIntegraion : FabricAutoControllerIntegraion
	{
		public override IGetAutoControllerIntegraion CreateGetPatser(IAuthenticationUser user)
		{
			return new GetAutoControllerIntegraion(user);
		}

		public override IPostAutoControllerIntegraion CreatePostPatser<T>(IAuthenticationUser user, T obj)
		{
			return new PostAutoControllerIntegraion<T>(user, obj);
		}
	}
}
