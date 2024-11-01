using DataIntegration.Model;
using DomainModel.Integration;
using DomainModel.Model;
using DomainModel.ResultsRequest;
using Logic.Interface;
using Microsoft.EntityFrameworkCore;

namespace Logic;
class PasswordEditer : IPasswordEditer
{
	public User User { get; set; } = new();
	DatabaseContext _db;
	IGeneraterHash _hash;

	public PasswordEditer(DatabaseContext context, IGeneraterHash generater)
	{
		_db = context;
		_hash = generater;
	}

	public async Task PasswordEditAsync(EditProfileResult editResult)
	{
		await VerificationData(editResult);
		User.Password = editResult.NewPassword;
		_db.Users.Update(User);
		await _db.SaveChangesAsync();
	}

	async Task VerificationData(EditProfileResult editResult)
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

	void VerifyPassword(EditProfileResult editProfileResult)
	{
		if (!_hash.Verify(editProfileResult.OldPassword, User.Password))
			throw new Exception("Пароль был введен неверно");
	}
}
