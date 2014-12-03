using System.Text;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Mobs.Friendly
{
	internal class Chicken : BreedableMobBase 
	{
		public Chicken() { Type = EntityTypes.Chicken; Health = 4; IsChickenJockey = false; }

		bool _isChickenJockey;
		[EntityDescriptor("Chicken Options", "Is Jockey")]
		public bool IsChickenJockey
		{
			get { return _isChickenJockey; }
			set
			{
				_isChickenJockey = value;
				PropChanged();
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

		public override string DisplayImage => Age >= 0 ? "/StackingEntities.Resources;component/Images/Mobs/Chicken/Chicken.png" : "/StackingEntities.Resources;component/Images/Mobs/Chicken/BabyChicken.png";

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (IsChickenJockey)
				b.Append("IsChickenJockey:1,");

			if (Health != 4)
				b.Append(string.Format("HealF:{0},", Health));

			return b.ToString();
		}
	}
}