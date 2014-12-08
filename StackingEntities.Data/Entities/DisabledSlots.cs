using System;
using System.ComponentModel;

namespace StackingEntities.Model.Entities
{
	[Flags]
	internal enum DisabledSlots
	{
		None = 0,
		Remove = 1,
		Replace = 2,
		Place = 4,
		[Description("Remove & Replace")]
		RemoveReplace = 3,
		[Description("Remove & Place")]
		RemovePlace = 5,
		[Description("Replace and Place")]
		ReplacePlace = 6,
		All = 7
	}
}