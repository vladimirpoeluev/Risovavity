
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest;

namespace Logic.Interface
{
    public interface IFabricCanvasOperation
    {
        IGetterCanvas CreateGetterCanvas(UserResult user);
        IEditerCanvas CreateEditerCanvas(UserResult user);
		IAdderCanvas CreateAdderCanvas(UserResult user);
	}
}
