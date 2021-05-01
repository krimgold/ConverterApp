using ConverterApp.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterApp.ConverterFactory
{
	static class ConverterFactory
	{
		public static IConverter GetConverter(ConverterType type)
		{
			switch (type)
			{
				case ConverterType.Length:
					return new LengthConverter();
				case ConverterType.Data:
					return new DataConverter();
				default:
					throw new ArgumentException("Pleasde provide correct type of converter.");
			}
		}
	}
}
