using System.Text;

namespace StackingEntities.Entities.Mobs
{
	internal abstract class TameableMobBase : BreedableMobBase
	{
		#region Appearance

		string _owner = "";
		[Property("Tameable Mob Options", "Owner (Player)")]
		public string Owner
		{
			get { return _owner; }
			set
			{
				_owner = value;
				PropChanged();
				PropChanged("Display");
				PropChanged("DisplayImage");
			}
		}

		[Property("Tameable Mob Options", "Is Sitting")]
		public bool Sitting { get; set; }

		#endregion

		#region Process

		public override string GenerateJSON(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJSON(topLevel));

			if (!string.IsNullOrWhiteSpace(Owner))
				b.Append(string.Format("Owner:\"{0}\",", Owner));

			if (Sitting)
				b.Append("Sitting:1,");

			return b.ToString();
		}

		#endregion
	}
}