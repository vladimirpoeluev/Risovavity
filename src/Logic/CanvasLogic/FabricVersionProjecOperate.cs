
using DataIntegration.Model;
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest;
using Logic.CanvasLogic.VersionProjectOperate;
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
			return new AdderVertionProject(_db, user);
		}

		public IGetterVersionProject CreateGetter(UserResult user)
		{
			return new GetterVersionCanvas(_db);
		}
	}
}
