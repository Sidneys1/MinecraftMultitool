using System.ComponentModel;

namespace StackingEntities.Model.Enums
{
	public enum JsonTextClickEvent
	{
		[Description("None/Inherit")]
		None,
		[Description("Open URL")]
		OpenUrl,
		[Description("Run Command")]
		RunCommand,
		[Description("Change Page")]
		ChangePage,
		[Description("Suggest Command")]
		SuggestCommand
	}
}