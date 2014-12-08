using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using StackingEntities.Model.Helpers;
using StackingEntities.Model.Interface;
using StackingEntities.Model.Items;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Mobs.Friendly
{
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
			Type = EntityTypes.Villager;
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

	public class VillagerRecipe : IJsonAble
	{
		public bool RewardExp { get; set; }
		public int MaxUses { get; set; }
		public int Uses { get; set; }

		public bool TwoItems { get; set; } = false;

		public Item BuyItem { get; } = new Item(false) {SlotTitle = "Buying (Item 1)" };
		public Item BuyItemB { get; } = new Item(false) {SlotTitle = "Buying (Item 2)" };
		public Item SellItem { get; }=new Item {SlotTitle = "Selling"};
		public string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder();

			b.AppendFormat("rewardExp:{0}b,", RewardExp ? 1 : 0);
			b.AppendFormat("maxUses:{0},", MaxUses);
			b.AppendFormat("uses:{0},", Uses);
			var s = BuyItem.GenerateJson(false);
			b.AppendFormat("buy:{{{0}}},", s.Remove(s.Length-1,1));
			if (TwoItems)
			{
				s = BuyItemB.GenerateJson(false);
				b.AppendFormat("buyB:{{{0}}},",s.Remove(s.Length - 1, 1));
			}
			s = SellItem.GenerateJson(false);
			b.AppendFormat("sell:{{{0}}}", s.Remove(s.Length - 1, 1));

			return b.ToString();
		}
	}


	public enum VillagerProfession
	{
		Default = -1,
		Farmer,
		Librarian,
		Priest,
		Blacksmith,
		Butcher
	}

	public enum VillagerCareer
	{
		Default=0,
		Farmer = 1,
		Fisherman = 2,
		Shepherd = 3,
		Fletcher = 4,
		Librarian = 1,
		Cleric = 1,
		Armorer = 1,
		[Description("Weapon Smith")]
		WeaponSmith = 2,
		[Description("Tool Smith")]
		ToolSmith = 3,
		Butcher = 1,
		Leatherworker = 2
	}
}
