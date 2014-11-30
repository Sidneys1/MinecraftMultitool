using System;

namespace StackingEntities
{
	[AttributeUsage(AttributeTargets.Property)]
	public class PropertyAttribute : Attribute
	{
		public readonly string Category, Name, IsEnabledPath;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="category">The GroupBox this will be listed in</param>
		/// <param name="name">The readable name of this option</param>
		/// <param name="isEnabledPath">Optional: name of parameter that specifies if this option is enabled</param>
		public PropertyAttribute(string category, string name, string isEnabledPath = null)
		{
			Category = category;
			Name = name;
			IsEnabledPath = isEnabledPath;
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
