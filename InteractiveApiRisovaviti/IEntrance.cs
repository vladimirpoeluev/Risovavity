using DomainModel.Model;

namespace InteractiveApiRisovaviti
{
	internal interface IEntrance
	{
		Role IputSystem(string login, string password);
	}
}
