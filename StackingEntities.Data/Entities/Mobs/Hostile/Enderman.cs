using System.Text;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Mobs.Hostile
{
	internal class Enderman : MobBase
	{
		public Enderman() { Type = EntityTypes.Enderman; Health = 40; Carried = 0; EndermiteCount = 0; CarriedData = 0; }

		[EntityDescriptor("Enderman Options", "Ender-mite Count")]
		[MinMax(0, int.MaxValue)]
		public int EndermiteCount { get; set; }

		int _carriedData;
		[EntityDescriptor("Enderman Options", "Carried Block Data")]
		[MinMax(0, short.MaxValue)]
		public int CarriedData
		{
			get { return _carriedData; }
			set
			{
				_carriedData = value;
				PropChanged();
				PropChanged("Display");
			}
		}

		int _carried;
		[EntityDescriptor("Enderman Options", "Carried Block")]
		[MinMax(0, short.MaxValue)]
		public int Carried
		{
			get { return _carried; }
			set
			{
				_carried = value;
				PropChanged();
				PropChanged("Display");
				PropChanged("DisplayImage");
			}
		}

		public override string Display
		{
			get
			{
				var add = "";

				if (Carried!=0)
					add += string.Format("Carrying {0}:{1}", Carried, CarriedData);

				return base.Display + add;
			}
		}

		public override string DisplayImage => Carried != 0 ? "/StackingEntities.Resources;component/Images/Mobs/Enderman/EndermanCarrying.png" : "/StackingEntities.Resources;component/Images/Mobs/Enderman/Enderman.png";

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (EndermiteCount != 0)
				b.Append(string.Format("EndermiteCount:{0},", EndermiteCount));

			if (CarriedData != 0)
				b.Append(string.Format("CarriedData:{0},", CarriedData));

			if (Carried != 0)
				b.Append(string.Format("Carried:{0},", Carried));

			if (Health != 40)
				b.Append(string.Format("HealF:{0},", Health));

			return b.ToString();
		}
	}
}