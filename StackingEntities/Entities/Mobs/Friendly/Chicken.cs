using System.Text;

namespace StackingEntities.Entities.Mobs.Friendly
{
	internal class Chicken : BreedableMobBase 
	{
		public Chicken() { Type = EntityTypes.Chicken; Health = 4; IsChickenJockey = false; }

		bool _isChickenJockey;
		[Property("Chicken Options", "Is Jockey")]
		public bool IsChickenJockey
		{
			get { return _isChickenJockey; }
			set
			{
				_isChickenJockey = value;
				PropChanged("IsChickenJockey");
				PropChanged("Display");
			}
		}

		public override string Display
		{
			get
			{
				var add = "";

				if (Age < 0)
					add += "Baby ";

				if (IsChickenJockey)
					add += "Jockey ";

				return base.Display + add;
			}
		}

		public override string DisplayImage => Age >= 0 ? "/Images/Mobs/Chicken/Chicken.png" : "/Images/Mobs/Chicken/BabyChicken.png";

		public override string GenerateJSON(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJSON(topLevel));

			if (IsChickenJockey)
				b.Append("IsChickenJockey:1,");

			if (Health != 4)
				b.Append(string.Format("HealF:{0},", Health));

			return b.ToString();
		}
	}
}