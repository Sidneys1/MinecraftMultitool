using System;
using System.Diagnostics;

namespace StackingEntities.Desktop.Properties.Annotations
{
	/// <summary>
	/// Indicates that the marked method unconditionally terminates control flow execution.
	/// For example, it could unconditionally throw exception
	/// </summary>
	[Obsolete("Use [ContractAnnotation('=> halt')] instead")]
	[AttributeUsage(AttributeTargets.Method)]
	[Conditional("JETBRAINS_ANNOTATIONS")]
	public sealed class TerminatesProgramAttribute : Attribute { }
}