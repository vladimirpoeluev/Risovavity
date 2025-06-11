using DomainModel.ResultsRequest.Error;

namespace InteractiveApiRisovaviti.Exceptions
{
	public class RequstException : Exception
	{
		public ErrorMessageRequest ErrorMessageRequest { get; set; }
		public string StatusCode { get; set; }
		public RequstException(ErrorMessageRequest errorMessage) 
		{
			ErrorMessageRequest = errorMessage;
		}
	}
}
