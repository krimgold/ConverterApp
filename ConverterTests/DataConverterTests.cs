using Converter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConverterTests
{
	[TestClass]
	public class DataConverterTests
	{
		[TestMethod]
		public void ConvertSameUnitsWithOnePrefix_ShouldNotFail()
		{
			var result = NumericConverter.ConvertData("1 byte", "terabyte");
			Assert.AreEqual(result, "0.000000000001 terabyte");
		}

		[TestMethod]
		public void ConvertSameUnitsWithTwoPrefixes_ShouldNotFail()
		{
			var result = NumericConverter.ConvertData("1 kilobyte", "terabyte");
			Assert.AreEqual(result, "0.000000001 terabyte");
		}

		[TestMethod]
		public void ConvertDifferentUnitsWithTwoPrefixes_ShouldNotFail()
		{
			var result = NumericConverter.ConvertData("13.2 kilobit", "gigabyte");
			Assert.AreEqual(result, "0.00000165 gigabyte");
		}

		[TestMethod]
		public void ConvertNulls_ShouldFail()
		{
			Assert.ThrowsException<ArgumentException>(() => NumericConverter.ConvertData(null, null));
		}


		[TestMethod]
		public void ConvertEmptyStrings_ShouldFail()
		{
			Assert.ThrowsException<ArgumentException>(() => NumericConverter.ConvertData("", ""));
		}

		[TestMethod]
		public void ConvertIncorrectNumber_ShouldFail()
		{
			Assert.ThrowsException<ArgumentException>(() => NumericConverter.ConvertData("abc bit", "byte"));
		}

		[TestMethod]
		public void ConvertIncorrectUnits_ShouldFail()
		{
			Assert.ThrowsException<ArgumentException>(() => NumericConverter.ConvertData("12.3 abc", "bit"));
		}

		[TestMethod]
		public void ConvertIncorrectPrefix_ShouldFail()
		{
			Assert.ThrowsException<ArgumentException>(() => NumericConverter.ConvertData("12 superbit", "byte"));
		}
	}
}
