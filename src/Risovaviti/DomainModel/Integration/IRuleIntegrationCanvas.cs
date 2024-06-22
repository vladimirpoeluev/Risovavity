using DomainModel.Records;

namespace DomainModel.Integration
{
    public interface IRuleIntegrationCanvas
    {
        bool Add(Canvas canvas);
        bool Remove(Canvas canvas);
        bool Update(Canvas canvas, Canvas newCanvas);
        Canvas Get(int id);
        Canvas[] Get();
    }
}
