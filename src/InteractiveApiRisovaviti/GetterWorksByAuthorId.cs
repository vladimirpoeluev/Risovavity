
using DomainModel.Integration;
using DomainModel.ResultsRequest.Canvas;
using InteractiveApiRisovaviti.ControllerIntegration;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti
{
	public class GetterWorksByAuthorId : IGetterWorkByAuthorId
	{
		private IGetAutoControllerIntegraion _metodGet;
		public GetterWorksByAuthorId(FabricAutoControllerIntegraion fabric, IAuthenticationUser user) 
		{
			_metodGet = fabric.CreateGetPatser(user);
		}
		public async Task<IEnumerable<CanvasResult>> GetCanvasByAuthorId(int id, int skip, int take)
		{
			return _metodGet.GetResult<IEnumerable<CanvasResult>>($"api/canvas/get/by-auhtorid/{id}?skip={skip}&take={take}");
		}

		public async Task<IEnumerable<VersionProjectResult>> GetVersionProjectResultsByAuthorId(int id, int skip, int take)
		{
			return _metodGet.GetResult<IEnumerable<VersionProjectResult>>($"api/VersionProject/get/by-auhtorid/{id}?skip={skip}&take={take}");
		}
	}
}
