using System.ComponentModel;

namespace StackingEntities.Model.Enums
{
	public enum SheepColors
	{
		[Description("Random")]
		DontCare =-1,
		Black = 15,
		Red = 14,
		Green = 13,
		Brown = 12,
		Blue = 11,
		Purple = 10,
		Cyan = 9,
		[Description("Light Gray")]
		LightGray = 8,
		Gray = 7,
		Pink = 6,
		Lime = 5,
		Yellow = 4,
		[Description("Light Blue")]
		LightBlue = 3,
		Magenta = 2,
		Orange = 1,
		White = 0
	}
}