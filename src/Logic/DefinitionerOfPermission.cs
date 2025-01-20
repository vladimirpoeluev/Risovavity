
using DomainModel.Integration;
using DomainModel.ResultsRequest;
using DomainModel.ResultsRequest.Canvas;

namespace Logic
{
	public class DefinitionerOfPermission : IDefinitionerOfPermission
	{
		public async Task<PermissionResult> GetPermissionAsync(UserResult user, CanvasResult canvas)
		{
			if(user.IdRoleNavigation.Name == "Adimin")
			{
				return new PermissionResult()
				{
					AddVerstion = true,
					Edit = true,
					Read = true,
				};
			}
			var result = new PermissionResult()
			{
				AddVerstion = true,
				Edit = false,
				Read = true,
			};
			if(user.Id == canvas.UserId)
			{
				result.Edit = true;
			}
			return result;
		}

		public async Task<PermissionResult> GetPermissionAsync(UserResult user, VersionProjectResult versionProject)
		{
			if (user.IdRoleNavigation.Name == "Adimin")
			{
				return new PermissionResult()
				{
					AddVerstion = null,
					Edit = true,
					Read = true,
				};
			}
			var result = new PermissionResult()
			{
				AddVerstion = null,
				Edit = false,
				Read = true,
			};
			if (user.Id == versionProject.AuthorId)
			{
				result.Edit = true;
			}
			return result;
		}
	}
}
