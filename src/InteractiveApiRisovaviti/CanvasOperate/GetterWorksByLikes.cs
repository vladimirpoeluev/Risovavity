using DomainModel;
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;
using InteractiveApiRisovaviti.ControllerIntegration;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.CanvasOperate;
public class GetterWorksByLikes : IGetterWorksByLikes
{
	FabricAutoControllerIntegraion _fabricAuto;
	IAuthenticationUser _user;
	public GetterWorksByLikes(FabricAutoControllerIntegraion fabricAuto, IAuthenticationUser user) 
	{
		_fabricAuto = fabricAuto;
		_user = user;
	}
	public async Task<IEnumerable<CanvasResult>> GetCanvas(int userId, RangeTakeAndSkip range)
	{
		IGetAutoControllerIntegraion get = _fabricAuto.CreateGetPatser(_user);
		return await get.GetResultAsync<IEnumerable<CanvasResult>>($"api/liked/canvas/{userId}?Skip={range.Skip}&Take={range.Take}");
	}

	public async Task<IEnumerable<VersionProjectResult>> GetVersionProject(int userId, RangeTakeAndSkip range)
	{
		IGetAutoControllerIntegraion get = _fabricAuto.CreateGetPatser(_user);
		return await get.GetResultAsync<IEnumerable<VersionProjectResult>>($"api/liked/version/{userId}?Skip={range.Skip}&Take={range.Take}");
	}
}