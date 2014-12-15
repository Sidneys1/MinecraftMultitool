using System;
using System.ComponentModel;

namespace StackingEntities.Model.Items.ItemTags
{
	[Serializable]
	public enum FireworkShape
	{
		[Description("Small Ball")]
		SmallBall,
		[Description("Large Ball")]
		LargeBall,
		Star,
		Creeper,
		Burst
	}
}