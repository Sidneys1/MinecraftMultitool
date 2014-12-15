using System;
using System.ComponentModel;

namespace StackingEntities.Model.Items.ItemTags
{
	[Flags,Serializable]
	public enum DisplayHideFlags
	{
		None = 0,
		Enchantments = 1,
		[Description("Attribute Modifiers")]
		AttribueModifiers = 2,
		Unbreakable = 4,
		[Description("Can Destroy")]
		CanDestroy = 8,
		[Description("Can Place On")]
		CanPlaceOn = 16,
		Other = 32
	}
}