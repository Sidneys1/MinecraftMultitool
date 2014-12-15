using System;
using System.ComponentModel;

namespace StackingEntities.Model.Objects
{
	[Serializable]
	public class JsonText
	{
		[DisplayName(@"Text")]
		public string Text { get; set; }

		public override string ToString()
		{
			return Text;
		}
	}
}