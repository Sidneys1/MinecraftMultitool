using System.ComponentModel;

namespace StackingEntities.Model.Enums
{
	public enum HorseType
	{
		Default,
		Horse,
		Donkey,
		Mule,
		[Description("Undead Horse")]
		UndeadHorse,
		[Description("Skeleton Horse")]
		SkeletonHorse
	}
}