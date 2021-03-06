﻿using System;
using System.Text;
using StackingEntities.Model.Enums;
using StackingEntities.Model.Helpers;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Mobs.Friendly
{
	[Serializable]
	public class Sheep : BreedableMobBase
	{
		private SheepColors _color = SheepColors.DontCare;
		private bool _shorn;

		[EntityDescriptor("Sheep Options", "Wool Color")]
		public SheepColors Color
		{
			get { return _color; }
			set { _color = value; PropChanged("Display"); PropChanged("DisplayImage");}
		}

		[EntityDescriptor("Sheep Options", "Is Sheared")]
		public bool Shorn
		{
			get { return _shorn; }
			set { _shorn = value; PropChanged("Display"); PropChanged("DisplayImage"); }
		}

		public Sheep() : base(8)
		{
			Type = EntityType.Sheep;
		}

		public override string Display => base.Display + (Shorn ? "Sheared " :"") + Color.Description() + "-Colored Sheep";

		public override string DisplayImage
		{
			get
			{
				if (Age < 0)
					return "/StackingEntities.Resources;component/Images/Mobs/Sheep/BabySheep.png";
				return Shorn ? "/StackingEntities.Resources;component/Images/Mobs/Sheep/ShornSheep.png" : string.Format("/StackingEntities.Resources;component/Images/Mobs/Sheep/Sheep_{0:D}.png", Color);
			}
		}

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (Shorn)
				b.Append("Sheared:1b,");

			if (Color != SheepColors.DontCare)
				b.AppendFormat("Color:{0:D}b,", Color);

			return b.ToString();
		}
	}
}
