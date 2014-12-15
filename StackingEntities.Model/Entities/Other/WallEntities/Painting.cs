using System;
using System.Text;
using StackingEntities.Model.Entities.Other.WallEntities.BaseClasses;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Other.WallEntities
{
	[Serializable]
	internal class Painting : WallEntityBase
	{
		public Painting() { Type = EntityTypes.Painting; }

		string _motive = "";
		[EntityDescriptor("Painting Options", "Motive")]
		public string Motive
		{
			get { return _motive; }
			set
			{
				_motive = value;
				PropChanged();
				PropChanged("Display");
			}
		}

		public override string Display => !string.IsNullOrWhiteSpace(Motive) ? "Motive: " + Motive : string.Empty;

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Other/Painting.png";

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (!string.IsNullOrWhiteSpace(Motive))
				b.Append(string.Format("Motive:\"{0}\",", Motive));

			return b.ToString();
		}
	}
}