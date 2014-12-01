using System.ComponentModel;
using System.Text;

namespace StackingEntities.Entities
{
	public class Attribute : IJsonAble
	{
		[DisplayName(@"Name")]
		public AttributeType Name { get; set; }

		[DisplayName(@"Base Value")]
		public double Base { get; set; }


		public string GenerateJSON(bool topLevel)
		{
			var b = new StringBuilder();

			b.AppendFormat("Name:\"{0}\",Base:{1:0.0}", Name.Description(), Base);

			return b.ToString();
		}
	}

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
