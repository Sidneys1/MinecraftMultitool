using System;
using System.Text;
using StackingEntities.Model.Helpers;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Projectiles.BaseClasses
{
	[Serializable]
	public abstract class OwnedProjectileBase : ShakingProjectileBase
	{
		[EntityDescriptor("Projectile Options", "Thrown By <Username>")]
		public string OwnerName { get; set; }

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (!string.IsNullOrWhiteSpace(OwnerName))
				b.AppendFormat("ownerName:\"{0}\",", OwnerName.EscapeJsonString());

			return b.ToString();
		}
	}
}
