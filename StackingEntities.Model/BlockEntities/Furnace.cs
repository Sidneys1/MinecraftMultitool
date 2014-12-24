using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StackingEntities.Model.BlockEntities.BaseClasses;
using StackingEntities.Model.Items;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.BlockEntities
{
	[Serializable]
	public class Furnace : LockedContainerBase
	{
		#region Properties

		[EntityDescriptor("Furnace Options", "Burn Time", "Number of ticks before the fuel runs out."),
		 MinMax(0, short.MaxValue)]
		public int? BurnTime { get; set; } = 0;

		[EntityDescriptor("Furnace Options", "Cook Time", "Number of ticks the item has been smelting for."),
		 MinMax(0, short.MaxValue)]
		public int? CookTime { get; set; } = 0;

		[EntityDescriptor("Furnace Options", "Input Item", wide:true)]
		public Item Smelting { get; } = new Item { SlotTitle = "Input Item", Slot = 0, SlotTagEnabled = false};
		[EntityDescriptor("Furnace Options", "Fuel Item", wide: true)]
		public Item Fuel { get; } = new Item { SlotTitle = "Fuel Item", Slot = 1, SlotTagEnabled = false };
		[EntityDescriptor("Furnace Options", "Output Item", wide: true)]
		public Item Output { get; } = new Item { SlotTitle = "Output Item", Slot = 2, SlotTagEnabled = false };

		#endregion

		#region Inherited

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(false));

			if (BurnTime.HasValue)
				b.AppendFormat("BurnTime:{0},", BurnTime.Value);

			if (CookTime.HasValue)
				b.AppendFormat("CookTime:{0},", CookTime.Value);

			var items = new List<string> {Smelting.GenerateJson(false), Fuel.GenerateJson(false), Output.GenerateJson(false)};


			if (items.All(string.IsNullOrWhiteSpace)) return b.ToString();

			b.Append("Items:[");

			for (var i = 0; i < items.Count; i++)
			{
				if (string.IsNullOrWhiteSpace(items[i])) continue;

				if (items[i].EndsWith(","))
					items[i] = items[i].Remove(items[i].Length - 1, 1);

				b.AppendFormat("{0}:{{{1}}},", i, items[i]);
			}

			b.Remove(b.Length - 1, 1);
			b.Append("],");

			return b.ToString();

		}

		#endregion
	}
}
