using System;

namespace StackingEntities
{
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
}