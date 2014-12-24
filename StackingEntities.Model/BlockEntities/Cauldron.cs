using System;
using System.Linq;
using System.Text;
using StackingEntities.Model.BlockEntities.BaseClasses;
using StackingEntities.Model.Items;
using StackingEntities.Model.Metadata;
using ItemList = System.Collections.ObjectModel.ObservableCollection<StackingEntities.Model.Items.Item>;

namespace StackingEntities.Model.BlockEntities
{
	[Serializable]
	public class Cauldron : BlockEntityBase
	{
		#region Properties

		[EntityDescriptor("Brewing Stand Options", "Brew Time (Ticks)", "Number of Ticks the potions have been brewing for."), MinMax(0, int.MaxValue)]
		public int BrewTime { get; set; }

		[EntityDescriptor("Brewing Stand Options", "Ingredient Item", wide:true)]
		public Item IngredientItem { get; } = new Item {SlotTitle = "Ingredient Item", Slot = 0, SlotTagEnabled = false};

		[EntityDescriptor("Brewing Stand Options", "Output Items", fixedSize:true), MinMax(3, 1)]
		public ItemList Items { get; }  = new ItemList
		{
			new Item {Slot = 1, SlotTagEnabled = false, SlotTitle = "Output Slot 1"},
			new Item{Slot = 2, SlotTagEnabled = false, SlotTitle = "Output Slot 2"},
			new Item{Slot = 3, SlotTagEnabled = false, SlotTitle = "Output Slot 3"}
		};

		#endregion

		//public Cauldron()// : base("Cauldron") { }

		#region Inherited

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(false));

			if (BrewTime > 0)
				b.AppendFormat("BrewTime:{0},", BrewTime);

			var items = new string[4];

			var s = IngredientItem.GenerateJson(false);
			if (!string.IsNullOrWhiteSpace(s))
				items[0] = s;

			for (var i = 0; i < 3; i++)
			{
				s = Items[i].GenerateJson(false);
				if (!string.IsNullOrWhiteSpace(s))
					items[i + 1] = s;
			}

			if (items.All(string.IsNullOrWhiteSpace)) return b.ToString();

			b.Append("Items:[");
			for (var i = 0; i < 4; i++)
			{
				s = items[i];
				if (string.IsNullOrWhiteSpace(s)) continue;
				if (s.EndsWith(","))
					s = s.Remove(s.Length - 1, 1);
				b.AppendFormat("{0}:{{{1}}},", i, s);
			}
			b.Remove(b.Length - 1, 1);
			b.Append("]");

			return b.ToString();

		}

		#endregion

	}
}
