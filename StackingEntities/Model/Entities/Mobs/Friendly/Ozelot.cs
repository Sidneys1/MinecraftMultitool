using System.Text;
using StackingEntities.ViewModel;

namespace StackingEntities.Model.Entities.Mobs.Friendly
{
	public class Ozelot : TameableMobBase
	{
		private CatType _catType;

		[Property("Ocelot Options", "Type")]
		public CatType CatType
		{
			get { return _catType; }
			set { _catType = value; PropChanged("Display"); PropChanged("DisplayImage"); }
		}

		public Ozelot()
		{
			Type = EntityTypes.Ozelot;
			Health = 10;
		}

		public override string Display => base.Display + CatType;

		public override string DisplayImage => string.Format("/Images/Mobs/Ozelot/Ozelot_{0:D}.png", CatType);

		public override string GenerateJSON(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJSON(topLevel));

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
