
using DomainModel.Integration.Canvas;
using DomainModel.ResultsRequest;
using Logic.Interface;

namespace Logic.CanvasLogic
{
	public class FabricCanvasOperation : IFabricCanvasOperation
	{
		public IAdderCanvas CreateAdderCanvas(UserResult user)
		{
			throw new NotImplementedException();
		}

		public IEditerCanvas CreateEditerCanvas(UserResult user)
		{
			throw new NotImplementedException();
		}

		public IGetterCanvas CreateGetterCanvas(UserResult user)
		{
			throw new NotImplementedException();
		}
	}
}
