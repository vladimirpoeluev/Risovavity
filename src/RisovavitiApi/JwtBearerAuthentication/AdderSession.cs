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
			string token = string.Empty;	
			string refreshToken = string.Empty;

			return (token, refreshToken);
		}
	}
}
