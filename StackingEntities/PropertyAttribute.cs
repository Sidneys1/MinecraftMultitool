using System;

namespace StackingEntities
{
	[AttributeUsage(AttributeTargets.Property)]
	public class PropertyAttribute : Attribute
	{
		public readonly string Category, Name, IsEnabledPath, DataGridRowHeaderPath;

		public readonly bool FixedSize;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="category">The GroupBox this will be listed in</param>
		/// <param name="name">The readable name of this option</param>
		/// <param name="isEnabledPath">Optional: name of parameter that specifies if this option is enabled</param>
		/// <param name="fixedSize">Whether or not a List is of a fixed length.</param>
		/// <param name="dgRowPath">The path to the row header of a List displayed in a GridView</param>
		public PropertyAttribute(string category, string name, string isEnabledPath = null, bool fixedSize = false, string dgRowPath = null)
		{
			Category = category;
			Name = name;
			IsEnabledPath = isEnabledPath;
			FixedSize = fixedSize;
			DataGridRowHeaderPath = dgRowPath;
		}
	}

	[AttributeUsage(AttributeTargets.Property)]
	public class MinMaxAttribute : Attribute
	{
		public readonly object Minimum, Maximum;

		public MinMaxAttribute(object minimum, object maximum)
		{
			Minimum = minimum;
			Maximum = maximum;
		}
	}

	[AttributeUsage(AttributeTargets.Property)]
	public class MultilineStringAttribute : Attribute
	{}
}
