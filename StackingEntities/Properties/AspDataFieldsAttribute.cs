using System;
using System.Diagnostics;

namespace StackingEntities.Annotations
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Method)]
	[Conditional("JETBRAINS_ANNOTATIONS")]
	public class AspDataFieldsAttribute : Attribute { }
}