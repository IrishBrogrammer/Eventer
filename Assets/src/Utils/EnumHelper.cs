using System;

namespace ExtensionMethods
{
	public static class EnumExtensions
	{
		// Convert a string to an enum. Uses reflection. If speed is important better to use
		// a Dictionary<string,Enum>  for lookup
		public static T ToEnum<T>(this string value)
		{
			return (T)Enum.Parse(typeof(T), value, true);
		}
	}
}
