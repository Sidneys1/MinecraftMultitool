using System;
using System.ComponentModel;

namespace StackingEntities.Model.Items.ItemTags
{
	[Serializable]
	public class Page
	{
		[DisplayName(@"Text")]
		public string Text { get; set; }

		public override string ToString()
		{
			return Text;
		}
	}
}