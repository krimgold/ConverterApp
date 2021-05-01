using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterApp.Converters
{
	interface IConverter
	{
		public string Convert(string from, string to);
	}
}
