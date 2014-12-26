using System;
using System.Text;
using StackingEntities.Model.Enums;
using StackingEntities.Model.Helpers;
using StackingEntities.Model.Interface;
using StackingEntities.Model.Metadata;
using StackingEntities.Model.Objects.SimpleTypes;
using DoubleList = System.Collections.ObjectModel.ObservableCollection<StackingEntities.Model.Objects.SimpleTypes.SimpleDouble>;

namespace StackingEntities.Model.Entities
{
	[Serializable]
	public abstract class EntityBase : Displayable, IJsonAble
	{
		public EntityType Type { get; set; }

		#region Motion

		[EntityDescriptor("Entity Options", "Velocity", fixedSize: true, dgRowPath: "Name")]
		public DoubleList Velocity { get; } = new DoubleList
		{
			new SimpleDouble("X"),
			new SimpleDouble("Y"),
			new SimpleDouble("Z")
		};

		#endregion

		#region Invulnerable

		bool _invulnerable;
		[EntityDescriptor("Entity Options", "Invulnerable", "Makes this Entity resistant to Damage")]
		public bool Invulnerable
		{
			get { return _invulnerable; }
			set
			{
				_invulnerable = value;
				PropChanged();
				PropChanged("Display");
			}
		}

		#endregion

		#region Fire
		int _fire;
		[EntityDescriptor("Entity Options", "Fire (Ticks)"), MinMax(-1, null)]
		public int Fire
		{
			get { return _fire; }
			set
			{
				_fire = value;
				PropChanged();
				PropChanged("Display");
			}
		}

		#endregion

		#region Silent

		bool _silent;
		[EntityDescriptor("Entity Options", "Silent", "Disable noise for this Entity")]
		public bool Silent
		{
			get { return _silent; }
			set
			{
				_silent = value; PropChanged(); PropChanged("Display");
			}
		}

		#endregion

		#region UI

		public override string Display => (Silent ? "Silent " : "") + (Invulnerable ? "Invulnerable " : "") + (Fire != 0 ? string.Format("Flaming ({0}) ", JsonTools.TicksToTime(Fire)) : "");

		#endregion

		#region Process

		public virtual string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder("{");

			if (!topLevel)
				b.AppendFormat("id:\"{0}\",", Type.ToString().EscapeJsonString());

			if (Invulnerable)
				b.Append("Invulnerable:1b,");

			double Dx = Velocity[0].Value, Dy = Velocity[1].Value, Dz = Velocity[2].Value;
			if (Math.Abs(Dx) > 0 || Math.Abs(Dy) > 0 || Math.Abs(Dz) > 0)
				b.AppendFormat("Motion:[{0:0.0},{1:0.0},{2:0.0}],", Dx, Dy, Dz);

			if (Fire != 0)
				b.AppendFormat("Fire:{0},", Fire);

			if (Silent)
				b.Append("Silent:1b,");

			return b.ToString();
		}

		#endregion
	}
}
