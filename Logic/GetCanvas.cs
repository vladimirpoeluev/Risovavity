using DomainModel.Model;
using Logic.Interface;
using DomainModel.Integration;
using System;

namespace Logic
{
    public class GetCanvas : IGetCanvas, IGetCanvasAsync
	{
		IRuleIntegrationCanvas _integrationCanvas;

		public GetCanvas(IRuleIntegrationCanvas integrationCanvas) 
		{
			_integrationCanvas = integrationCanvas;
		}

		public IEnumerable<Canvas> Get()
		{
			IEnumerable<Canvas> result = _integrationCanvas.Get();
			if (result.Count() == 0)
				throw new Exception();
			return result;
		}

		public Canvas Get(int id)
		{
			return _integrationCanvas.Get(id);
		}

		public async Task<IEnumerable<Canvas>> GetAsync()
		{
			return await Task.Run<IEnumerable<Canvas>>(() =>
			{
				return Get();
			});
		}

		public Task<Canvas> GetAsync(string id)
		{
			throw new NotImplementedException();
		}
	}
}
