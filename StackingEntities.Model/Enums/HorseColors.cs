using System.ComponentModel;

namespace StackingEntities.Model.Enums
{
	public enum HorseColors
	{
		White,
		Buckskin,
		[Description("Dark Bay")]
		DarkBay,
		Bay,
		Black,
		[Description("Dapple Gray")]
		DappleGray,
		[Description("Flaxen Chestnut")]
		FlaxenChestnut
	}
}