using System.Collections.ObjectModel;
using System.Text;
using StackingEntities.Model.Interface;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Items.ItemTags
{
	public class ItemTagsEnchantments : IJsonAble
	{
		[EntityDescriptor("Enchanting","Enchantments")]
		public ObservableCollection<Enchantment> Ench { get; set; } = new ObservableCollection<Enchantment>();

		[EntityDescriptor("Enchanting", "Book Enchantments")]
		public ObservableCollection<Enchantment> StoredEnchantments {get; set; }= new ObservableCollection<Enchantment>();

		[EntityDescriptor("Enchanting", "Repair Cost")]
		public int RepairCost { get; set; }

		public string GenerateJson(bool topLevel = true)
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
					b.AppendFormat("{0}:{{{1}}}", index, storedEnchantment.GenerateJson(false));
				}
			}

			if (Ench.Count <= 0) return b.ToString();

			b.Append("ench:[");

			for (var index = 0; index < Ench.Count; index++)
			{
				var enchantment = Ench[index];
				b.AppendFormat("{0}:{{{1}}}", index, enchantment.GenerateJson(false));
			}

			b.Append("],");

			return b.ToString();
		}
	}
}