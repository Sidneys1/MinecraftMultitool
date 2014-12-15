using System;
using System.Diagnostics;

namespace StackingEntities.Model.Properties.Annotations
{
	[AttributeUsage(AttributeTargets.Method)]
	[Conditional("JETBRAINS_ANNOTATIONS")]
	public sealed class RazorHelperCommonAttribute : Attribute { }
}