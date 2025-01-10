
using DataIntegration.Interface.InterfaceOfModel;
using DomainModel.Integration.CanvasOperation;
using DomainModel.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Logic.CanvasLogic.VersionProjectOperate
{
	public class LikesOfVersionService : ILikesOfVersitonService
	{
		private IDataBaseModel _data;
		private int UserId { get; set; }
		public LikesOfVersionService(IDataBaseModel dataBase, IHttpContextAccessor httpContext)
		{
			_data = dataBase;
			UserId = int.Parse(httpContext.HttpContext.User.Claims.First(e => e.Type == ClaimTypes.Sid).Value);
		}
		public async Task<int> CouintLikes(int versionId)
		{
			return await _data.LikeOfVersionProjects.Where(e => e.VersionProjectId == versionId).CountAsync();
		}

		public async Task<bool> IsLike(int versionId)
		{
			if (await _data.LikeOfVersionProjects.FirstOrDefaultAsync(e => e.VersionProjectId == versionId && e.UserId == UserId) != null)
			{
				return true;
			}
			return false;
		}

		public async Task Like(int versionId)
		{
			try
			{
				await _data.LikeOfVersionProjects.AddAsync(GetLike(versionId));
				await _data.SaveChangesAsync();
			}
			catch { }
		}

		public async Task UnLike(int versionId)
		{
			try
			{
				_data.LikeOfVersionProjects.Remove(GetLike(versionId));
				await _data.SaveChangesAsync();
			}
			catch { }

		}

		private LikeOfVersionProject GetLike(int versionId)
		{
			return new LikeOfVersionProject()
			{
				VersionProjectId = versionId,
				UserId = UserId
			};
		}
	}
}
