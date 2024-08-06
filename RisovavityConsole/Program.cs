
using DomainModel.Records;
using InteractiveApiRisovaviti;

Console.Write("Введите логин: ");
string login = Console.ReadLine() ?? "";
Console.Write("Введите пароль: ");
string password = Console.ReadLine() ?? "";
try
{
	Console.WriteLine(new Entrance().IputSystem(login, password).Name);
}
catch(Exception ex)
{
	Console.WriteLine(ex.Message);
}

Console.ReadLine();