using System;
using System.Diagnostics;

namespace StackingEntities.Model.Annotations
{
	/// <summary>
	/// Indicates that IEnumerable, passed as parameter, is not enumerated.
	/// </summary>
	[AttributeUsage(AttributeTargets.Parameter)]
	[Conditional("JETBRAINS_ANNOTATIONS")]
	public sealed class NoEnumerationAttribute : Attribute { }
}