using System;
using StackingEntities.Model.Entities.Projectiles.BaseClasses;
using StackingEntities.Model.Enums;

namespace StackingEntities.Model.Entities.Projectiles
{
	[Serializable]
	public class ThrownPotion : OwnedProjectileBase
	{
		// TODO: potion Items

		//[EntityDescriptor("Potion Options", "Potion Item")]
		//public Item Potion { get; } = new Item {Count = 1, CountTagEnabled = false, Damage = 0, DamageTagEnabled = false, Id = "minecraft:potion", IdTagEnabled = false, Slot = null, SlotTitle = "Potion Item"};

		public ThrownPotion()
		{
			Type = EntityType.ThrownPotion;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Projectiles/ThrownPotion.png";
	}
}
