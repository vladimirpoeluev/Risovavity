using DomainModel.Integration.CanvasOperation;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.CanvasOperate
{
    public class GetterProjectByParentBuilder : IGetterProjectByParentBuilder
	{
		GetterVersionProjectByParent _getterVersionsProjectByParent;
		public GetterProjectByParentBuilder(IAuthenticationUser user)
		{
			_getterVersionsProjectByParent = new GetterVersionProjectByParent(user);
		}

		public GetterProjectByParentBuilder SetSkip(int skip)
		{
			_getterVersionsProjectByParent.Skip = skip;
			return this;
		}

		public GetterProjectByParentBuilder SetTake(int take)
		{
			_getterVersionsProjectByParent.Take = take;
			return this;
		}

		public IGetterVersionByParentVersion Build() => _getterVersionsProjectByParent;
	}
}
