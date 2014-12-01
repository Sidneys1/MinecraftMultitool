namespace StackingEntities.Model.Entities.Mobs.Hostile
{
	public class LavaSlime : Slime
	{
		public LavaSlime()
		{
			Type = EntityTypes.LavaSlime;
		}

		public override string DisplayImage => "/StackingEntities;component/Images/Mobs/Slime/LavaSlime.png";
	}
}