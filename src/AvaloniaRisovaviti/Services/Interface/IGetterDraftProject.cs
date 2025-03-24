using AvaloniaRisovaviti.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AvaloniaRisovaviti.Services.Interface
{
    public interface IGetterDraftProject
    {
        Task<DraftModel> GetDraftModel(Guid guid);
        Task<IEnumerable<Guid>> GetGuids();
        Task<IEnumerable<string>> GetImagesByProject(Guid guid);
		void OpenForEdit(Guid guid);
        void OpenForEdit(Guid guid, string namaImage);
    }
}