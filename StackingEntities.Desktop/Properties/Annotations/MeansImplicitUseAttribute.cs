using System;
using System.Diagnostics;
using StackingEntities.Desktop.Desktop.Annotations;

namespace StackingEntities.Desktop.Properties.Annotations
{
	/// <summary>
	/// Should be used on attributes and causes ReSharper
	/// to not mark symbols marked with such attributes as unused
	/// (as well as by other usage inspections)
	/// </summary>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.GenericParameter)]
	[Conditional("JETBRAINS_ANNOTATIONS")]
	public sealed class MeansImplicitUseAttribute : Attribute
	{
		public MeansImplicitUseAttribute() 
			: this(ImplicitUseKindFlags.Default, ImplicitUseTargetFlags.Default) { }

		public MeansImplicitUseAttribute(ImplicitUseKindFlags useKindFlags)
			: this(useKindFlags, ImplicitUseTargetFlags.Default) { }

		public MeansImplicitUseAttribute(ImplicitUseTargetFlags targetFlags)
			: this(ImplicitUseKindFlags.Default, targetFlags) { }

		public MeansImplicitUseAttribute(
			ImplicitUseKindFlags useKindFlags, ImplicitUseTargetFlags targetFlags)
		{
			UseKindFlags = useKindFlags;
			TargetFlags = targetFlags;
		}

		[UsedImplicitly] public ImplicitUseKindFlags UseKindFlags { get; private set; }
		[UsedImplicitly] public ImplicitUseTargetFlags TargetFlags { get; private set; }
	}
}