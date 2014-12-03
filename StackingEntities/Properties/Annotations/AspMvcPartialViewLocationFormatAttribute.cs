using System;
using System.Diagnostics;

namespace StackingEntities.Desktop.Properties.Annotations
{
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
	[Conditional("JETBRAINS_ANNOTATIONS")]
	public sealed class AspMvcPartialViewLocationFormatAttribute : Attribute
	{
		public AspMvcPartialViewLocationFormatAttribute(string format)
		{
			Format = format;
		}

		public string Format { get; private set; }
	}
}