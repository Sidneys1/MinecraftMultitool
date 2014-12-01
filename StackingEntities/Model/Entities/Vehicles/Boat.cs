namespace StackingEntities.Model.Entities.Vehicles
{
	public class Boat : EntityBase
	{
		public Boat()
		{
			Type = EntityTypes.Boat; //Health
		}

		public override string DisplayImage => "/Images/Vehicles/Boat.png";
	}
}
