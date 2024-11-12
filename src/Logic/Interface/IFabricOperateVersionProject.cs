
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest;

namespace Logic.Interface
{
    public interface IFabricOperateVersionProject
    {
        IAdderVersionProject CreateAdder(UserResult user);
        IGetterVersionProject CreateGetter(UserResult user);
    }
}
