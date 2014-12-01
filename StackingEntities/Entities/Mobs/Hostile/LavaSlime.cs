namespace StackingEntities.Entities.Mobs.Hostile
{
	public class LavaSlime : Slime
	{
		public LavaSlime()
		{
			Type = EntityTypes.LavaSlime;
		}

		public override string DisplayImage => "/Images/Mobs/Slime/LavaSlime.png";
	}
}