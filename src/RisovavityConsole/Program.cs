
using DomainModel.Model;
using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti;
using InteractiveApiRisovaviti.Interface;

Console.Write("Введите логин: ");
string login = Console.ReadLine() ?? "";
Console.Write("Введите пароль: ");
string password = Console.ReadLine() ?? "";
try
{
	IAuthenticationUser user = new Entrance().IputSystem(login, password);
	Console.WriteLine("Вход был выполнен успешно");
	UserResult userResult = new Profile(user).ProfileUser;
	Console.WriteLine($"Профиль {userResult.IdRoleNavigation.Name}a:");
	Console.WriteLine($"Имя {userResult.Name}");
	Console.WriteLine($"ID {userResult.Id}");
	Console.WriteLine($"Почта {userResult.Email}");
	Console.WriteLine($"Роль {userResult.IdRoleNavigation.Name}");
}
catch(Exception ex)
{
	Console.WriteLine(ex.Message);
}

Console.ReadLine();