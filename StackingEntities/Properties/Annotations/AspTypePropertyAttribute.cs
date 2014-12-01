using System;
using System.Diagnostics;

namespace StackingEntities.Properties.Annotations
{
	[AttributeUsage(AttributeTargets.Property)]
	[Conditional("JETBRAINS_ANNOTATIONS")]
	public class AspTypePropertyAttribute : Attribute
	{
		public bool CreateConstructorReferences { get; private set; }

		public AspTypePropertyAttribute(bool createConstructorReferences)
		{
			CreateConstructorReferences = createConstructorReferences;
		}
	}
}