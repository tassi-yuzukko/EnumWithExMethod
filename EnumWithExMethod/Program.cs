using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EnumWithExMethod
{
    class Program
    {
        static void Main(string[] args)
		{
			Console.OutputEncoding = Encoding.UTF8;

			//var type = typeof(Color);
			//var getFieldsTypes = type.GetFields().Where(fi => fi.FieldType == type);

			//foreach(var field in getFieldsTypes)
			//{
			//	Console.WriteLine(field.ToString());
			//}

			foreach(Color elem in Enum.GetValues(typeof(Color)))
			{
				Console.WriteLine(elem.ToJpnName());
				Console.WriteLine(elem.ToRgb());
				Console.WriteLine(elem.ToHex());
			}
		}
    }
}