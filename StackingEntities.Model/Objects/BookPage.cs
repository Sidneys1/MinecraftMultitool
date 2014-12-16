using System;

namespace StackingEntities.Model.Objects
{
	[Serializable]
	public class BookPage
	{
		public JsonTextElement Text { get; } = new JsonTextElement { Title = "Book Page Options"};

		public override string ToString()
		{
			return Text.GenerateJson(false);
		}
	}
}