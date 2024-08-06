using DomainModel.Model;

namespace Logic.Interface
{
    public interface IGetCanvasAsync
    {
        Task<IEnumerable<Canvas>> GetAsync();
        Task<Canvas> GetAsync(string id);
    }
}