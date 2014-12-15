using System;
using System.Text;
using StackingEntities.Model.Interface;
using StackingEntities.Model.Items;

namespace StackingEntities.Model.Objects
{
	[Serializable]
	public class VillagerRecipe : IJsonAble
	{
		public bool RewardExp { get; set; }
		public int MaxUses { get; set; }
		public int Uses { get; set; }

		public bool TwoItems { get; set; } = false;

		public Item BuyItem { get; } = new Item {SlotTitle = "Buying (Item 1)" };
		public Item BuyItemB { get; } = new Item {SlotTitle = "Buying (Item 2)" };
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
}