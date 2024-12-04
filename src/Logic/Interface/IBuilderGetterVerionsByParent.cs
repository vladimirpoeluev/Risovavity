using DomainModel.Integration.CanvasOperation;
using Logic.CanvasLogic;

namespace Logic.Interface
{
    public interface IBuilderGetterVerionsByParent
    {
        BuilderGetterVerionsByParent Skip(int skip);
        BuilderGetterVerionsByParent Take(int take);
        IGetterVersionByParentVersion ToGetter();
    }
}