using System;
using System.Diagnostics;

namespace StackingEntities.Annotations
{
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
	[Conditional("JETBRAINS_ANNOTATIONS")]
	public sealed class AspMvcViewLocationFormatAttribute : Attribute
	{
		public AspMvcViewLocationFormatAttribute(string format)
		{
			Format = format;
		}

		public string Format { get; private set; }
	}
}