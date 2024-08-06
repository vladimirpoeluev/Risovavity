using DomainModel.Model;

namespace Logic.Interface
{
	internal interface IGetCanvas
	{
		IEnumerable<Canvas> Get();
		Canvas Get(int id);
	}
}
