using System;
using System.Diagnostics;

namespace StackingEntities.Model.Annotations
{
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
	[Conditional("JETBRAINS_ANNOTATIONS")]
	public sealed class RazorImportNamespaceAttribute : Attribute
	{
		public RazorImportNamespaceAttribute(string name)
		{
			Name = name;
		}

		public string Name { get; private set; }
	}
}