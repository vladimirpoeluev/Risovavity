
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;
using InteractiveApiRisovaviti.ControllerIntegration;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.CanvasOperate;
public class GetterVersionProjectByParent : IGetterVersionByParentVersion
{
	IGetAutoControllerIntegraion _controller;
	public int Skip { get; set; } = 0;
	public int Take { get; set; } = 50;

	public GetterVersionProjectByParent(IAuthenticationUser user)
	{
		_controller = new GetAutoControllerIntegraion(user);
	}

	internal GetterVersionProjectByParent(IGetAutoControllerIntegraion controller)
	{
		_controller = controller;
	}

	public async Task<IEnumerable<VersionProjectResult>> GetVersionsByParent(VersionProjectResult parent)
	{
		return await _controller.GetResultAsync<IEnumerable<VersionProjectResult>>($"api/VersionProject/get/versions/{parent.Id}?skip={Skip}&take={Take}");
	}
}