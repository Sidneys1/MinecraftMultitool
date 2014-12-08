using StackingEntities.Model.Entities.Projectiles.BaseClasses;

namespace StackingEntities.Model.Entities.Projectiles
{
	public class ThrownPotion : OwnedProjectileBase
	{
		// TODO: potion Items

		//[EntityDescriptor("Potion Options", "Potion Item")]
		//public Item Potion { get; } = new Item {Count = 1, CountTagEnabled = false, Damage = 0, DamageTagEnabled = false, Id = "minecraft:potion", IdTagEnabled = false, Slot = null, SlotTitle = "Potion Item"};

		public ThrownPotion()
		{
			Type = EntityTypes.ThrownPotion;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Projectiles/ThrownPotion.png";
	}
}
