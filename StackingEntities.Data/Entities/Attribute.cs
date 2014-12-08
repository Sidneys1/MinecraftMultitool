using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using StackingEntities.Model.Helpers;
using StackingEntities.Model.Interface;

namespace StackingEntities.Model.Entities
{
	public class Attribute : IJsonAble
	{
		[DisplayName(@"Name")]
		public AttributeType Name { get; set; }

		[DisplayName(@"Base Value")]
		public double Base { get; set; }

		public ObservableCollection<AttributeModifier> Modifiers { get; } = new ObservableCollection<AttributeModifier>();

		public string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder();

			b.AppendFormat("Name:\"{0}\",Base:{1:0.0}", Name.Description(), Base);

			if (Modifiers.Count <= 0) return b.ToString();

			b.Append("Modifiers:[");
			for (var i = 0; i < Modifiers.Count; i++)
			{
				b.AppendFormat("{0}:{{{1}}},", i, Modifiers[i].GenerateJson(false));
			}
			b.Remove(b.Length - 1, 1);
			b.Append("]");


			return b.ToString();
		}
	}

	public class AttributeModifier :IJsonAble
	{
		public string Name { get; set; } = string.Empty;

		public double Amount { get; set; }

		public AttributeModifierOperation Operation { get; set; }

		public string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder("");

			if (!string.IsNullOrWhiteSpace(Name))
				b.AppendFormat("Name:\"{0}\",", Name.EscapeJsonString());

			b.AppendFormat("Amount:{0:0.0#},", Amount);

			b.AppendFormat("Operation:{0:D}", Operation);

			return b.ToString();
		}
	}

	public enum AttributeModifierOperation
	{
		[Description("+- Amount")]
		Add,
		[Description("+- Amount % (Additive)")]
		AddPercent,
		[Description("+- Amount % (Multiplicitive)")]
		AddPercentMult
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
