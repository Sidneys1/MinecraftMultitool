using System;
using System.Collections.ObjectModel;
using System.Text;
using StackingEntities.Model.Helpers;
using StackingEntities.Model.Items;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Vehicles
{
	[Serializable]
	public class MinecartChest : Minecart
	{
		[EntityDescriptor("Minecart Chest Options", "Inventory", fixedSize: true), MinMax(9, 3)]
		public ObservableCollection<Item> Inventory { get; } = new ObservableCollection<Item>();

		public MinecartChest()
		{
			Type = EntityTypes.MinecartChest;

			for (var i = 0; i <= 26; i++)
			{
				Inventory.Add(new Item { Slot = i, SlotTagEnabled = false });
			}
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Vehicles/MinecartChest.png";

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			b.Append(JsonTools.GenItems(Inventory));

			return b.ToString();
		}
	}
}
