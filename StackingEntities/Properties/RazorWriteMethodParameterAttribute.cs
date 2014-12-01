using System;
using System.Diagnostics;

namespace StackingEntities.Annotations
{
	[AttributeUsage(AttributeTargets.Parameter)]
	[Conditional("JETBRAINS_ANNOTATIONS")]
	public sealed class RazorWriteMethodParameterAttribute : Attribute { }
}