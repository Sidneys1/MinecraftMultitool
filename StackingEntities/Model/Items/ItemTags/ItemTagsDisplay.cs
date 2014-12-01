using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using StackingEntities.Properties.Annotations;
using StackingEntities.ViewModel;

namespace StackingEntities.Model.Items.ItemTags
{
	[Flags]
	public enum DisplayHideFlags
	{
		None = 0,
		Enchantments = 1,
		[Description("Attribute Modifiers")]
		AttribueModifiers = 2,
		Unbreakable = 4,
		[Description("Can Destroy")]
		CanDestroy = 8,
		[Description("Can Place On")]
		CanPlaceOn = 16,
		Other = 32
	}

	public class ItemTagsDisplay : IJsonAble, INotifyPropertyChanged
	{
		[Property("Display", "Custom Name")]
		public string Name { get; set; }

		[Property("Display", "Lore"), MultilineString]
		public string Lore { get; set; }

		public DisplayHideFlags DisplayHideFlags { get; set; } = DisplayHideFlags.None;

		[Property("Display", "Hide Enchantments")]
		public bool DisplayEnchants
		{
			get { return (DisplayHideFlags & DisplayHideFlags.Enchantments) == DisplayHideFlags.Enchantments; }
			set
			{
				if (value)
					DisplayHideFlags |= DisplayHideFlags.Enchantments;
				else
					DisplayHideFlags &= ~DisplayHideFlags.Enchantments;

				OnPropertyChanged("DisplayHideFlags");
			}
		}

		[Property("Display", "Hide Attribute Modifiers")]
		public bool DisplayAttributes
		{
			get { return (DisplayHideFlags & DisplayHideFlags.AttribueModifiers) == DisplayHideFlags.AttribueModifiers; }
			set
			{
				if (value)
					DisplayHideFlags |= DisplayHideFlags.AttribueModifiers;
				else
					DisplayHideFlags &= ~DisplayHideFlags.AttribueModifiers;

				OnPropertyChanged("DisplayHideFlags");
			}
		}

		[Property("Display", "Hide 'Unbreakable'")]
		public bool DisplayUnbreakable
		{
			get { return (DisplayHideFlags & DisplayHideFlags.Unbreakable) == DisplayHideFlags.Unbreakable; }
			set
			{
				if (value)
					DisplayHideFlags |= DisplayHideFlags.Unbreakable;
				else
					DisplayHideFlags &= ~DisplayHideFlags.Unbreakable;

				OnPropertyChanged("DisplayHideFlags");
			}
		}

		[Property("Display", "Hide 'Can Destroy'")]
		public bool DisplayCanDestroy
		{
			get { return (DisplayHideFlags & DisplayHideFlags.CanDestroy) == DisplayHideFlags.CanDestroy; }
			set
			{
				if (value)
					DisplayHideFlags |= DisplayHideFlags.CanDestroy;
				else
					DisplayHideFlags &= ~DisplayHideFlags.CanDestroy;

				OnPropertyChanged("DisplayHideFlags");
			}
		}

		[Property("Display", "Hide 'Can Place On'")]
		public bool DisplayCanPlaceOn
		{
			get { return (DisplayHideFlags & DisplayHideFlags.CanPlaceOn) == DisplayHideFlags.CanPlaceOn; }
			set
			{
				if (value)
					DisplayHideFlags |= DisplayHideFlags.CanPlaceOn;
				else
					DisplayHideFlags &= ~DisplayHideFlags.CanPlaceOn;

				OnPropertyChanged("DisplayHideFlags");
			}
		}

		[Property("Display", "Hide Other Info")]
		public bool DisplayOther
		{
			get { return (DisplayHideFlags & DisplayHideFlags.Other) == DisplayHideFlags.Other; }
			set
			{
				if (value)
					DisplayHideFlags |= DisplayHideFlags.Other;
				else
					DisplayHideFlags &= ~DisplayHideFlags.Other;

				OnPropertyChanged("DisplayHideFlags");
			}
		}

		public int Color => Blue | (Green << 8) | (Red << 16);

		[Property("Leather Armor Color", "Red"), MinMax(0, 255)]
		public int Red { get; set; }
		[Property("Leather Armor Color", "Green"), MinMax(0, 255)]
		public int Green { get; set; }
		[Property("Leather Armor Color", "Blue"), MinMax(0, 255)]
		public int Blue { get; set; }


		public string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder();

			var b2 = new StringBuilder("display:{");

			if (!string.IsNullOrWhiteSpace(Name))
				b2.AppendFormat("Name:\"{0}\",", JsonTools.EscapeStringValue(Name));

			if (Color != 0)
				b2.AppendFormat("color:{0},", Color);

			if (!string.IsNullOrWhiteSpace(Lore))
			{
				var lines = Lore.Split(new[] {Environment.NewLine, "\r", "\n"}, StringSplitOptions.None);

				b2.Append("Lore:[");

				foreach (var line in lines)
				{
					b2.AppendFormat("\"{0}\",", JsonTools.EscapeStringValue(line));
				}
				b2.Remove(b2.Length - 1, 1);
				b2.Append("],");
			}
			b2.Remove(b2.Length - 1, 1);
			b2.Append("},");

			if (b2.Length > 11)
				b.Append(b2);

			if (DisplayHideFlags != DisplayHideFlags.None)
				b.AppendFormat("HideFlags:{0},", (int) DisplayHideFlags);

			return b.ToString();
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}