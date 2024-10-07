using DomainModel.Model;

namespace DomainModel.Integration
{
    public interface IRuleIntegrationStatus
    {
        Status[] Get();
        Status Get(int id);
    }
}
