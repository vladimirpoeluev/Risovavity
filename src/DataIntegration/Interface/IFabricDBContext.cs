using DataIntegration.Model;

namespace DataIntegration.Interface
{
    public interface IFabricDBContext
    {
        DatabaseContext CreateContext();
    }
}
