using System;
using System.Diagnostics;

namespace StackingEntities.Desktop.Properties.Annotations
{
	/// <summary>
	/// Indicates that parameter is regular expression pattern.
	/// </summary>
	[AttributeUsage(AttributeTargets.Parameter)]
	[Conditional("JETBRAINS_ANNOTATIONS")]
	public sealed class RegexPatternAttribute : Attribute { }
}