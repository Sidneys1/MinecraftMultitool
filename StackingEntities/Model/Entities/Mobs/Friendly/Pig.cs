using System.Text;
using StackingEntities.ViewModel;

namespace StackingEntities.Model.Entities.Mobs.Friendly
{
	public class Pig : BreedableMobBase
	{
		private bool _saddled;

		[Property("Pig Options", "Saddled")]
		public bool Saddled
		{
			get { return _saddled; }
			set { _saddled = value; PropChanged("Display"); PropChanged("DisplayImage"); }
		}

		public Pig()
		{
			Type = EntityTypes.Pig;
			Health = 10;
		}


		public override string Display => base.Display + (Saddled ? "Saddled Pig" : "Pig");

		public override string DisplayImage => Age < 0 ? "/StackingEntities;component/Images/Mobs/Pig/BabyPig.png" : "/StackingEntities;component/Images/Mobs/Pig/" + (Saddled ? "SaddlePig.png" : "Pig.png");

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (Health != 10)
				b.AppendFormat("HealF:{0}f,", Health);

			if (Saddled)
				b.Append("Saddled:1b,");

			return b.ToString();
		}
	}
}
