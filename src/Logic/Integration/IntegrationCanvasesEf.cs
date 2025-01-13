

using DataIntegration.Model;
using DomainModel.Integration;
using DomainModel.Model;

namespace Logic.Integration
{
	public class IntegrationCanvasesEf : IRuleIntegrationCanvas
	{
		private DatabaseContext DatabaseContext { get; set; }
		public IntegrationCanvasesEf(DatabaseContext databaseContext) 
		{ 
			DatabaseContext = databaseContext;
		}

		public bool Add(Canvas canvas)
		{
			DatabaseContext.Canvas.Add(canvas);
			DatabaseContext.SaveChanges();
			return true;
		}

		public Canvas Get(int id)
		{
			return DatabaseContext.Canvas.Where((canvas) => canvas.Id == id).Single();
		}

		public IEnumerable<Canvas> Get()
		{
			return DatabaseContext.Canvas;
		}

		public bool Remove(Canvas canvas)
		{
			DatabaseContext.Canvas.Remove(canvas);
			return true;
		}

		public bool Update(Canvas canvas, Canvas newCanvas)
		{
			DatabaseContext.Canvas.Update(newCanvas);
			DatabaseContext.SaveChanges();
			return true;
		}
	}
}
