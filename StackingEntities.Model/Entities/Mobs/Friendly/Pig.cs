using System;
using System.Text;
using StackingEntities.Model.Enums;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Mobs.Friendly
{
	[Serializable]
	public class Pig : BreedableMobBase
	{
		private bool _saddled;

		[EntityDescriptor("Pig Options", "Saddled")]
		public bool Saddled
		{
			get { return _saddled; }
			set { _saddled = value; PropChanged("Display"); PropChanged("DisplayImage"); }
		}

		public Pig() : base(10)
		{
			Type = EntityType.Pig;
		}


		public override string Display => base.Display + (Saddled ? "Saddled Pig" : "Pig");

		public override string DisplayImage => Age < 0 ? "/StackingEntities.Resources;component/Images/Mobs/Pig/BabyPig.png" : "/StackingEntities.Resources;component/Images/Mobs/Pig/" + (Saddled ? "SaddlePig.png" : "Pig.png");

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (Saddled)
				b.Append("Saddled:1b,");

			return b.ToString();
		}
	}
}
