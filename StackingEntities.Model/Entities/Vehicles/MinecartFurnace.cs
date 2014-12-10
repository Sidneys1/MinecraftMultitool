using System;
using System.Text;
using StackingEntities.Model.Helpers;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Vehicles
{
	[Serializable]
	internal class MinecartFurnace : Minecart
	{
		public MinecartFurnace() { Type = EntityTypes.MinecartFurnace; }

		[EntityDescriptor("Minecart Furnace Options","Push X")]
		public double PushX { get; set; }

		[EntityDescriptor("Minecart Furnace Options", "Push Z")]
		public double PushZ { get; set; }

		int _fuel;
		[EntityDescriptor("Minecart Furnace Options", "Ticks of Fuel"), MinMax(0, null)]
		public int Fuel
		{
			get { return _fuel; }
			set
			{
				_fuel = value;
				PropChanged();
				PropChanged("Display");
			}
		}

		public override string Display => string.Format("Minecart Furnace\r\n{0} Fuel", (Fuel == 0 ? "No" : (JsonTools.TicksToTime(Fuel) + " of")));

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Vehicles/MinecartFurnace.png";

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (Math.Abs(PushX) > 0)
				b.Append(string.Format("PushX:{0},", PushX));

			if (Math.Abs(PushZ) > 0)
				b.Append(string.Format("PushZ:{0},", PushZ));

			if (Fuel != 0)
				b.Append(string.Format("Fuel:{0},", Fuel));

			return b.ToString();
		}
	}
}