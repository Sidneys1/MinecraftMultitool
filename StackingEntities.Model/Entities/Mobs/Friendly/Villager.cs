using System;
using System.Collections.ObjectModel;
using System.Text;
using StackingEntities.Model.Enums;
using StackingEntities.Model.Helpers;
using StackingEntities.Model.Items;
using StackingEntities.Model.Metadata;
using StackingEntities.Model.Objects;

namespace StackingEntities.Model.Entities.Mobs.Friendly
{
	[Serializable]
	public class Villager : MobBase
	{
		[EntityDescriptor("Villager Options", "Willing", "Whether or not the Villager is willing to breed.")]
		public bool Willing { get; set; } = false;

		[EntityDescriptor("Villager Options", "Level", "What trading level is unlocked."), MinMax(0, int.MaxValue)]
		public int CareerLevel { get; set; }

		[EntityDescriptor("Villager Options", "Profession")]
		public VillagerProfession Profession { get; set; } = VillagerProfession.Default;

		[EntityDescriptor("Villager Options", "Career")]
		public VillagerCareer Career { get; set; } = VillagerCareer.Default;

		[EntityDescriptor("Villager Options", "Inventory", fixedSize: true), MinMax(8, 1)]
		public ObservableCollection<Item> Inventory { get; } = new ObservableCollection<Item>();

		[EntityDescriptor("Villager Options", "Trading Offers")]
		public ObservableCollection<VillagerRecipe> Offers { get; } = new ObservableCollection<VillagerRecipe>();

		public Villager() : base(20)
		{
			Type = EntityType.Villager;
			for (var i = 0; i <= 7; i++)
			{
				Inventory.Add(new Item { Slot = i, SlotTagEnabled = false });
			}
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Mobs/Villager/Villager.png";

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (Willing)
				b.Append("Willing:1b,");

			if (CareerLevel != 0)
				b.AppendFormat("CareerLevel:{0},", CareerLevel);

			if (Profession != VillagerProfession.Default)
				b.AppendFormat("Profession:{0:D},", Profession);

			if (Career != VillagerCareer.Default)
				b.AppendFormat("Career:{0:D},", Career);

			b.Append(JsonTools.GenItems(Inventory, "Inventory"));

			if (Offers.Count <= 0) return b.ToString();

			b.Append("Offers:{Recipes:[");
			for (var i = 0; i < Offers.Count; i++)
			{
				b.AppendFormat("{0}:{{{1}}},", i, Offers[i].GenerateJson(false));
			}
			b.Remove(b.Length - 1, 1);
			b.Append("]},");


			return b.ToString();

		}
	}
}
