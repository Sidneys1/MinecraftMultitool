using System.ComponentModel;

namespace StackingEntities.Model.Enums
{
	public enum JsonTextHoverEvent
	{
		[Description("None/Inherit")]
		None,
		[Description("Show Text")]
		ShowText,
		[Description("Show Item")]
		ShowItem,
		[Description("Show Achievement")]
		ShowAchievement,
		[Description("Show Entity")]
		ShowEntity
	}
}