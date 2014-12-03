namespace StackingEntities.Model.Entities.Mobs.Hostile
{
	public class Blaze : MobBase
	{
		public Blaze() : base(20)
		{
			Type = EntityTypes.Blaze;
		}


		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Mobs/Blaze/Blaze.png";
	}
}
