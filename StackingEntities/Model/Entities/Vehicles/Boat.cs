namespace StackingEntities.Model.Entities.Vehicles
{
	public class Boat : EntityBase
	{
		public Boat()
		{
			Type = EntityTypes.Boat; //Health
		}

		public override string DisplayImage => "/StackingEntities;component/Images/Vehicles/Boat.png";
	}
}
