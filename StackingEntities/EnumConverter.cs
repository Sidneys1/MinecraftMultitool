using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Markup;

namespace StackingEntities
{
	public class EnumerationExtension : MarkupExtension
	{
		private Type _enumType;


		public EnumerationExtension(Type enumType)
		{
			if (enumType == null)
				throw new ArgumentNullException("enumType");

			EnumType = enumType;
		}

		public Type EnumType
		{
			get { return _enumType; }
			private set
			{
				if (_enumType == value)
					return;

				var enumType = Nullable.GetUnderlyingType(value) ?? value;

				if (enumType.IsEnum == false)
					throw new ArgumentException("Type must be an Enum.");

				_enumType = value;
			}
		}

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			var enumValues = Enum.GetValues(EnumType);

			return (
			  from object enumValue in enumValues
			  select new EnumerationMember
			  {
				  Value = enumValue,
				  Description = GetDescription(enumValue)
			  }).ToArray();
		}

		private string GetDescription(object enumValue)
		{
			var descriptionAttribute = EnumType
			  .GetField(enumValue.ToString())
			  .GetCustomAttributes(typeof(DescriptionAttribute), false)
			  .FirstOrDefault() as DescriptionAttribute;


			return descriptionAttribute != null
			  ? descriptionAttribute.Description
			  : enumValue.ToString();
		}

		public class EnumerationMember
		{
			public string Description { get; set; }
			public object Value { get; set; }
		}
	}

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

public static class EnumHelper
{
	/// <summary>
	/// Gets the description of a specific enum value.
	/// </summary>
	public static string Description(this Enum eValue)
	{
		var nAttributes = eValue.GetType().GetField(eValue.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);

		if (!nAttributes.Any())
		{
			// If no description is found, best guess is to generate it by replacing underscores with spaces
			// and title case it. You can change this to however you want to handle enums with no descriptions.
			var oTi = CultureInfo.CurrentCulture.TextInfo;
			return oTi.ToTitleCase(oTi.ToLower(eValue.ToString().Replace("_", " ")));
		}

		var descriptionAttribute = nAttributes.First() as DescriptionAttribute;
		return descriptionAttribute != null ? descriptionAttribute.Description : string.Empty;
	}

	/// <summary>
	/// Returns an enumerable collection of all values and descriptions for an enum type.
	/// </summary>
	public static IEnumerable<ValueDescription> GetAllValuesAndDescriptions<TEnum>() where TEnum : struct, IConvertible, IComparable, IFormattable
	{
		if (!typeof(TEnum).IsEnum)
			throw new ArgumentException("TEnum must be an Enumeration type");

		return Enum.GetValues(typeof(TEnum)).Cast<Enum>().Select(e => new ValueDescription { Value = e, Description = e.Description() }).ToList();
	}
}

public class ValueDescription
{
	public Enum Value { get; set; }
	public string Description { get; set; }
}