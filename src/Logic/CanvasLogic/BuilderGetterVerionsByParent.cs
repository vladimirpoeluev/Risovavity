
using DataIntegration.Model;
using DomainModel.Integration.CanvasOperation;
using Logic.CanvasLogic.VersionProjectOperate;
using Logic.Interface;

namespace Logic.CanvasLogic
{
    public class BuilderGetterVerionsByParent : IBuilderGetterVerionsByParent
	{
		private GetterVersionsByParent _getterVesionsByParent;
		public BuilderGetterVerionsByParent(DatabaseContext databaseContext)
		{
			_getterVesionsByParent = new GetterVersionsByParent(databaseContext);
		}

		public BuilderGetterVerionsByParent Skip(int skip)
		{
			_getterVesionsByParent.Skip = skip;
			return this;
		}

		public BuilderGetterVerionsByParent Take(int take)
		{
			_getterVesionsByParent.Take = take;
			return this;
		}

		public IGetterVersionByParentVersion ToGetter() => _getterVesionsByParent;
	}
}
