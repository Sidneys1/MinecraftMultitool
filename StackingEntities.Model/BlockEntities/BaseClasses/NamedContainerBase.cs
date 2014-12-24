using System;
using System.Text;
using StackingEntities.Model.Helpers;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.BlockEntities.BaseClasses
{
	[Serializable]
	public abstract class NamedContainerBase : BlockEntityBase
	{
		#region Properties

		[EntityDescriptor("GUI Block Options", "Custom Name", "Override the GUI Name")]
		public string CustomName { get; set; }

		#endregion

		//protected NamedContainerBase(string id) : base(id)
		//{ }

		#region Inherited

		public override string GenerateJson(bool topLevel)
		{
			if (string.IsNullOrWhiteSpace(CustomName)) return base.GenerateJson(false);

			var b = new StringBuilder(base.GenerateJson(false));

			b.AppendFormat("CustomName:\"{0}\",", CustomName.EscapeJsonString());

			return b.ToString();
		}

		#endregion

	}
}
