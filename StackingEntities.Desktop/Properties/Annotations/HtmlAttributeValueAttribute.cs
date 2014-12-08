using System;
using System.Diagnostics;

namespace StackingEntities.Desktop.Properties.Annotations
{
	[AttributeUsage(
		AttributeTargets.Parameter | AttributeTargets.Field | AttributeTargets.Property)]
	[Conditional("JETBRAINS_ANNOTATIONS")]
	public sealed class HtmlAttributeValueAttribute : Attribute
	{
		public HtmlAttributeValueAttribute([NotNull] string name)
		{
			Name = name;
		}

		[NotNull] public string Name { get; private set; }
	}
}