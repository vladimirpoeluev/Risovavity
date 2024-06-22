namespace TestRisovaviti
{
    using RisovavitiApi;
    using Logic;
    using DomainModel.Records;
    using System.Net.Http.Headers;

    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Role role = new Role(1, "Администратор");
            Role role2 = new Role(1, "Администратор");

            Assert.Equal(role, role2, Comparer.Get<Role>((a, b) => a.Name == b.Name && a.Id == b.Id));

        }
    }
}