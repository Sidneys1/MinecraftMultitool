using System.ComponentModel;

namespace StackingEntities.Model.Enums
{
	public enum SkullType
	{
		Inherit=-1,
		Skeleton,
		[Description("Wither Skeleton")]
		WitherSkeleton,
		Zombie,
		Player,
		Creeper
	}
}