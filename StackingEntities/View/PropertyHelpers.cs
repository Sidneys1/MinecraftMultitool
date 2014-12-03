using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace StackingEntities.View
{
	public static class PropertyHelpers
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
}