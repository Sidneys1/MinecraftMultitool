using System;
using System.Diagnostics;

namespace StackingEntities.Desktop.Properties.Annotations
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Method)]
	[Conditional("JETBRAINS_ANNOTATIONS")]
	public class AspDataFieldAttribute : Attribute { }
}