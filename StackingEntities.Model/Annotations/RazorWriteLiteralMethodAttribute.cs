using System;
using System.Diagnostics;

namespace StackingEntities.Model.Annotations
{
	[AttributeUsage(AttributeTargets.Method)]
	[Conditional("JETBRAINS_ANNOTATIONS")]
	public sealed class RazorWriteLiteralMethodAttribute : Attribute { }
}