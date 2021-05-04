using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConverterApp.Converters
{
	class CommonConverter
	{
		private Dictionary<string, decimal> metricPrefices = new Dictionary<string, decimal>()
		{
			{ "tera", 1000000000000m },
			{ "giga", 1000000000m },
			{ "mega", 1000000m },
			{ "kilo", 1000m },
			{ "hecto", 100m },
			{ "deca", 10m },
			{ "deci", 0.1m },
			{ "centi", 0.01m },
			{ "milli", 0.001m },
			{ "micro", 0.000001m },
			{ "nano", 0.000000001m }
		};

		protected string GetConvertedValue(string from, string to, Dictionary<string, double> conversions)
		{
			if (conversions == null)
			{
				throw new ArgumentNullException("Please provide conversions.");
			}

			var fromArgs = from.Split(" ");

			if (fromArgs.Length != 2)
			{
				throw new ArgumentNullException("Please provide correct numeric value and units for conversion.");
			}

			var fromValue = fromArgs[0];
			var fromUnits = fromArgs[1];

			var fromNumericPrefix = GetNumericPrefix(fromUnits);
			var toNumericPrefix = GetNumericPrefix(to);

			var conversionRatio = GetRatio(fromUnits, to, conversions);

			var convertionResult = GetConversionResult(fromValue, conversionRatio, fromNumericPrefix, toNumericPrefix);

			return $"{convertionResult} {to}";
		}

		private decimal GetNumericPrefix(string units)
		{
			var prefix = GetMetricPrefix(units);

			var conversionRate = (String.IsNullOrEmpty(prefix) ? 1 : metricPrefices[prefix]);

			return conversionRate;
		}

		private double GetRatio(string fromUnits, string to, Dictionary<string, double> conversions)
		{
			var fromPrefix = GetMetricPrefix(fromUnits);
			var toPrefix = GetMetricPrefix(to);

			var fromBasicUnits = fromUnits.TrimStart(fromPrefix.ToCharArray());
			var toBasicUnits = to.TrimStart(toPrefix.ToCharArray());

			var fromTo = $"{fromBasicUnits} to {toBasicUnits}".ToLower();

			if (!conversions.TryGetValue(fromTo, out double ratio))
			{
				throw new ArgumentException($"Please provide correct conversion units. Cannot convert {fromTo}");
			}

			return ratio;
		}

		private string GetMetricPrefix(string metric)
		{
			foreach (KeyValuePair<string, decimal> entry in metricPrefices)
			{
				if (metric.Contains(entry.Key))
				{
					return entry.Key;
				}
			}

			return String.Empty;
		}

		private string GetConversionResult(string fromValue, double ratio, decimal fromPrefix, decimal toPrefix)
		{
			if (!double.TryParse(fromValue, out double convertedValue))
			{
				throw new ArgumentException("Please provide correct number of units to convert from.");
			}

			return ((decimal)convertedValue * fromPrefix * (decimal)ratio / toPrefix).ToString();
		}
	}
}
