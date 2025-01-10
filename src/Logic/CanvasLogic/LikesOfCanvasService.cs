
using DataIntegration.Interface.InterfaceOfModel;
using DomainModel.Integration.CanvasOperation;
using DomainModel.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Logic.CanvasLogic
{
	public class LikesOfCanvasService : ILikesOfCanvasService
	{
		private IDataBaseModel _data;
		private int UserId { get; set; }
		public LikesOfCanvasService(IDataBaseModel dataBase, IHttpContextAccessor httpContext) 
		{
			_data = dataBase;
			UserId = int.Parse(httpContext.HttpContext.User.Claims.First(e => e.Type == ClaimTypes.Sid).Value);
		}
		public async Task<int> CouintLikes(int canvasId)
		{
			return await _data.LikeOfCanvas.Where(e => e.CanvasId == canvasId).CountAsync();
		}

		public async Task<bool> IsLike(int canvasId)
		{
			if(await _data.LikeOfCanvas.FirstOrDefaultAsync(e => e.CanvasId == canvasId && e.UserId == UserId) != null)
			{
				return true;
			}
			return false;
		}

		public async Task Like(int canvasId)
		{
			try
			{
				await _data.LikeOfCanvas.AddAsync(GetLike(canvasId));
				await _data.SaveChangesAsync();
			}
			catch { }
		}

		public async Task UnLike(int canvasId)
		{
			try
			{
				_data.LikeOfCanvas.Remove(GetLike(canvasId));
				await _data.SaveChangesAsync();
			}
			catch { }
			
		}

		private LikeOfCanvas GetLike(int canvasId)
		{
			return new LikeOfCanvas()
			{
				CanvasId = canvasId,
				UserId = UserId
			};
		}
	}
}
