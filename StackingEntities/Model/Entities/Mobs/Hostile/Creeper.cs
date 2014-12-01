using System.Text;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Mobs.Hostile
{
	internal class Creeper : MobBase 
	{
		public Creeper() { Type = EntityTypes.Creeper; Health = 20; Powered = false; ExplosionRadius = 3; Fuse = 30; }

		bool _powered;
		[Property("Creeper Options", "Charged")]
		public bool Powered
		{
			get { return _powered; }
			set
			{
				_powered = value;
				PropChanged();
				PropChanged("DisplayImage");
				PropChanged("Display");
			}
		}

		[Property("Creeper Options", "Explosion Radius")]
		[MinMax(0, byte.MaxValue)]
		public int ExplosionRadius { get; set; }

		[Property("Creeper Options", "Fuse Time (Ticks)")]
		[MinMax(0, short.MaxValue)]
		public int Fuse { get; set; }

		bool _ignited;
		[Property("Creeper Options", "Ignited")]
		public bool Ignited
		{
			get { return _ignited; }
			set
			{
				_ignited = value;
				PropChanged();
				PropChanged("Display");
			}
		}

		public override string Display
		{
			get
			{
				var add = "";

				if (Powered)
					add += "Charged ";

				if (Ignited)
					add += "Ignited ";

				return base.Display + add;
			}
		}

		public override string DisplayImage => Powered ? "/StackingEntities;component/Images/Mobs/Creeper/ChargedCreeper.png" : "/StackingEntities;component/Images/Mobs/Creeper/Creeper.png";

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (Powered)
				b.Append("Powered:1,");

			if (Ignited)
				b.Append("Ignited:1,");

			if (ExplosionRadius != 3)
				b.Append(string.Format("ExplosionRadius:{0},", ExplosionRadius));

			if (Fuse != 30)
				b.Append(string.Format("Fuse:{0},", Fuse));

			if (Health != 20)
				b.Append(string.Format("HealF:{0},", Health));

			return b.ToString();
		}
	}
}