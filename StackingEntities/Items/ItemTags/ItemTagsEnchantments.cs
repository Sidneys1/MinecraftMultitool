using System.Collections.Generic;
using System.Text;

namespace StackingEntities.Items.ItemTags
{
	public class ItemTagsEnchantments : IJsonAble
	{
		[Property("Enchanting","Enchantments")]
		public List<Enchantment> Ench { get; set; } = new List<Enchantment>();

		[Property("Enchanting", "Book Enchantments")]
		public List<Enchantment> StoredEnchantments {get; set; }= new List<Enchantment>();

		[Property("Enchanting", "Repair Cost")]
		public int RepairCost { get; set; }

		public string GenerateJSON(bool topLevel = true)
		{
			var b = new StringBuilder();

			if (RepairCost != 0)
				b.AppendFormat("RepairCost:{0},", RepairCost);

			if (StoredEnchantments.Count > 0)
			{
				b.Append("StoredEnchantments:[");

				for (var index = 0; index < StoredEnchantments.Count; index++)
				{
					var storedEnchantment = StoredEnchantments[index];
					b.AppendFormat("{0}:{{{1}}}", index, storedEnchantment.GenerateJSON(false));
				}
			}

			if (Ench.Count <= 0) return b.ToString();

			b.Append("ench:[");

			for (var index = 0; index < Ench.Count; index++)
			{
				var enchantment = Ench[index];
				b.AppendFormat("{0}:{{{1}}}", index, enchantment.GenerateJSON(false));
			}

			return b.ToString();
		}
	}
}