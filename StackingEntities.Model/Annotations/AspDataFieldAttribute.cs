using System;
using System.Diagnostics;

namespace StackingEntities.Model.Annotations
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Method)]
	[Conditional("JETBRAINS_ANNOTATIONS")]
	public class AspDataFieldAttribute : Attribute { }
}