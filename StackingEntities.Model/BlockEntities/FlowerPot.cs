using System;
using System.Text;
using StackingEntities.Model.BlockEntities.BaseClasses;
using StackingEntities.Model.Helpers;
using StackingEntities.Model.Items;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.BlockEntities
{
	[Serializable]
	public class FlowerPot : BlockEntityBase
	{
		#region Properties

		[EntityDescriptor("Flower Pot Options", "Flower Pot Item", wide:true)]
		public Item Item { get; } = new Item (false) {Count = null, SlotTitle = "Flower Pot Item"};

		#endregion

		#region Inherited

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(false));

			if (!string.IsNullOrWhiteSpace(Item.Id))
				b.AppendFormat("Item:\"{0}\",", Item.Id.EscapeJsonString());

			if (Item.Damage.HasValue)
				b.AppendFormat("Data:{0},", Item.Damage.Value);

			return b.ToString();
		}

		#endregion
	}
}
