using DomainModel.ResultsRequest;
using Logic.Interface;

namespace RisovavitiApi.JwtBearerAuthentication
{
	public class AdderSession
	{
		IInputerSystem GenerateAccertToken { get; set; }
		IInputerSystem GenerateRefreshToken { get; set; }

		public AdderSession(IInputerSystem generateAccertToken, IInputerSystem generateRefreshToken)
		{
			GenerateAccertToken = generateAccertToken;
			GenerateRefreshToken = generateRefreshToken;
		}

		public (string token, string refreshToken) GenerateSession(UserResult user)
		{
			string token = GenerateAccertToken.InputUser(new DomainModel.Model.User()
			{
				Id = user.Id,
				Name = user.Name,
				IdRole = user.IdRoleNavigation.Id
			});	
			string refreshToken = GenerateRefreshToken.InputUser(new DomainModel.Model.User()
			{
				Id = user.Id,
				Name = user.Name,
				IdRole = user.IdRoleNavigation.Id
			});

			return (token, refreshToken);
		}
	}
}
