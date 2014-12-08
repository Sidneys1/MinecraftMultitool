namespace StackingEntities.Model.Entities.Mobs.Hostile
{
	public class LavaSlime : Slime
	{
		public LavaSlime()
		{
			Type = EntityTypes.LavaSlime;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Mobs/Slime/LavaSlime.png";
	}
}