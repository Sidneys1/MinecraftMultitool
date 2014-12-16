using System.ComponentModel;

namespace StackingEntities.Model.Enums
{
	public enum JsonTextColor
	{
		// ReSharper disable InconsistentNaming
		[Description("Default/Inherit")]
		Inherit,
		black,
		[Description("Dark Blue")]
		dark_blue,
		[Description("Dark Green")]
		dark_green,
		[Description("Dark Aqua")]
		dark_awua,
		[Description("Dark Red")]
		dark_red,
		[Description("Dark Purple")]
		dark_purple,
		gold,
		gray,
		[Description("Dark Grey")]
		dark_gray,
		blue,
		green,
		aqua,
		red,
		[Description("Light Purple")]
		light_purple,
		yellow,
		white,
		reset
		// ReSharper restore InconsistentNaming
	}
}