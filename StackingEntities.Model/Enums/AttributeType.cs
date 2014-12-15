using System.ComponentModel;

namespace StackingEntities.Model.Enums
{
	public enum AttributeType
	{
		[Description("generic.maxHealth")]
		GenericMaxHealth,
		[Description("generic.followRange")]
		GenericFollowRange,
		[Description("generic.knockbackResistance")]
		GenericKnockbackResistance,
		[Description("generic.movementSpeed")]
		GenericMovementSpeed,
		[Description("generic.attackDamage")]
		GenericAttackDamage,

		[Description("horse.jumpStrength")]
		HorseJumpStrength,

		[Description("zombie.spawnReinforcements")]
		ZombieSpawnReinforcements
	}
}
