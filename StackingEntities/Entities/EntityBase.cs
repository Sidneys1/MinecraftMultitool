using System;
using System.ComponentModel;
using System.Text;

namespace StackingEntities.Entities
{
	public abstract class EntityBase: Displayable, IJsonAble
	{
		public EntityTypes Type { get; set; }

		#region Motion

		[Property("Entity Options", "Velocity X")]
		public double Dx { get; set; }

		[Property("Entity Options", "Velocity Y")]
		public double Dy { get; set; }

		[Property("Entity Options", "Velocity Z")]
		public double Dz { get; set; }

		#endregion

		#region Invulnerable

		bool _invulnerable;
		[Property("Entity Options", "Invulnerable")]
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
		[Property("Entity Options", "Fire (Ticks)"), MinMax(-1, null)]
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

		#region UI

		public override string Display => (Invulnerable ? "Invulnerable " : "") + (Fire != 0 ? "Flaming " : "");

		#endregion

		#region Process

// ReSharper disable once InconsistentNaming
		public virtual string GenerateJSON(bool topLevel)
		{
			var b = new StringBuilder("{");

			if (!topLevel)
				b.AppendFormat("id:\"{0}\",", JsonTools.EscapeStringValue(Type.ToString()));

			if (Invulnerable)
				b.Append("Invulnerable:1b,");

			if (Math.Abs(Dx) > 0 || Math.Abs(Dy) > 0 || Math.Abs(Dz) > 0)
				b.Append(string.Format("Motion:[{0:0.0},{1:0.0},{2:0.0}],", Dx, Dy, Dz));

			if (Fire != 0)
				b.Append(string.Format("Fire:{0},", Fire));

			return b.ToString();
		}

		#endregion
	}

	internal enum Dyes
	{
		Black = 15,
		Red = 14,
		Green = 13,
		Brown = 12,
		Blue = 11,
		Purple = 10,
		Cyan = 9,
		[Description("Light Gray")]
		LightGray = 8,
		Gray = 7,
		Pink = 6,
		Lime = 5,
		Yellow =4,
		[Description("Light Blue")]
		LightBlue = 3,
		Magenta = 2,
		Orange = 1,
		White = 0
	}

	internal enum Direction
	{
		North = 2,
		South = 0,
		East = 3,
		West = 1
	}

	[Flags]
	internal enum DisabledSlots
	{
		None=0,
		Remove=1,
		Replace=2,
		Place=4,
		[Description("Remove & Replace")]
		RemoveReplace = 3,
		[Description("Remove & Place")]
		RemovePlace = 5,
		[Description("Replace and Place")]
		ReplacePlace = 6,
		All = 7
	}
}
