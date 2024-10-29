

namespace AvaloniaRisovaviti.Validaters
{
	internal interface IValidaterPassword
	{
		bool IsValid { get; }
		string Error { get; }
	}
}
