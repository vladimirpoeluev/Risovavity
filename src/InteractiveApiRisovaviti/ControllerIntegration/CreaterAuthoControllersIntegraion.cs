using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.ControllerIntegration
{
	internal class CreaterAuthoControllersIntegraion : FabricAutoControllerIntegraion
	{
		public override IGetAutoControllerIntegraion CreateGetPatser<T>(IAuthenticationUser user)
		{
			return new GetAutoControllerIntegraion(user);
		}

		public override IPostAutoControllerIntegraion CreatePostPatser<T>(IAuthenticationUser user, T obj)
		{
			return new PostAutoControllerIntegraion<T>(user, obj);
		}
	}
}
