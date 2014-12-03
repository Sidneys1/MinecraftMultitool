namespace StackingEntities.Model.Entities.Vehicles
{
	public class MinecartChest : Minecart
	{
		//TODO Items lists

		public MinecartChest()
		{
			Type = EntityTypes.MinecartChest;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Vehicles/MinecartChest.png";
	}
}
