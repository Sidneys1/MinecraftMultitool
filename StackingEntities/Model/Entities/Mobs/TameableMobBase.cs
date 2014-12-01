using System.Text;
using StackingEntities.ViewModel;

namespace StackingEntities.Model.Entities.Mobs
{
	public abstract class TameableMobBase : BreedableMobBase
	{
		#region Appearance

		string _owner = "";
		private bool _sitting;

		[Property("Tameable Mob Options", "Owner (Player)")]
		public string Owner
		{
			get { return _owner; }
			set
			{
				_owner = value;
				PropChanged("Display");
				PropChanged("DisplayImage");
			}
		}

		[Property("Tameable Mob Options", "Is Sitting")]
		public bool Sitting
		{
			get { return _sitting; }
			set { _sitting = value; PropChanged("Display");
			}
		}

		#endregion

		#region Process

		public override string Display => base.Display + (Sitting ? "Sitting " : "") + (string.IsNullOrWhiteSpace(_owner)?"" :"Tamed ");

		public override string GenerateJSON(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJSON(topLevel));

			if (!string.IsNullOrWhiteSpace(Owner))
				b.Append(string.Format("Owner:\"{0}\",", Owner));

			if (Sitting)
				b.Append("Sitting:1b,");

			return b.ToString();
		}

		#endregion
	}
}