using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EnumWithExMethod
{
    public static class ColorExtensions
    {
		private static Dictionary<Color, RgbAttribute> rgbCache;
		private static Dictionary<Color, HexAttribute> hexCache;
		private static Dictionary<Color, JapaneseAttribute> jpnCache;

		static ColorExtensions()
		{
			// Enumから属性と値を取り出す。
			// この部分は汎用的に使えるようユーティリティクラスに隔離してもいいかもですね。
			var type = typeof(Color);
			var lookup = type.GetFields()
				.Where(fi => fi.FieldType == type)		// 純粋なEnum定数のみにフィルタリングする。GetFields()しただけでは、「Int32」とかいうゴミが残るため。←何者か要検索
				.SelectMany(fi => fi.GetCustomAttributes(false),	
					(fi, Attribute) => new { Color = (Color)fi.GetValue(null), Attribute })
				.ToLookup(a => a.Attribute.GetType());

			// キャッシュに突っ込む
			jpnCache = lookup[typeof(JapaneseAttribute)].ToDictionary(a => a.Color, a => (JapaneseAttribute)a.Attribute);
			hexCache = lookup[typeof(HexAttribute)].ToDictionary(a => a.Color, a => (HexAttribute)a.Attribute);
			rgbCache = lookup[typeof(RgbAttribute)].ToDictionary(a => a.Color, a => (RgbAttribute)a.Attribute);
		}

		public static string ToJpnName(this Color color)
		{
			return jpnCache[color].Value;
		}

		public static string ToHex(this Color color)
		{
			return hexCache[color].Value;
		}

		public static string ToRgb(this Color color)
		{
			var rgb = rgbCache[color];
			return string.Format("{0:D3}{1:D3}{2:D3}", rgb.R, rgb.G, rgb.B);
		}
	}
}
