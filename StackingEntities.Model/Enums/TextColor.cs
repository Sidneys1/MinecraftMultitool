using System.ComponentModel;

namespace StackingEntities.Model.Enums
{
	public enum TextColor
	{
		[Description("Default/Inherit")]
		Inherit,
		Black,
		[Description("Dark Blue")]
		DarkBlue,
		[Description("Dark Green")]
		DarkGreen,
		[Description("Dark Aqua")]
		DarkAqua,
		[Description("Dark Red")]
		DarkRed,
		[Description("Dark Purple")]
		DarkPurple,
		Gold,
		Gray,
		[Description("Dark Grey")]
		DarkGray,
		Blue,
		Green,
		Aqua,
		Red,
		[Description("Light Purple")]
		LightPurple,
		Yellow,
		White,
		Reset
	}
}