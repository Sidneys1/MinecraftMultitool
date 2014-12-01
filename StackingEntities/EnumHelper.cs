using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace StackingEntities
{
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