using DomainModel.Model;
using Logic.Interface;

namespace Logic
{
    public class SingleSaveUserToken : ICreateSaverToken
	{ 
		private static readonly ISaverUserToken instance = new SaverUserToken();

		public ISaverUserToken CreateSaver()
		{
			return instance;
		}

		public class SaverUserToken : ISaverUserToken
		{
			Dictionary<Guid, User> tokens;

			public SaverUserToken()
			{
				tokens = new Dictionary<Guid, User>();
			}

			public User Get(Guid token)
			{
				return tokens[token];
			}

			public void Add(User user, Guid token)
			{
				tokens[token] = user;
			}
		}
	}

}
