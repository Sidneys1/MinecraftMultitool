using System.ComponentModel;

namespace StackingEntities.Model.Enums
{
	public enum JsonTextClickEvent
	{
		// ReSharper disable InconsistentNaming
		[Description("None/Inherit")]
		None,
		[Description("Open URL")]
		open_url,
		[Description("Run Command")]
		run_command,
		[Description("Change Page")]
		change_page,
		[Description("Suggest Command")]
		suggest_command
		// ReSharper restore InconsistentNaming
	}
}