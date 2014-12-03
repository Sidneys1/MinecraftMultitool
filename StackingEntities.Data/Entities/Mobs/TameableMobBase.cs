using System.Text;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Mobs
{
	public abstract class TameableMobBase : BreedableMobBase
	{
		#region Appearance

		string _owner = "";
		private bool _sitting;

		[EntityDescriptor("Tameable Mob Options", "Owner (Player)")]
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

		[EntityDescriptor("Tameable Mob Options", "Is Sitting")]
		public bool Sitting
		{
			get { return _sitting; }
			set { _sitting = value; PropChanged("Display");
			}
		}

		#endregion

		protected TameableMobBase(int baseHealth) :base(baseHealth)
		{ }

		#region Process

		public override string Display => base.Display + (Sitting ? "Sitting " : "") + (string.IsNullOrWhiteSpace(_owner)?"" :"Tamed ");

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (!string.IsNullOrWhiteSpace(Owner))
				b.Append(string.Format("Owner:\"{0}\",", Owner));

			if (Sitting)
				b.Append("Sitting:1b,");

			return b.ToString();
		}

		#endregion
	}
}