using DomainModel.Model;
using DomainModel.ResultsRequest;

namespace DomainModel.Integration
{
	public interface IPasswordEditer
	{
		User User { get; set; }
		Task PasswordEditAsync(EditProfileResult editResult);
	}
}
