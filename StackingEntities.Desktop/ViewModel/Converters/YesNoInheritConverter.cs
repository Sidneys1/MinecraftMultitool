using System;
using System.Globalization;
using System.Windows.Data;

namespace StackingEntities.Desktop.ViewModel.Converters
{
	public class YesNoInheritConverter : IValueConverter
	{
		#region IValueConverter Members

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var inValue = (bool?)value;

			return inValue.HasValue ? (inValue.Value ? "Yes" : "No") : "Inherit";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
