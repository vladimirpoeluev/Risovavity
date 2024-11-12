
using DataIntegration.Model;
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest;
using Logic.Interface;

namespace Logic.CanvasLogic
{
	public class FabricVersionProjecOperate : IFabricOperateVersionProject
	{
		DatabaseContext _db;
		public FabricVersionProjecOperate(DatabaseContext db) 
		{
			_db = db;
		}

		public IAdderVersionProject CreateAdder(UserResult user)
		{
			throw new NotImplementedException();
		}

		public IGetterVersionProject CreateGetter(UserResult user)
		{
			throw new NotImplementedException();
		}
	}
}
