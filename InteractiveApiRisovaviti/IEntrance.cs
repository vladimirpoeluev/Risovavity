using DomainModel.Records;

namespace InteractiveApiRisovaviti
{
	internal interface IEntrance
	{
		Role IputSystem(string login, string password);
	}
}
