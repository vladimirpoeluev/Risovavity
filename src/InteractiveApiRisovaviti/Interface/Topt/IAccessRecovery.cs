using DomainModel.ResultsRequest.TotpModels;

namespace InteractiveApiRisovaviti.Interface.Topt;

public interface IAccessRecovery
{
	Task<IEditPasswordForRecovery> Recovery(CodeToptConfirmationResult codeTopt);
}