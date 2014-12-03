namespace StackingEntities.Model.Entities.Mobs.Hostile
{
	public class EnderDragon :MobBase
	{
		public EnderDragon() : base(200)
		{
			Type = EntityTypes.EnderDragon;
			Health = 200;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Mobs/EnderDragon/EnderDragon.png";
	}
}
