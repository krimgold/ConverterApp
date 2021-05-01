using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterApp.Converters
{
	class DataConverter : CommonConverter, IConverter
	{
		private Dictionary<string, double> conversions = new Dictionary<string, double>()
		{
			{ "byte to bit", 8 },
			{ "bit to byte", 0.125 },
			{ "bit to bit", 1 },
			{ "byte to byte", 1 }
		};

		public string Convert(string from, string to)
		{
			return GetConvertedValue(from, to, conversions);
		}
	}
}
