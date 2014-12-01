using System.Text;
using StackingEntities.ViewModel;

namespace StackingEntities.Model.Entities.Mobs
{
	public abstract class BreedableMobBase : MobBase
	{
		[Property("Breedable Mob Options", "Love Mode (Ticks)")]
		public int InLove { get; set; }

		int _age;
		[Property("Breedable Mob Options", "Age (Ticks)")]
		public int Age
		{
			get { return _age; }
			set
			{
				_age = value;
				PropChanged();
				PropChanged("Display");
				PropChanged("DisplayImage");
			}
		}

		//[PropertyAttribute("Breedable Mob Options", "Love Mode (Ticks)")]
		//public int ForcedAge { get; set; }

		public override string Display => Age<0 ? "Baby " + base.Display : base.Display;

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (InLove != 0)
				b.Append(string.Format("InLove:{0},", InLove));

			if (Age != 0)
				b.Append(string.Format("Age:{0},", Age));

			//if (ForcedAge != 0)
			//	b.Append(string.Format("ForcedAge:{0},", ForcedAge));

			return b.ToString();
		}
	}
}