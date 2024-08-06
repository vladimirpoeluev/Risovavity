using DomainModel.Records;

namespace DomainModel.Integration
{
    public interface IRuleIntegrationStatus
    {
        Status[] Get();
        Status Get(int id);
    }
}
