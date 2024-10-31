

using System.Collections.Generic;

namespace AvaloniaRisovaviti.Validaters
{
	internal interface IValidaterPassword
	{
		bool IsValid { get; }
		IEnumerable<string> Error { get; }
	}
}
