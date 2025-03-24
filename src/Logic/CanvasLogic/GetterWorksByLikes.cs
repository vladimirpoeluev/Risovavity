using DataIntegration.Interface;
using DataIntegration.Model;
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

namespace Logic.CanvasLogic;
public class GetterWorksByLikes : IGetterWorksByLikes
{
	IFabricDBContext _fabricDB;
	public GetterWorksByLikes(IFabricDBContext fabricDB) 
	{
		_fabricDB = fabricDB;
	}
	public async Task<IEnumerable<CanvasResult>> GetCanvas(int userId, RangeTakeAndSkip range)
	{
		DatabaseContext context = _fabricDB.CreateContext();
		return await context.LikeOfCanvas.Include(u => u.Canvas)
					.Where(u => u.UserId == userId).Skip(range.Skip).Take(range.Take)
					.Select(e => new CanvasResult(e.Canvas)).ToListAsync();
	}

	public async Task<IEnumerable<VersionProjectResult>> GetVersionProject(int userId, RangeTakeAndSkip range)
	{
		DatabaseContext context = _fabricDB.CreateContext();
		return await context.LikeOfVersionProjects.Include(u => u.VersionProject)
					.Where(u => u.UserId == userId).Skip(range.Skip).Take(range.Take)
					.Select(e => new VersionProjectResult(e.VersionProject)).ToListAsync();
	}