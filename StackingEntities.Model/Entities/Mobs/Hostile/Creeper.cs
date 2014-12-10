using System;
using System.Text;
using StackingEntities.Model.Helpers;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Mobs.Hostile
{
	[Serializable]
	internal class Creeper : MobBase 
	{
		public Creeper() : base(20)
		{ Type = EntityTypes.Creeper;}

		bool _powered;
		[EntityDescriptor("Creeper Options", "Charged")]
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

		[EntityDescriptor("Creeper Options", "Explosion Radius")]
		[MinMax(0, byte.MaxValue)]
		public int ExplosionRadius { get; set; } = 3;

		[EntityDescriptor("Creeper Options", "Fuse Time (Ticks)")]
		[MinMax(0, short.MaxValue)]
		public int Fuse
		{
			get { return _fuse; }
			set { _fuse = value; PropChanged("Display"); }
		}

		bool _ignited;
		private int _fuse = 30;

		[EntityDescriptor("Creeper Options", "Ignited")]
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

				if (Fuse != 30)
					add += JsonTools.TicksToTime(Fuse) + "-Fuse ";

				return base.Display + add;
			}
		}

		public override string DisplayImage => Powered ? "/StackingEntities.Resources;component/Images/Mobs/Creeper/ChargedCreeper.png" : "/StackingEntities.Resources;component/Images/Mobs/Creeper/Creeper.png";

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

			return b.ToString();
		}
	}
}