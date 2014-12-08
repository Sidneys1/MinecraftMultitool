namespace StackingEntities.Model.Entities.Other
{
	public class LeashKnot : EntityBase
	{
		public LeashKnot ()
		{
			Type = EntityTypes.LeashKnot;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Other/Lead.png";
	}
}
