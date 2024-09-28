using DataIntegration.Model;
using DomainModel.Model;
using Logic.Integration;

namespace TestRisovaviti.DataIntegration
{
	public class ModelEfUserTests
	{
		[Fact]
		public void TestEfUserRole()
		{
			var getUser = new IntegrationUsersEf();
			var expected = new Role() { Id = 1, Name = "Admin" };
			var result = getUser.Get(1);

			Assert.Equal(expected, result.Role);
		}

		[Fact]
		public void TestEfUserCanvas()
		{
			DatabaseContext ctx = new DatabaseContext();
			var expected = new InteractiveCanvas()
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
