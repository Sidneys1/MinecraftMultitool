using StackingEntities.Model.Entities.Projectiles.BaseClasses;
using StackingEntities.Model.Items;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Projectiles
{
	public class ThrownPotion : OwnedProjectileBase
	{
		[EntityDescriptor("Potion Options", "Potion Item")]
		public Item Potion { get; } = new Item() {Count = 1, CountTagEnabled = false, Damage = 0, DamageTagEnabled = false, Id = "minecraft:potion", IdTagEnabled = false, Slot = null };

		public ThrownPotion()
		{
			Type = EntityTypes.ThrownPotion;
			//Potion.Tag.Add(new ItemTags);
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Projectiles/ThrownPotion.png";
	}
}
