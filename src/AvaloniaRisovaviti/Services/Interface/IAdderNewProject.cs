using AvaloniaRisovaviti.Model;
using System;
using System.Threading.Tasks;

namespace AvaloniaRisovaviti.Services.Interface
{
    internal interface IAdderNewProject
    {
        Task<Guid> AddProject(DraftModel draft);
    }
}