using System.ComponentModel;

namespace StackingEntities.Model.Enums
{
	public enum AttributeModifierOperation
	{
		[Description("+- Amount")]
		Add,
		[Description("+- Amount % (Additive)")]
		AddPercent,
		[Description("+- Amount % (Multiplicitive)")]
		AddPercentMult
	}
}