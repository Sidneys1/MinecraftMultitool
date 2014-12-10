using System;
using System.ComponentModel;
using System.Text;
using StackingEntities.Model.Interface;

namespace StackingEntities.Model.Entities.Mobs
{
	[Serializable]
	public class PotionEffect :IJsonAble
	{
		[DisplayName(@"Type")]
		public EffectId Id { get; set; }

		[DisplayName(@"Level (0=I)")]
		public byte Amplifier { get; set; }

		[DisplayName(@"Duration (Ticks)")]
		public int Duration { get; set; }

		[DisplayName(@"From Beacon")]
		public bool Ambient { get; set; } = false;

		[DisplayName(@"Particles")]
		public bool ShowParticles { get; set; } = true;

		public string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder();

			b.AppendFormat("Id:{0:D}b,", Id);

			b.AppendFormat("Amplifier:{0}b,", Amplifier);

			b.AppendFormat("Duration:{0},", Duration);

			b.AppendFormat("Ambient:{0}b,", Ambient ? "1" : "0");

			b.AppendFormat("ShowParticles:{0}b", ShowParticles ? "1" : "0");

			return b.ToString();
		}
	}

	public enum EffectId
	{
		Speed,
		Slowness,
		Haste,
		MiningFatigue,
		Strength,
		InstantHealth,
		InstantDamage,
		JumpBoost,
		Nausea,
		Regeneration,
		Resistance,
		FireResistance,
		WaterBreathing,
		Invisiblility,
		Blindness,
		NightVision,
		Hunger,
		Weakness,
		Poison,
		Wither,
		HealthBoost,
		Absorption,
		Saturation
	}
}
