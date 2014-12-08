namespace StackingEntities.Model.Entities.Mobs.Hostile
{
	public class CaveSpider :MobBase
	{
		public CaveSpider() : base(12)
		{
			Type = EntityTypes.CaveSpider;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Mobs/CaveSpider/CaveSpider.png";
	}
}