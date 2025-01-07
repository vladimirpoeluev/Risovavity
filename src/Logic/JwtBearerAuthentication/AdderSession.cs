using DomainModel.ResultsRequest;
using Logic.Interface;
using Logic.JwtBearerAuthentication.Interface;

namespace Logic.JwtBearerAuthentication
{
    public class AdderSession : IAdderSession
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
			string refreshToken = GenerateRefreshToken.InputUser(new DomainModel.Model.User()
			{
				Id = user.Id,
				Name = user.Name,
				IdRole = user.IdRoleNavigation.Id
			});
			if (GenerateRefreshToken is IGeneraterAccessByRefresh)
			{
				var generater = (IGeneraterAccessByRefresh)GenerateRefreshToken;
				generater.GetAccessToken(GenerateAccertToken);
			}

			string token = GenerateAccertToken.InputUser(new DomainModel.Model.User()
			{
				Id = user.Id,
				Name = user.Name,
				IdRole = user.IdRoleNavigation.Id
			});

			return (token, refreshToken);
		}
	}
}
