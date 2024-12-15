

using DataIntegration.Model;
using DomainModel.Model;
using DomainModel.ResultsRequest;
using Logic.HashPassword;
using Logic.Interface;
using Microsoft.EntityFrameworkCore;

namespace Logic
{
    public class EntranceUser : IEntranceUser
	{
		DatabaseContext _db;
		IGeneraterHash _generater;

		public EntranceUser(DatabaseContext context, IGeneraterHash generater)
		{
			_db = context;
			_generater = generater;
		}

		public async Task<UserResult> Login(AuthenticationForm form)
		{
			User user = await _db.Users.Where((entity)
				=> entity.Login == form.Login
				&& _generater.Verify(form.Password, entity.Password))
				.FirstAsync();
			UserResult userResult = UserResult.CreateResultFromUser(user);
			return userResult;
		}

	}
}
