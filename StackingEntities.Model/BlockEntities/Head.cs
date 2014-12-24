using System;
using System.Text;
using StackingEntities.Model.BlockEntities.BaseClasses;
using StackingEntities.Model.Enums;
using StackingEntities.Model.Helpers;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.BlockEntities
{
	[Serializable]
	public class Head : BlockEntityBase
	{
		private SkullType _type = SkullType.Inherit;

		#region Properties

		[EntityDescriptor("Skull Options", "Skull Type")]
        public SkullType Type
		{
			get { return _type; }
			set { _type = value; PropChanged("IsPlayerHead"); }
		}

		[EntityDescriptor("Skull Options", "Player Name", "Name of the player to display the skin of.", "IsPlayerHead")]
		public string ExtraType { get; set; }

		[EntityDescriptor("Skull Options", "Rotation")]
        public SignRotation Rotation { get; set; } = SignRotation.Inherit;

		public bool IsPlayerHead => Type == SkullType.Player;

		#endregion

		#region Inherited

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(false));

			if (Type != SkullType.Inherit)
				b.AppendFormat("SkullType:{0:D}b,", Type);

			if (Rotation != SignRotation.Inherit)
				b.AppendFormat("Rot:{0:D}b,", Rotation);

			if (Type == SkullType.Player && !string.IsNullOrWhiteSpace(ExtraType))
				b.AppendFormat("ExtraType:\"{0}\",", ExtraType.EscapeJsonString());

			return b.ToString();

		}

		#endregion
	}
}
