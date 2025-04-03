using DataIntegration.Model;
using DomainModel.Integration;
using DomainModel.Model;
using DomainModel.ResultsRequest;
using Logic.Interface;
using Microsoft.EntityFrameworkCore;

namespace Logic;

public class PasswordEditer : IPasswordEditer
{
	public User User { get; set; } = new();
	DatabaseContext _db;
	IGeneraterHash _hash;

	public PasswordEditer(DatabaseContext context, IGeneraterHash generater)
	{
		_db = context;
		_hash = generater;
	}

	public async Task PasswordEditAsync(EditPasswordResult editResult)
	{
		await VerificationData(editResult);

		User oldUser = await _db.Users.Where((user) => user.Id == User.Id).FirstAsync();

		oldUser.Password = _hash.Generate(editResult.NewPassword);
		_db.Entry(oldUser).State = EntityState.Modified;
		await _db.SaveChangesAsync();
	}

	async Task VerificationData(EditPasswordResult editResult)
	{
		await CheckUser();
		VerifyPassword(editResult);
	}

	async Task CheckUser()
	{
		try
		{
			await _db.Users.Where((user) => user.Id == User.Id).FirstAsync();
		}
		catch 
		{
			throw new Exception("Пользователь не найден");
		}
	}

	void VerifyPassword(EditPasswordResult editProfileResult)
	{
		if (!_hash.Verify(editProfileResult.OldPassword, User.Password))
			throw new Exception("Пароль был введен неверно");
	}

	public async Task PasswordEditAsync(EditNewPasswordResul editResult)
	{
		await _db.Users.Where(user => User.Id == user.Id)
			.ExecuteUpdateAsync((d) => d.SetProperty((user) => user.Password, _hash.Generate(editResult.Password)));
	}
}
