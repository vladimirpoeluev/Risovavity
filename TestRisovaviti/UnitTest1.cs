namespace TestRisovaviti
{
    using DomainModel.Model;

    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Role role = new Role();
            Role role2 = new Role();

            Assert.Equal(role, role2, Comparer.Get<Role>((a, b) => a.Name == b.Name && a.Id == b.Id));

        }
    }
}