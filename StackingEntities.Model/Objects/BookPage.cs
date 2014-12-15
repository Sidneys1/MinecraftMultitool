using System;
using System.ComponentModel;

namespace StackingEntities.Model.Objects
{
	[Serializable]
	public class BookPage
	{
		public JsonTextElement Text { get; } = new JsonTextElement { Title = "Book Page Options", Text = "Text"};

		public override string ToString()
		{
			return Text.GenerateJson(false);
		}
	}
}