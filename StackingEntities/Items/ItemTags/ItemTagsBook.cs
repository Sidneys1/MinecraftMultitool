using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace StackingEntities.Items.ItemTags
{
	public class ItemTagsBook : IJsonAble
	{
		[Property("Book", "Generation")]
		public BookGeneration Generation { get; set; } = BookGeneration.Original;

		[Property("Book", "Author")]
		public string Author { get; set; }

		[Property("Book", "Title")]
		public string Title { get; set; }

		[Property("Book", "Pages")]
		public List<Page> Pages { get; set; } = new List<Page>(); 

		public string GenerateJSON(bool topLevel)
		{
			var b = new StringBuilder();

			if (Generation != BookGeneration.Original)
				b.AppendFormat("generation:{0:D},", Generation);

			if (!string.IsNullOrWhiteSpace(Author))
				b.AppendFormat("author:\"{0}\",", JsonTools.EscapeStringValue(Author));

			if (!string.IsNullOrWhiteSpace(Title))
				b.AppendFormat("title:\"{0}\",", JsonTools.EscapeStringValue(Title));

			if (Pages.Count == 0) return b.ToString();

			var b2 = new StringBuilder("pages:[");
			foreach (var line in Pages)
			{
				b2.AppendFormat("\"{0}\",", JsonTools.EscapeStringValue(line.ToString()));
			}

			b2.Remove(b2.Length - 1, 1);
			b2.Append("],");

			if (b2.Length > 9)
				b.Append(b2);

			return b.ToString();
		}

	}

	public enum BookGeneration
	{
		Original,
		Copy,
		[Description("Copy of a Copy")]
		CopyOfCopy,
		Tattered
	}

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
