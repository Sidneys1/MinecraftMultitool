using System.Text;
using StackingEntities.ViewModel;

namespace StackingEntities.Model.Entities.ItemEntities
{
	internal class XpOrb : ItemEntityBase
	{
		private int _value;

		

		[Property("XP Orb Options", "Value (XP Points)"), MinMax(0, int.MaxValue)]
		public int Value
		{
			get { return _value; }
			set { _value = value;
				PropChanged("Display");
				PropChanged("DisplayImage");
			}
		}

		public XpOrb ()
		{
			Type = EntityTypes.XPOrb;
			Health = 0;
		}

		public override string Display => string.Format("Size {0}", GetSize());

		private int GetSize()
		{
			var size = 1;
			if (Value >= 2477)
				size = 11;
			else if (Value >= 1237)
				size = 10;
			else if (Value >= 617)
				size = 9;
			else if (Value >= 307)
				size = 8;
			else if (Value >= 149)
				size = 7;
			else if (Value >= 73)
				size = 6;
			else if (Value >= 37)
				size = 5;
			else if (Value >= 17)
				size = 4;
			else if (Value >= 7)
				size = 3;
			else if (Value >= 3)
				size = 2;
			return size;
		}

		public override string DisplayImage => string.Format("/StackingEntities;component/Images/Other/experience_orb_{0}.png", GetSize());

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			
			b.Append(string.Format("Value:{0},", Value));

			return b.ToString();
		}
	}
}