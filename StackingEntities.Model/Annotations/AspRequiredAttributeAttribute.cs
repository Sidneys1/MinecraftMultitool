using System;
using System.Diagnostics;

namespace StackingEntities.Model.Annotations
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	[Conditional("JETBRAINS_ANNOTATIONS")]
	public class AspRequiredAttributeAttribute : Attribute
	{
		public AspRequiredAttributeAttribute([NotNull] string attribute)
		{
			Attribute = attribute;
		}

		public string Attribute { get; private set; }
	}
}