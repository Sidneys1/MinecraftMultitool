using System;
using System.Diagnostics;

namespace StackingEntities.Model.Annotations
{
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
	[Conditional("JETBRAINS_ANNOTATIONS")]
	public sealed class AspMvcAreaMasterLocationFormatAttribute : Attribute
	{
		public AspMvcAreaMasterLocationFormatAttribute(string format)
		{
			Format = format;
		}

		public string Format { get; private set; }
	}
}