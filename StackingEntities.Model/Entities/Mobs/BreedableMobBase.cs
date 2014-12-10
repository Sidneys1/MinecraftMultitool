using System;
using System.Text;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Mobs
{
	[Serializable]
	public abstract class BreedableMobBase : MobBase
	{
		[EntityDescriptor("Breedable Mob Options", "Love Mode (Ticks)")]
		public int InLove { get; set; }

		int _age;
		[EntityDescriptor("Breedable Mob Options", "Age (Ticks)")]
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

		protected BreedableMobBase(int baseHealth) : base(baseHealth)
		{
		}

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