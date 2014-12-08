using System;
using System.Diagnostics;
using StackingEntities.Desktop.Desktop.Annotations;

namespace StackingEntities.Desktop.Properties.Annotations
{
	/// <summary>
	/// Indicates how method invocation affects content of the collection
	/// </summary>
	[AttributeUsage(AttributeTargets.Method)]
	[Conditional("JETBRAINS_ANNOTATIONS")]
	public sealed class CollectionAccessAttribute : Attribute
	{
		public CollectionAccessAttribute(CollectionAccessType collectionAccessType)
		{
			CollectionAccessType = collectionAccessType;
		}

		public CollectionAccessType CollectionAccessType { get; private set; }
	}
}