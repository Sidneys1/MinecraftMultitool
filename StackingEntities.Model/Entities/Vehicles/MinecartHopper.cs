using System;
using System.Collections.ObjectModel;
using System.Text;
using StackingEntities.Model.Helpers;
using StackingEntities.Model.Items;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Vehicles
{
	[Serializable]
	public class MinecartHopper : Minecart
	{
		[EntityDescriptor("Minecart Hopper Options", "Inventory", fixedSize: true), MinMax(5, 1)]
		public ObservableCollection<Item> Inventory { get; } = new ObservableCollection<Item>();

		public MinecartHopper()
		{
			Type = EntityTypes.MinecartHopper;
			for (var i = 0; i <= 4; i++)
			{
				Inventory.Add(new Item { Slot = i, SlotTagEnabled = false });
			}
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Vehicles/MinecartHopper.png";

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			b.Append(JsonTools.GenItems(Inventory));

			return b.ToString();
		}
	}
}
