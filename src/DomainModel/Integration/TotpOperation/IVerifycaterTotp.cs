namespace DomainModel.Integration.TotpOperation
{
	public interface IVerifycaterTotp
	{
		Task<bool> VerifycaterTotpAsync(int id, string code);
	}
}
