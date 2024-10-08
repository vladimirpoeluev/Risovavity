﻿
using DomainModel.Model;

namespace DomainModel.ResultsRequest;

public class UserResult
{
	public int Id { get; set; }

	public string Name { get; set; } = null!;

	public string Email { get; set; } = null!;

	public virtual RoleResult IdRoleNavigation { get; set; } = null!;

	public User GetUserObject()
	{
		return new User()
		{
			Id = Id,
			Name = Name,
			Email = Email,
			Role = IdRoleNavigation?.GetRoleObjection() ?? new Role() { Id = 0, Name = "Ошибка опознания роли"},
			IdRole = IdRoleNavigation?.Id ?? 0
		};
	}

	public static UserResult CreateResultFromUser(User user)
	{
		return new UserResult()
		{
			Id = user?.Id ?? 0,
			Name = user?.Name ?? "Отсутствует",
			Email = user?.Email ?? "Отсутствует",
			IdRoleNavigation = RoleResult.CreateRoleResultFromRole(user?.Role ?? new Role())
		};

	}
}
