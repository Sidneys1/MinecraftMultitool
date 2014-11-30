﻿using System.ComponentModel;
using System.Text;

namespace StackingEntities.Items.ItemTags
{
	public class Enchantment:IJsonAble
	{
		[DisplayName(@"ID")]
		public EnchantmentId Type { get; set; }
		[DisplayName(@"Level"), MinMax(short.MinValue, short.MaxValue)]
		public int Level { get; set; }

		public string GenerateJSON(bool topLevel = true)
		{
			var b = new StringBuilder();

			b.AppendFormat("id:{0:D}s,", Type);

			b.AppendFormat("lvl:{0}s", Level);
				
			return b.ToString();
		}
	}

	public enum EnchantmentId
	{
		Protection = 0,
		[Description("Fire Protection")]
		FireProtection = 1,
		[Description("Feather Falling")]
		FeatherFalling = 2,
		[Description("Blast Protection")]
		BlastProtection = 3,
		[Description("Projectile Protection")]
		ProjectileProtection = 4,
		Respiration = 5,
		[Description("Aqua Affinity")]
		AquaAffinity = 6,
		Thorns = 7,
		[Description("Depth Strider")]
		DepthStrider = 8,

		Sharpness = 16,
		Smite = 17,
		[Description("Bane of Arthropods")]
		BaneOfArthropods = 18,
		Knockback = 19,
		[Description("Fire Aspect")]
		FireAspect = 20,
		Looting = 21,

		Efficiency = 32,
		[Description("Silk Touch")]
		SilkTouch  = 33,
		Unbreaking = 34,
		Fortune = 35,

		Power = 48,
		Punch = 49,
		Flame = 50,
		Infinity = 51,

		[Description("Luck of the Sea")]
		LuckOfTheSea = 61,
		Lure = 62
	}
}