using System;
using System.Text;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.BlockEntities.BaseClasses
{
	[Serializable]
	public abstract class LockedContainerBase : NamedContainerBase
	{
		#region Properties

		[EntityDescriptor("GUI Block Options", "Lock")]
		public string Lock { get; set; }

		#endregion

		//protected LockedContainerBase(string id) : base(id)
		//{
		//}

		#region Inherited

		public override string GenerateJson(bool topLevel)
		{
			if (string.IsNullOrWhiteSpace(Lock)) return base.GenerateJson(false);

			var b = new StringBuilder(base.GenerateJson(false));
			b.AppendFormat("Lock:\"{0}\",", Lock);

			return b.ToString();

		}

		#endregion

	}
}
