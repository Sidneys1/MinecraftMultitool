using System.ComponentModel;

namespace StackingEntities.Model.Enums
{
	public enum JsonTextHoverEvent
	{
		// ReSharper disable InconsistentNaming
		[Description("None/Inherit")]
		None,
		[Description("Show Text")]
		show_text,
		[Description("Show Item")]
		show_item,
		[Description("Show Achievement")]
		show_achievement,
		[Description("Show Entity")]
		show_entity
		// ReSharper restore InconsistentNaming
	}
}