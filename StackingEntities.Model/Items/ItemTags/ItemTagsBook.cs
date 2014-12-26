using System;
using System.Text;
using StackingEntities.Model.Enums;
using StackingEntities.Model.Helpers;
using StackingEntities.Model.Interface;
using StackingEntities.Model.Metadata;
using BookPageList = System.Collections.ObjectModel.ObservableCollection<StackingEntities.Model.Objects.BookPage>;

namespace StackingEntities.Model.Items.ItemTags
{
	[Serializable]
	public class ItemTagsBook : IJsonAble
	{
		[EntityDescriptor("Book", "Generation")]
		public BookGeneration Generation { get; set; } = BookGeneration.Original;

		[EntityDescriptor("Book", "Author")]
		public string Author { get; set; }

		[EntityDescriptor("Book", "Title")]
		public string Title { get; set; }

		[EntityDescriptor("Book", "Pages")]
		public BookPageList Pages { get; set; } = new BookPageList(); 

		public string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder();

			if (Generation != BookGeneration.Original)
				b.AppendFormat("generation:{0:D},", Generation);

			if (!string.IsNullOrWhiteSpace(Author))
				b.AppendFormat("author:\"{0}\",", Author.EscapeJsonString());

			if (!string.IsNullOrWhiteSpace(Title))
				b.AppendFormat("title:\"{0}\",", Title.EscapeJsonString());

			if (Pages.Count == 0) return b.ToString();

			var b2 = new StringBuilder("pages:[");
			for (var i = 0; i < Pages.Count; i++)
			{
				var line = Pages[i];
				b2.AppendFormat("{0}:\"{1}\",", i, line.ToString().EscapeJsonString());
			}

			b2.Remove(b2.Length - 1, 1);
			b2.Append("],");

			if (b2.Length > 9)
				b.Append(b2);

			return b.ToString();
		}

	}
}
