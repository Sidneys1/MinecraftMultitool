using System;
using System.ComponentModel;

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
			throw new NotImplementedException();
		}
	}

	public enum AttributeType
	{
		generic_maxHealth,
		generic_followRange,
		generic_knockbackResistance,
		generic_movementSpeed,
		generic_attackDamage,

		horse_jumpStrength,

		zombie_spawnReinforcements
	}
}
