namespace StackingEntities.Model.Entities.Projectiles
{
	public class ThrownExpBottle : BaseClasses.OwnedProjectileBase
	{
		public ThrownExpBottle()
		{
			Type = EntityTypes.ThrownExpBottle;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Projectiles/ThrownExpBottle.png";
	}
}
