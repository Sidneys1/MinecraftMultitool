using System;
using System.Text;
using StackingEntities.Model.Enums;
using StackingEntities.Model.Items;
using StackingEntities.Model.Items.ItemTags;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Other
{
	[Serializable]
	internal class FireworkRocketEntity : EntityBase
	{
		public FireworkRocketEntity()
		{
			Type = EntityType.FireworksRocketEntity;
			FireWorksItem.Tag.Add(new ItemTagsFireworkStar {IsStar = false, IsStarEnabled = false});
		}

		[EntityDescriptor("Firework Options", "Life (Age)")]
		public int Life{get;set;}

		[EntityDescriptor("Firework Options", "Life Time")]
		public int LifeTime{get;set;}

		[EntityDescriptor("Firework Options", "Firework Item")]
		public Item FireWorksItem { get; set; } = new Item(false) {Id = "minecraft:fireworks", IdTagEnabled = false, CountTagEnabled = false, SlotTagEnabled = false, DamageTagEnabled = false, SlotTitle = "Firework Item" };

		public override string Display => string.Empty;

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Other/FireworkRocketEntity.png";

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