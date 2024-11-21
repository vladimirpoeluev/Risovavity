using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;
using InteractiveApiRisovaviti.ControllerIntegration;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.CanvasOperate;

public class GetterImageProject : IGetterImageProject
{
	IGetAutoControllerIntegraion _getter;

	public GetterImageProject(IAuthenticationUser user)
	{
		_getter = new GetAutoControllerIntegraion(user);
	}

	public async Task<ImageResult> GetImageResult(int idProject)
	{
		return await _getter.GetResultAsync<ImageResult>($"api/ImageProject/get/{idProject}");
	}
}
