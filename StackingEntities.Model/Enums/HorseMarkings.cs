using System.ComponentModel;

namespace StackingEntities.Model.Enums
{
	public enum HorseMarkings
	{
		None,
		[Description("Stockings & Blaze")]
		StockingsAndBlaze,
		[Description("Snowflake Appaloosa")]
		SnowflakeAppaloosa,
		Paint,
		Sooty
	}
}