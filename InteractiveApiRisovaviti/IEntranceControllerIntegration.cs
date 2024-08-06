
namespace InteractiveApiRisovaviti
{
	internal interface IEntranceControllerIntegration
	{
		Guid GetCode(string login, string password);
	}
}
