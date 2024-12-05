using DomainModel.Integration.CanvasOperation;
using InteractiveApiRisovaviti.CanvasOperate;

namespace InteractiveApiRisovaviti.Interface
{
    public interface IGetterProjectByParentBuilder
    {
        IGetterVersionByParentVersion Build();
        GetterProjectByParentBuilder SetSkip(int skip);
        GetterProjectByParentBuilder SetTake(int take);
    }
}