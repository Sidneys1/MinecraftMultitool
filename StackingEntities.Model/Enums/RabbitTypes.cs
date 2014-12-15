using System.ComponentModel;

namespace StackingEntities.Model.Enums
{
	public enum RabbitTypes
	{
		[Description("Any")]
		DontCare = -1,
		Brown,
		White,
		Black,
		[Description("Black & White")]
		BlackWhite,
		Gold,
		[Description("Salt & Pepper")]
		SaltPepper,
		[Description("Killer Bunny")]
		KillerBunny = 99
	}
}