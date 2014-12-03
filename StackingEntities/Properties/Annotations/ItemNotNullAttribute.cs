using System;
using System.Diagnostics;

namespace StackingEntities.Desktop.Properties.Annotations
{
	/// <summary>
	/// Indicates that collection or enumerable value does not contain null elements
	/// </summary>
	[AttributeUsage(
		AttributeTargets.Method | AttributeTargets.Parameter | AttributeTargets.Property |
		AttributeTargets.Delegate | AttributeTargets.Field)]
	[Conditional("JETBRAINS_ANNOTATIONS")]
	public sealed class ItemNotNullAttribute : Attribute { }
}