using static Logic.SingleSaveUserToken;

namespace Logic.Interface
{
    public interface ICreateSaverToken
    {
        public ISaverUserToken CreateSaver();
    }
}
