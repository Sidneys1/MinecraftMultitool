using System.Text;
using StackingEntities.Model.Items;
using StackingEntities.Model.Items.ItemTags;
using StackingEntities.ViewModel;

namespace StackingEntities.Model.Entities.Other
{
	internal class FireworkRocketEntity : EntityBase
	{
		public FireworkRocketEntity()
		{
			Type = EntityTypes.FireworksRocketEntity;
			FireWorksItem.Tag.Add(new ItemTagsFireworkStar {IsStar = false, IsStarEnabled = false});
		}

		[Property("Firework Options", "Life (Age)")]
		public int Life{get;set;}

		[Property("Firework Options", "Life Time")]
		public int LifeTime{get;set;}

		[Property("Firework Options", "Firework Item")]
		public Item FireWorksItem { get; set; } = new Item {Id = "minecraft:fireworks", IdTagEnabled = false, CountTagEnabled = false, SlotTagEnabled = false, DamageTagEnabled = false};

		public override string Display => string.Empty;

		public override string DisplayImage => "/StackingEntities;component/Images/Other/FireworkRocketEntity.png";

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (Life != 0)
				b.Append(string.Format("Life:{0},", Life));

			if (LifeTime != 0)
				b.Append(string.Format("LifeTime:{0},", LifeTime));


			var generateJson = FireWorksItem.GenerateJson(false);
			generateJson = generateJson.Remove(generateJson.Length - 1, 1);
			b.AppendFormat("FireWorksItem:{{{0}}},", generateJson);

			return b.ToString();
		}
	}
}