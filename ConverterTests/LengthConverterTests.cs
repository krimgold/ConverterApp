using Converter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConverterTests
{
	[TestClass]
	public class LengthConverterTests
	{
		[TestMethod]
		public void ConvertSameUnitsWithOnePrefix_ShouldNotFail()
		{
			var result = NumericConverter.ConvertLength("1 meter", "centimeter");
			Assert.AreEqual(result, "100 centimeter");
		}

		[TestMethod]
		public void ConvertSameUnitsWithTwoPrefixes_ShouldNotFail()
		{
			var result = NumericConverter.ConvertLength("2.8 decimeter", "kilometer");
			Assert.AreEqual(result, "0.00028 kilometer");
		}

		[TestMethod]
		public void ConvertDifferentUnitsWithTwoPrefixes_ShouldNotFail()
		{
			var result = NumericConverter.ConvertLength("1.5 decimeter", "kilofoot");
			Assert.AreEqual(result, "0.000492126 kilofoot");
		}

		[TestMethod]
		public void ConvertFootToFoot_ShouldNotFail()
		{
			var result = NumericConverter.ConvertLength("1 decifoot", "kilofoot");
			Assert.AreEqual(result, "0.0001 kilofoot");
		}

		[TestMethod]
		public void ConvertNulls_ShouldFail()
		{
			Assert.ThrowsException<ArgumentException>(() => NumericConverter.ConvertLength(null, null));
		}


		[TestMethod]
		public void ConvertEmptyStrings_ShouldFail()
		{
			Assert.ThrowsException<ArgumentException>(() => NumericConverter.ConvertLength("", ""));
		}

		[TestMethod]
		public void ConvertIncorrectNumber_ShouldFail()
		{
			Assert.ThrowsException<ArgumentException>(() => NumericConverter.ConvertLength("abc inch", "foot"));
		}

		[TestMethod]
		public void ConvertIncorrectUnits_ShouldFail()
		{
			Assert.ThrowsException<ArgumentException>(() => NumericConverter.ConvertLength("12 abc", "foot"));
		}

		[TestMethod]
		public void ConvertIncorrectPrefix_ShouldFail()
		{
			Assert.ThrowsException<ArgumentException>(() => NumericConverter.ConvertLength("12 superinch", "foot"));
		}
	}
}
