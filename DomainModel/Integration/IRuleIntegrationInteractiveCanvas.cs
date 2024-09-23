

using DomainModel.Model;

namespace DomainModel.Integration
{
    internal interface IRuleIntegrationInteractiveCanvas
    {
        bool Add(InteractiveCanvas canvas);
        bool Remove(InteractiveCanvas canvas);
        bool Update(InteractiveCanvas canvas, InteractiveCanvas newCanvas);
        InteractiveCanvas Get(int id);
        InteractiveCanvas[] Get();
    }
}
