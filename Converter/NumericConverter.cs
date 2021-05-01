using ConverterApp.ConverterFactory;
using System;
using System.Diagnostics.Contracts;

namespace Converter
{
	/// <summary>
	/// Numeric Converter provides conversions between different units. Most commonly used prefices are supported.
	/// </summary>
	public static class NumericConverter
	{
		/// <summary>
		/// Converts units of length
		/// </summary>
		/// <param name="from">Contains numeric value and units from which to convert separated by space. Units are provided in singular form</param>
		/// <param name="to">Contains to which conversion is done. Should contain units in singular form</param>
		/// <returns>String desribing the result of conversion</returns>
		public static string ConvertLength(string from, string to)
		{
			if (String.IsNullOrEmpty(from) || String.IsNullOrEmpty(to))
			{
				throw new ArgumentException("Please provide correct arguments.");
			}

			try
			{
				var converter = ConverterFactory.GetConverter(ConverterType.Length);
				return converter.Convert(from, to);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			
		}

		/// <summary>
		/// Converts units of data
		/// </summary>
		/// <param name="from">Contains numeric value and units from which to convert separated by space. Units are provided in singular form</param>
		/// <param name="to">Contains to which conversion is done. Should contain units in singular form</param>
		/// <returns>String desribing the result of conversion</returns>
		public static string ConvertData(string from, string to)
		{
			if (String.IsNullOrEmpty(from) || String.IsNullOrEmpty(to))
			{
				throw new ArgumentException("Please provide correct arguments.");
			}

			try
			{
				var converter = ConverterFactory.GetConverter(ConverterType.Data);
				return converter.Convert(from, to);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
