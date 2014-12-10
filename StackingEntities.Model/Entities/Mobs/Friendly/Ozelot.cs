using System;
using System.Text;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Mobs.Friendly
{
	[Serializable]
	public class Ozelot : TameableMobBase
	{
		private CatType _catType;

		[EntityDescriptor("Ocelot Options", "Type")]
		public CatType CatType
		{
			get { return _catType; }
			set { _catType = value; PropChanged("Display"); PropChanged("DisplayImage"); }
		}

		public Ozelot() : base(10)
		{
			Type = EntityTypes.Ozelot;
		}

		public override string Display => base.Display + CatType;

		public override string DisplayImage => string.Format("/StackingEntities.Resources;component/Images/Mobs/Ozelot/Ozelot_{0:D}.png", CatType);

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (CatType != CatType.Ocelot)
				b.AppendFormat("CatType:{0:D},", CatType);

			return b.ToString();
		}
	}

	public enum CatType
	{
		Ocelot,
		Tuxedo,
		Tabby,
		Siamese
	}
}
