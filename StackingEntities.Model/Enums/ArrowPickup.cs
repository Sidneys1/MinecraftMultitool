using System.ComponentModel;

namespace StackingEntities.Model.Enums
{
	public enum ArrowPickup
	{
		[Description("Cannot be Picked Up")]
		NoPickup,
		[Description("Can be picked Up in Survival & Creative")]
		SurvivalCreative,
		[Description("Can be picked up in Creative")]
		Creative
	}
}