using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace StackingEntities.Desktop.ViewModel.Converters
{
	public class EnumVisibilityConverter : IValueConverter
	{
		#region IValueConverter Members

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var parameterString = parameter as string;
			if (parameterString == null)
				return DependencyProperty.UnsetValue;

			if (Enum.IsDefined(value.GetType(), value) == false)
				return DependencyProperty.UnsetValue;

			var invert = false;
			if (parameterString.StartsWith("!"))
			{
				invert = true;
				parameterString = parameterString.Remove(0, 1);
			}

			var parameterValue = Enum.Parse(value.GetType(), parameterString);

			var match = parameterValue.Equals(value);

			if (invert)
				match = !match;

			return match ? Visibility.Visible : Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var parameterString = parameter as string;
			return parameterString == null ? DependencyProperty.UnsetValue : Enum.Parse(targetType, parameterString);
		}

		#endregion
	}

}
