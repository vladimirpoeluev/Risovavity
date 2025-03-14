using AvaloniaRisovaviti.Model;
using System;
using System.Threading.Tasks;

namespace AvaloniaRisovaviti.Services.Interface
{
    internal interface IGetterDraftProject
    {
        Task<DraftModel> GetDraftModel(Guid guid);
        Task<Guid> GetGuids();
        Task OpenForEdit(Guid guid);
    }
}