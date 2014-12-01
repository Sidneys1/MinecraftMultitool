using System.ComponentModel;
using System.Text;
using StackingEntities.ViewModel;

namespace StackingEntities.Model.Entities.Mobs.Friendly
{
	public class Sheep : BreedableMobBase
	{
		private SheepColors _color = SheepColors.DontCare;
		private bool _shorn;

		[Property("Sheep Options", "Wool Color")]
		public SheepColors Color
		{
			get { return _color; }
			set { _color = value; PropChanged("Display"); PropChanged("DisplayImage");}
		}

		[Property("Sheep Options", "Is Sheared")]
		public bool Shorn
		{
			get { return _shorn; }
			set { _shorn = value; PropChanged("Display"); PropChanged("DisplayImage"); }
		}

		public Sheep()
		{
			Type = EntityTypes.Sheep;
			Health = 8;
		}

		public override string Display => base.Display + (Shorn ? "Sheared " :"") + Color.Description() + "-Colored Sheep";

		public override string DisplayImage
		{
			get
			{
				if (Age < 0)
					return "/StackingEntities;component/Images/Mobs/Sheep/BabySheep.png";
				return Shorn ? "/StackingEntities;component/Images/Mobs/Sheep/ShornSheep.png" : string.Format("/StackingEntities;component/Images/Mobs/Sheep/Sheep_{0:D}.png", Color);
			}
		}

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (Shorn)
				b.Append("Sheared:1b,");

			if (Color != SheepColors.DontCare)
				b.AppendFormat("Color:{0:D}b,", Color);

			if (Health != 8)
				b.AppendFormat("HealF:{0}f,", Health);

			return b.ToString();
		}
	}

	public enum SheepColors
	{
		[Description("Random")]
		DontCare =-1,
		Black = 15,
		Red = 14,
		Green = 13,
		Brown = 12,
		Blue = 11,
		Purple = 10,
		Cyan = 9,
		[Description("Light Gray")]
		LightGray = 8,
		Gray = 7,
		Pink = 6,
		Lime = 5,
		Yellow = 4,
		[Description("Light Blue")]
		LightBlue = 3,
		Magenta = 2,
		Orange = 1,
		White = 0
	}
}
