using System.Text;
using StackingEntities.ViewModel;

namespace StackingEntities.Model.Entities.Mobs.Friendly
{
	internal class Bat : MobBase 
	{
		public Bat() { Type = EntityTypes.Bat; Health = 6; BatFlags = false; }

		bool _batFlags;
		[Property("Bat Options", "Is Hanging")]
		public bool BatFlags
		{
			get { return _batFlags; }
			set
			{
				_batFlags = value;
				PropChanged();
				PropChanged("Display");
			}
		}

		public override string Display => base.Display + (BatFlags ? "Hanging" : "Flying");

		public override string DisplayImage => "/Images/Mobs/Bat/Bat.png";

		public override string GenerateJSON(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJSON(topLevel));

			if (BatFlags)
				b.Append("BatFlags:1,");

			if (Health != 6)
				b.Append(string.Format("HealF:{0},", Health));

			return b.ToString();
		}
	}
}