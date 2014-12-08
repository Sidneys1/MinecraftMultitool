using System.Text;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Mobs.Friendly
{
	internal class Bat : MobBase 
	{
		public Bat() :base(6) { Type = EntityTypes.Bat; BatFlags = false; }

		bool _batFlags;
		[EntityDescriptor("Bat Options", "Is Hanging")]
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

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Mobs/Bat/Bat.png";

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (BatFlags)
				b.Append("BatFlags:1,");

			return b.ToString();
		}
	}
}