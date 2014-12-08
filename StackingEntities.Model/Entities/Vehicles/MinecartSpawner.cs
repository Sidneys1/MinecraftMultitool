namespace StackingEntities.Model.Entities.Vehicles
{
	public class MinecartSpawner : Minecart
	{
		// TODO Spawner

		public MinecartSpawner()
		{
			Type = EntityTypes.MinecartSpawner;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Vehicles/MinecartSpawner.png";
	}
}
