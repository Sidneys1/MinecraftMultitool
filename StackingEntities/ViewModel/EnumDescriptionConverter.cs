using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;

namespace StackingEntities.ViewModel
{
	public class EnumDescriptionConverter : IValueConverter
	{
		private static string GetEnumDescription(Enum enumObj)
		{
			var fieldInfo = enumObj.GetType().GetField(enumObj.ToString());

			var attribArray = fieldInfo.GetCustomAttributes(false);

			if (attribArray.Length == 0)
				return enumObj.ToString();

			var attrib = attribArray[0] as DescriptionAttribute;
			return attrib != null ? attrib.Description : "";
		}

		object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var myEnum = (Enum)value;
			var description = GetEnumDescription(myEnum);
			return description;
		}

		object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return string.Empty;
		}
	}
}
