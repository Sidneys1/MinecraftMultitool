using System;
using System.Diagnostics;

namespace StackingEntities.Model.Properties.Annotations
{
	/// <summary>
	/// When applied to a target attribute, specifies a requirement for any type marked
	/// with the target attribute to implement or inherit specific type or types.
	/// </summary>
	/// <example><code>
	/// [BaseTypeRequired(typeof(IComponent)] // Specify requirement
	/// public class ComponentAttribute : Attribute { }
	/// [Component] // ComponentAttribute requires implementing IComponent interface
	/// public class MyComponent : IComponent { }
	/// </code></example>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	[BaseTypeRequired(typeof(Attribute))]
	[Conditional("JETBRAINS_ANNOTATIONS")]
	public sealed class BaseTypeRequiredAttribute : Attribute
	{
		public BaseTypeRequiredAttribute([NotNull] Type baseType)
		{
			BaseType = baseType;
		}

		[NotNull] public Type BaseType { get; private set; }
	}
}