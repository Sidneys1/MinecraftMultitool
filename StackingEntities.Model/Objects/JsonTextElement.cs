using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using StackingEntities.Model.Annotations;
using StackingEntities.Model.Enums;
using StackingEntities.Model.Helpers;
using StackingEntities.Model.Interface;
using StackingEntities.Model.Items;
using StackingEntities.Model.SimpleTypes;

namespace StackingEntities.Model.Objects
{
	[Serializable]
	public class JsonTextElement : IJsonAble, INotifyPropertyChanged
	{
		private JsonTextHoverEvent _hoverEvent = JsonTextHoverEvent.None;
		public string Text { get; set; }

		public string Translate { get; set; }
		public ObservableCollection<SimpleString> TranslateWith { get; } = new ObservableCollection<SimpleString>();

		public string ScoreName { get; set; }
		public string ScoreObjective { get; set; }
		public string ScoreValue { get; set; }

		public string Selector { get; set; }

		private JsonTextType _textType = JsonTextType.Text;
		public JsonTextType TextType
		{
			get { return _textType; }
			set { _textType = value; PropChanged("TextType"); }
		}

		public JsonTextColor Color { get; set; } = JsonTextColor.Inherit;
		public bool? Bold { get; set; }
		public bool? Underlined { get; set; }
		public bool? Italic { get; set; }
		public bool? Strikethrough { get; set; }
		public bool? Obfuscated { get; set; }

		private JsonTextClickEvent _clickEvent = JsonTextClickEvent.None;
		public JsonTextClickEvent ClickEvent
		{
			get { return _clickEvent; }
			set { _clickEvent = value; PropChanged("ClickEvent"); }
		}

		public string ClickEventValue { get; set; }

		public JsonTextHoverEvent HoverEvent
		{
			get { return _hoverEvent; }
			set
			{
				_hoverEvent = value;
				if (value == JsonTextHoverEvent.show_text)
				{
					if (HoverEventText == null)
					{
						HoverEventText = _hoverEventTextBackup ?? new JsonTextElement { Title = "Hover Text" };
						PropChanged("HoverEventText");
					}
				}
				else if (HoverEventText != null)
				{
					_hoverEventTextBackup = HoverEventText;
					HoverEventText = null;
					PropChanged("HoverEventText");
				}


				PropChanged("HoverEvent");
			}
		}

		private JsonTextElement _hoverEventTextBackup;


		public JsonTextElement HoverEventText { get; private set; }
		public string HoverEventEntityName { get; set; }
		public AchievementName HoverEventAchievementName { get; set; }
		public Item HoverEventItem { get; } = new Item { Count = null, Slot = null };
		public EntityType HoverEntityType { get; set; }
		public string HoverEntityId { get; set; }

		public ObservableCollection<JsonTextElement> Extra { get; } = new ObservableCollection<JsonTextElement>();

		public string InsertionText { get; set; }

		public string Title { get; set; }

		public string GenerateJson(bool topLevel)
		{
			return ComputeJson(this);
		}

		// Currently do not need.
		//public bool HasValue()
		//{
		//	var ret = false;

		//	switch (TextType)
		//	{
		//		case JsonTextType.Text:
		//			ret |= !string.IsNullOrWhiteSpace(Text);
		//			break;

		//		case JsonTextType.Selector:
		//			ret |= !string.IsNullOrWhiteSpace(Selector);
		//			break;

		//		case JsonTextType.Score:
		//			ret |= !string.IsNullOrWhiteSpace(ScoreName);
		//			break;

		//		case JsonTextType.Translate:
		//			ret |= !string.IsNullOrWhiteSpace(Translate);
		//			break;
		//	}

		//	ret |= Color != JsonTextColor.Inherit;

		//	ret |= Bold.HasValue;
		//	ret |= Underlined.HasValue;
		//	ret |= Italic.HasValue;
		//	ret |= Strikethrough.HasValue;
		//	ret |= Obfuscated.HasValue;

		//	ret |= !string.IsNullOrWhiteSpace(InsertionText);

		//	ret |= ClickEvent != JsonTextClickEvent.None;

		//	switch (HoverEvent)
		//	{
		//		case JsonTextHoverEvent.show_text:
		//			ret |= HoverEventText?.HasValue() ?? false;
		//                  break;
		//		case JsonTextHoverEvent.show_item:
		//		case JsonTextHoverEvent.show_achievement:
		//		case JsonTextHoverEvent.show_entity:
		//			ret = true;
		//			break;
		//	}

		//	ret |= Extra.Count > 0;

		//	return ret;
		//}

		private static string ComputeJson(JsonTextElement j)
		{
			var b = new StringBuilder("{");

			switch (j.TextType)
			{
				case JsonTextType.Text:
					b.AppendFormat("text:\"{0}\",", j.Text.EscapeJsonString());
					break;

				case JsonTextType.Selector:
					b.AppendFormat("selector:\"{0}\",", j.Selector.EscapeJsonString());
					break;

				case JsonTextType.Score:
					b.AppendFormat("score:{{name:\"{0}\",objective:\"{1}\"", j.ScoreName.EscapeJsonString(),
						j.ScoreObjective.EscapeJsonString());
					if (!string.IsNullOrWhiteSpace(j.ScoreValue))
						b.AppendFormat(",value:\"{0}\"", j.ScoreValue.EscapeJsonString());
					b.Append("}},");
					break;

				case JsonTextType.Translate:
					b.AppendFormat("translate:\"{0}\",", j.Translate.EscapeJsonString());

					if (j.TranslateWith.Count == 0) break;
					b.Append("with:[");
					foreach (var simpleString in j.TranslateWith)
					{
						b.AppendFormat("\"{0}\",", simpleString.Value.EscapeJsonString());
					}
					if (b[b.Length - 1] == ',')
						b.Remove(b.Length - 1, 1);
					b.Append("],");
					break;
			}

			if (j.Color != JsonTextColor.Inherit)
				b.AppendFormat("color:\"{0}\",", j.Color);

			AppendBoolQ(b, "bold", j.Bold);
			AppendBoolQ(b, "underlined", j.Underlined);
			AppendBoolQ(b, "italic", j.Italic);
			AppendBoolQ(b, "strikethrough", j.Strikethrough);
			AppendBoolQ(b, "obfuscated", j.Obfuscated);

			if (!string.IsNullOrWhiteSpace(j.InsertionText))
				b.AppendFormat("insertion:\"{0}\",", j.InsertionText.EscapeJsonString());

			if (j.ClickEvent != JsonTextClickEvent.None)
			{
				b.AppendFormat("clickEvent:{{action:\"{0}\",value:\"{1}\"}},", j.ClickEvent, j.ClickEventValue.EscapeJsonString());
			}

			switch (j.HoverEvent)
			{
				case JsonTextHoverEvent.show_text:
					b.AppendFormat("hoverEvent:{{action:\"{0}\",value:{1}}},", j.HoverEvent, ComputeJson(j.HoverEventText));
					break;
				case JsonTextHoverEvent.show_item:
					b.AppendFormat("hoverEvent:{{action:\"{0}\",value:\"{1}\"}},", j.HoverEvent, j.HoverEventItem.GenerateJson(false).EscapeJsonString());
					break;
				case JsonTextHoverEvent.show_achievement:
					b.AppendFormat("hoverEvent:{{action:\"{0}\",value:\"achievement.{1}\"}},", j.HoverEvent, j.HoverEventAchievementName);
					break;
				case JsonTextHoverEvent.show_entity:
					b.AppendFormat("hoverEvent:{{action:\"{0}\",value:\"{{type:\\\"{1}\\\",name:\\\"{2}\\\",id:\\\"{3}\\\"}}\"}},",
						j.HoverEvent, j.HoverEntityType, j.HoverEventEntityName.EscapeJsonString(), j.HoverEntityId.EscapeJsonString());
					break;
			}

			if (j.Extra.Count == 0)
			{
				if (b[b.Length - 1] == ',')
					b.Remove(b.Length - 1, 1);
				b.Append("}");

				return b.ToString() == string.Format("{{text:\"{0}\"}}", j.Text.EscapeJsonString()) ? string.Format("\"{0}\"", j.Text.EscapeJsonString()) : b.ToString();
			}

			b.Append("extra:[");
			foreach (var jsonTextElement in j.Extra)
			{
				b.AppendFormat("{0},", ComputeJson(jsonTextElement));
			}
			b.Remove(b.Length - 1, 1);
			b.Append("]}");

			return b.ToString();
		}

		private static void AppendBoolQ(StringBuilder b, string bold, bool? boo)
		{
			if (boo.HasValue)
				b.AppendFormat("{0}:\"{1}\",", bold, boo.Value ? "true" : "false");
		}

		[field: NonSerialized]
		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void PropChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}