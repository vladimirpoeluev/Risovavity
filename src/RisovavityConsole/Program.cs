
using DomainModel.Model;
using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti;
using InteractiveApiRisovaviti.Interface;

Console.Write("Введите логин: ");
string login = Console.ReadLine() ?? "";
Console.Write("Введите пароль: ");
string password = Console.ReadLine() ?? "";

	IAuthenticationUser user = new Entrance().IputSystem(login, password);
	Console.WriteLine("Вход был выполнен успешно");
	UserResult userResult = new Profile(user).ProfileUser;
	Console.WriteLine($"Профиль {userResult.IdRoleNavigation.Name}a:");
	Console.WriteLine($"Имя {userResult.Name}");
	Console.WriteLine($"ID {userResult.Id}");
	Console.WriteLine($"Почта {userResult.Email}");
	Console.WriteLine($"Роль {userResult.IdRoleNavigation.Name}");

	Console.WriteLine();

	Console.WriteLine("Изменение пользовательских данных");
	userResult.Email = "Кака муманя";
	new Profile(user).ProfileUser = userResult;

	UserResult userResult2 = new Profile(user).ProfileUser;
	Console.WriteLine($"Профиль {userResult2.IdRoleNavigation.Name}a:");
	Console.WriteLine($"Имя {userResult2.Name}");
	Console.WriteLine($"ID {userResult2.Id}");
	Console.WriteLine($"Почта {userResult2.Email}");
	Console.WriteLine($"Роль {userResult2.IdRoleNavigation.Name}");


Console.ReadLine();