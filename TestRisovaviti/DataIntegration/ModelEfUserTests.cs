using DataIntegration.Model;
using DomainModel.Model;
using RisovavitiApi.Controllers;

namespace TestRisovaviti.DataIntegration
{
	public class ModelEfUserTests
	{
		[Fact]
		public void TestEfUserRole()
		{
			DatabaseContext context = new DatabaseContext();
			var expected = new Role() { Id = 1, Name = "Администратор" };
			var result = context.Users.FirstOrDefault();

			Assert.Equal(expected, result.Role);
		}

		[Fact]
		public void TestEfUserCanvas()
		{
			DatabaseContext ctx = new DatabaseContext();
			var expected = new InteractiveCanva()
			{
				Id = 1,
				Name = "Canvas1",
				Description = "Крутой холст для создания рисунков",
				ConnectionString = "uefwhqfo2379rhuaifew",
				IdStatus = 1,
				Author = 1
			};

			var result = ctx.Users.Single();
			var actual = result.InteractiveCanvas.FirstOrDefault();
			Assert.Equal(expected, actual);
		}
	}
}
