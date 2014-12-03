using System.Text;
using StackingEntities.Model.Helpers;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Mobs.Friendly
{
	internal class Wolf : TameableMobBase
	{
		public Wolf() : base(8) { Type = EntityTypes.Wolf; }

		#region Type

		private bool _angry;
		[EntityDescriptor("Wolf Options", "Is Angry")]
		public bool Angry
		{
			get { return _angry; }
			set
			{
				_angry = value;
				PropChanged();
				PropChanged("Display");
				PropChanged("DisplayImage");
			}
		}

		private Dyes _collarColor = (Dyes)14;
		[EntityDescriptor("Wolf Options", "Collar Color")]
		public Dyes CollarColor
		{
			get { return _collarColor; }
			set
			{
				_collarColor = value;
				PropChanged();
				PropChanged("Display");
			}
		}

		#endregion

		#region UI

		public override string Display => base.Display + (CollarColor != (Dyes) 14 ? CollarColor.Description() + "-Collared " : "") +
		                                  (_angry ? "Angry " : "") + "Wolf";

		public override string DisplayImage
		{
			get
			{
				var name = string.Empty;

				if (Angry)
					name += "Angry";

				if (Age < 0)
					name += "Baby";

				if (!Angry && Age >= 0 && !string.IsNullOrWhiteSpace(Owner))
					name += "Tame";

				return string.Format("/StackingEntities.Resources;component/Images/Mobs/wolf/{0}Wolf.png", name);
			}
		}

		#endregion

		#region Process

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (Angry)
				b.Append("Angry:1b,");

			if ((!string.IsNullOrWhiteSpace(Owner) && Health != 20) || ((string.IsNullOrWhiteSpace(Owner) && Health != 8)))
				b.Append(string.Format("HealF:{0}f,", Health));

			if (CollarColor != (Dyes)14)
				b.Append(string.Format("CollarColor:{0}b,", (int)CollarColor));

			return b.ToString();
		}

		#endregion
	}
}