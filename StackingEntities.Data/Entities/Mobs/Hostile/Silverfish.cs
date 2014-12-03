namespace StackingEntities.Model.Entities.Mobs.Hostile
{
	public class Silverfish : MobBase
	{
		public Silverfish() : base(8)
		{
			Type = EntityTypes.Silverfish;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Mobs/Silverfish/Silverfish.png";
	}
}
