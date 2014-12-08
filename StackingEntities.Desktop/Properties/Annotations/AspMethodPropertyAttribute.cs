using System;
using System.Diagnostics;

namespace StackingEntities.Desktop.Properties.Annotations
{
	[AttributeUsage(AttributeTargets.Property)]
	[Conditional("JETBRAINS_ANNOTATIONS")]
	public class AspMethodPropertyAttribute : Attribute { }
}