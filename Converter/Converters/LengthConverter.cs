

using System;
using System.Collections.Generic;

namespace ConverterApp.Converters
{
	class LengthConverter : CommonConverter, IConverter
	{
		private Dictionary<string, double> conversions = new Dictionary<string, double>()
		{
			{ "meter to foot", 3.28084 },
			{ "meter to inch", 39.3701 },
			{ "meter to meter", 1 },
			{ "foot to inch", 12 },
			{ "foot to meter", 0.3048 },
			{ "foot to foot", 1 },
			{ "inch to foot", 0.0833 },
			{ "inch to meter", 0.0254 },
			{ "inch to inch", 1 }
		};

		public string Convert(string from, string to)
		{
			return GetConvertedValue(from, to, conversions);
		}
	}
}
