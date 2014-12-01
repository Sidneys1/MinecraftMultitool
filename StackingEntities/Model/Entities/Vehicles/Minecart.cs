using System.Text;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Vehicles
{
	internal class Minecart : EntityBase
	{
		public Minecart() { Type = EntityTypes.Minecart; }

		#region Cargo

		bool _customDisplayTile;
		[Property("Minecart Options", "Display Cargo")]
		public bool CustomDisplayTile
		{
			get { return _customDisplayTile; }
			set
			{
				_customDisplayTile = value;
				PropChanged();
				PropChanged("Display");
			}
		}

		string _displayTile = "";
		[Property("Minecart Options", "Cargo ID")]
		public string DisplayTile
		{
			get { return _displayTile; }
			set
			{
				_displayTile = value;
				PropChanged();
				PropChanged("Display");
			}
		}

		[Property("Minecart Options", "Cargo Data"), MinMax(0, 15)]
		public int DisplayData { get; set; }

		[Property("Minecart Options", "Cargo Offset")]
		public int DisplayOffset { get; set; }

		#endregion

		[Property("Minecart Options", "Custom Name")]
		public string CustomName { get; set; }

		#region UI

		public override string Display => "Minecart" + (CustomDisplayTile ? " " + DisplayTile : "");

		public override string DisplayImage => "/StackingEntities;component/Images/Vehicles/Minecart.png";

		#endregion

		#region Process

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (!string.IsNullOrWhiteSpace(CustomName))
				b.Append(string.Format("CustomName:\"{0}\",", CustomName));

			if (CustomDisplayTile)
				b.Append(string.Format("CustomDisplayTile:1b,DisplayTile:\"{0}\",DisplayData:{1},DisplayOffset:{2},", DisplayTile, DisplayData, DisplayOffset));

			return b.ToString();
		}

		#endregion
	}
}