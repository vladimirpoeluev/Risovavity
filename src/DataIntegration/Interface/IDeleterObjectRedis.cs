using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Interface
{
	public interface IDeleterObjectRedis
	{
		Task DeleteObject(string key);
	}
}
