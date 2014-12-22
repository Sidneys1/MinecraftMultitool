using System;
using System.ComponentModel;
using System.Text;
using StackingEntities.Model.Enums;
using StackingEntities.Model.Interface;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Objects
{
	[Serializable]
	public class Enchantment:IJsonAble
	{
		[DisplayName(@"ID")]
		public EnchantmentId Type { get; set; }

		[DisplayName(@"Level"), MinMax(short.MinValue, short.MaxValue)]
		public int Level { get; set; } = 1;

		public string GenerateJson(bool topLevel = true)
		{
			var b = new StringBuilder();

			b.AppendFormat("id:{0:D}s,", Type);

			b.AppendFormat("lvl:{0}s", Level);
				
			return b.ToString();
		}
	}
}