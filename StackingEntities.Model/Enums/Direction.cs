using System.ComponentModel;

namespace StackingEntities.Model.Enums
{
	public enum Direction
	{
		Inherit = -1,
		[Description("North")]
		north = 2,
		[Description("South")]
		south = 0,
		[Description("East")]
		east = 3,
		[Description("West")]
		west = 1
	}
}