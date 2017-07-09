using System;
using System.Collections.Generic;
using System.Text;

namespace EnumWithExMethod
{
    public enum Color
    {
		[JapaneseAttribute("黒"), RgbAttribute(0x00, 0x00, 0x00), HexAttribute("FFFFFF")]
		Black,
		[JapaneseAttribute("白"), RgbAttribute(0xff, 0xff, 0xff), HexAttribute("000000")]
		White,
		[JapaneseAttribute("赤"), RgbAttribute(0xff, 0x00, 0x00), HexAttribute("FF0000")]
		Red,
    }

	[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
	public sealed class JapaneseAttribute : Attribute
	{
		public string Value { get; private set; }

		public JapaneseAttribute(string value)
		{
			Value = value;
		}
	}

	[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
	public sealed class RgbAttribute : Attribute
	{
		public int R { get; private set; }
		public int G { get; private set; }
		public int B { get; private set; }

		public RgbAttribute(int r, int g, int b)
		{
			R = r;
			G = g;
			B = b;
		}
	}

	[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
	public sealed class HexAttribute : Attribute
	{
		public string Value { get; private set; }

		public HexAttribute(string value)
		{
			Value = value;
		}
	}
}
