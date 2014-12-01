using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace StackingEntities
{
	static internal class Helpers
	{
		public static string GetPropertyDisplayName(object descriptor)
		{

			var pd = descriptor as PropertyDescriptor;
			if (pd != null)
			{
				// Check for DisplayName attribute and set the column header accordingly
				var displayName = pd.Attributes[typeof(DisplayNameAttribute)] as DisplayNameAttribute;
				if (displayName != null && !Equals(displayName, DisplayNameAttribute.Default))
				{
					return displayName.DisplayName;
				}

			}
			else
			{
				var pi = descriptor as PropertyInfo;
				if (pi == null) return null;
				// Check for DisplayName attribute and set the column header accordingly
				var attributes = pi.GetCustomAttributes(typeof(DisplayNameAttribute), true);
				return (from t in attributes select t as DisplayNameAttribute into displayName where displayName != null && !Equals(displayName, DisplayNameAttribute.Default) select displayName.DisplayName).FirstOrDefault();
			}
			return null;
		}

		public static IEnumerable<PropertyInfo> GetPropertiesSorted(this Type type)
		{
			var properties = new List<PropertyInfo>();
			while (type != null)
			{
				properties.AddRange(type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance));
				type = type.BaseType;
			}
			return properties;
		}
	}

	public class DisplayOption
	{
		public DisplayOption(string rName, string pName, Type pType, Object dContext, object min = null, object max = null, bool mLine = false, string epName = null, bool fSize = false, string dgRowPath = null)
		{
			ReadableName = rName;
			PropertyName = pName;
			PropertyType = pType;
			DataContext = dContext;

			Minimum = min;
			Maximum = max;
			Multiline = mLine;

			EnabledPropertyName = epName;

			FixedSize = fSize;

			DataGridRowHeaderPath = dgRowPath;
		}

		public string DataGridRowHeaderPath { get; set; }

		public bool FixedSize { get; set; }

		public string ReadableName { get; set; }

		public string PropertyName { get; set; }

		public Type  PropertyType { get; set; }

		public object Minimum { get; set; }

		public object Maximum { get; set; }

		public bool Multiline { get; set; }

		public object DataContext { get; set; }

		public string EnabledPropertyName { get; set; }
	}

	public class SimpleDouble
	{
		public SimpleDouble(string name = null)
		{
			Name = name;
		}

		[DisplayName("Value")]
		public double Value { get; set; }

		public string Name { get; set; }
	}

}