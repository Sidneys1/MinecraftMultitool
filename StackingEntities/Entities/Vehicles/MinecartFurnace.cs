using System;
using System.Text;

namespace StackingEntities.Entities.Vehicles
{
	internal class MinecartFurnace : Minecart
	{
		public MinecartFurnace() { Type = EntityTypes.MinecartFurnace; }

		[Property("Minecart Furnace Options","Push X")]
		public double PushX { get; set; }

		[Property("Minecart Furnace Options", "Push Z")]
		public double PushZ { get; set; }

		int _fuel;
		[Property("Minecart Furnace Options", "Ticks of Fuel"), MinMax(0, null)]
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

		public override string Display => string.Format("Minecart Furnace\r\n{0} Fuel", (Fuel == 0 ? "No" : (Fuel >= 20 ? (Fuel/20f) + " Seconds of" : Fuel + " Ticks of")));

		public override string DisplayImage => "Images/Vehicles/MinecartFurnace.png";

		public override string GenerateJSON(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJSON(topLevel));

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