using System.ComponentModel;

namespace StackingEntities.Model.Enums
{
	public enum PotionEffectId
	{
		Inherit=-1,
		None,
		Speed,
		Slowness,
		Haste,
		[Description("Mining Fatigue")]
		MiningFatigue,
		Strength,
		[Description("Instant Health")]
		InstantHealth,
		[Description("Instant Damage")]
		InstantDamage,
		[Description("Jump Boost")]
		JumpBoost,
		Nausea,
		Regeneration,
		Resistance,
		[Description("Fire Resistance")]
		FireResistance,
		[Description("Water Breathing")]
		WaterBreathing,
		Invisiblility,
		Blindness,
		[Description("Night Vision")]
		NightVision,
		Hunger,
		Weakness,
		Poison,
		Wither,
		[Description("Health Boost")]
		HealthBoost,
		Absorption,
		Saturation
	}
}
