using System;

namespace StackingEntities
{
	[AttributeUsage(AttributeTargets.Property)]
	public class PropertyAttribute : Attribute
	{
		public readonly string Category, Name;

		public PropertyAttribute(string category, string name)
		{
			Category = category;
			Name = name;
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
	{
		
	}
}
