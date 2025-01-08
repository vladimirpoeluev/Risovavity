
using DataIntegration.Interface.InterfaceOfModel;
using DomainModel.Integration.CanvasOperation;
using DomainModel.Model;
using DomainModel.ResultsRequest.Canvas;
using Microsoft.EntityFrameworkCore;

namespace Logic.CanvasLogic.VersionProjectOperate
{
	public class EditerVersitonProject : IEditVersionProject
	{
		IVersionsProjectsDataBase _versionProjectData;
		public EditerVersitonProject(IVersionsProjectsDataBase verstionProjectData) 
		{
			_versionProjectData = verstionProjectData;
		}
		public async Task Edit(VerstionProjectEditResutl newVersionProject)
		{
			VersionProject version = await _versionProjectData.VersionsProjects.FirstAsync(entity => entity.Id == newVersionProject.VerstionId);
			version.Description = newVersionProject.DescriptionEdit;
			version.Name = newVersionProject.NameEdit;
		}
	}
}
