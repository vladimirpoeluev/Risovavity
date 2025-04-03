using DomainModel.ResultsRequest;

namespace InteractiveApiRisovaviti.Interface.Topt
{
	public interface IEditPasswordForRecovery
	{
		Task EditPassword(EditNewPasswordResul passwordForm);
	}
}
