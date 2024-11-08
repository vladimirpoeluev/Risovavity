using DataIntegration.Model;
using DomainModel.Integration.Canvas;
using DomainModel.ResultsRequest;
using DomainModel.ResultsRequest.Canvas;

namespace Logic.CanvasLogic
{
	public class AdderCanvas : IAdderCanvas
	{
		private DatabaseContext _context;
		private UserResult _userResult;

		public AdderCanvas(UserResult user, DatabaseContext context)
		{
			_context = context;
			_userResult = user;
		}

		public void AddCanvas(CanvasAddResult canvasAddResult)
		{
			
		}
	}
}
