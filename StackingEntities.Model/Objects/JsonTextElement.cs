using System;
using System.Collections.ObjectModel;
using System.Text;
using StackingEntities.Model.Enums;
using StackingEntities.Model.Interface;
using StackingEntities.Model.SimpleTypes;

namespace StackingEntities.Model.Objects
{
	[Serializable]
	public class JsonTextElement : IJsonAble
	{
		public string Text { get; set; }

		public string Translate { get; set; }
		public ObservableCollection<SimpleString> TranslateWith { get; } = new ObservableCollection<SimpleString>();
		
		public string ScoreName { get; set; }
		public string ScoreObjective { get; set; }
		public string ScoreValue { get; set; }

		public string Selector { get; set; }
		 
		public TextType TextType { get; set; } = TextType.Text;

		public TextColor Color { get; set; } = TextColor.Inherit;
		public bool? Bold { get; set; }
		public bool? Underlined { get; set; }
		public bool? Italic { get; set; }
		public bool? Strikethrough { get; set; }
		public bool? Obfuscated { get; set; }

		public JsonTextClickEvent ClickEvent { get; set; } = JsonTextClickEvent.None;
		public string ClickEventValue { get; set; }

		public JsonTextHoverEvent HoverEvent { get; set; } = JsonTextHoverEvent.None;
		public string HoverEventValue { get; set; }

		public ObservableCollection<JsonTextElement> Extra { get; } = new ObservableCollection<JsonTextElement>();

		public string InsertionText { get; set; }

		public string Title { get; set; } = null;

		public string GenerateJson(bool topLevel)
		{
			throw new System.NotImplementedException();
			// TODO: Generate JSON
		}
	}
}