namespace StackingEntities.Model.Entities.Vehicles
{
	public class MinecartHopper : Minecart
	{
		public MinecartHopper()
		{
			Type = EntityTypes.MinecartHopper;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Vehicles/MinecartHopper.png";
	}
}
