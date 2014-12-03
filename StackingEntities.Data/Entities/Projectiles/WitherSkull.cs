namespace StackingEntities.Model.Entities.Projectiles
{
	public class WitherSkull : BaseClasses.DirectionProjectileBase
	{
		public WitherSkull()
		{
			Type = EntityTypes.WitherSkull;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Projectiles/WitherSkull.png";
	}
}
