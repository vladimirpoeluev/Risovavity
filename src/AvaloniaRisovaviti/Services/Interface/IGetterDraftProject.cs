using AvaloniaRisovaviti.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AvaloniaRisovaviti.Services.Interface
{
    internal interface IGetterDraftProject
    {
        Task<DraftModel> GetDraftModel(Guid guid);
        Task<IEnumerable<Guid>> GetGuids();
        void OpenForEdit(Guid guid);
    }
}