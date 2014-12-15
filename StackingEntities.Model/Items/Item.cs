using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using StackingEntities.Model.Helpers;
using StackingEntities.Model.Interface;
using StackingEntities.Model.Items.ItemTags;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Items
{
	[Serializable]
	public class Item: IJsonAble, INotifyPropertyChanged
	{
		[EntityDescriptor("Item", "Count"), MinMax(byte.MinValue, byte.MaxValue)]
		public int? Count { get; set; } = 1;

		public bool HasCountTag => Count.HasValue;

		public bool CountTagEnabled { get; set; } = true;

		[EntityDescriptor("Item", "Slot"), MinMax(byte.MinValue, byte.MaxValue)]
		public int? Slot { get; set; } = null;

		public bool HasSlotTag => Slot.HasValue;

		public bool SlotTagEnabled { get; set; } = true;

		[EntityDescriptor("Item", "Damage/Data Value"), MinMax(short.MinValue, short.MaxValue)]
		public int? Damage { get; set; } = 0;

		public bool HasDamageTag => Damage.HasValue;

		public bool DamageTagEnabled { get; set; } = true;

		[EntityDescriptor("Item", "id")]
		public string Id
		{
			get { return _id; }
			set { _id = value;
				PropChanged("HasId");
			}
		}

		public bool IdTagEnabled { get; set; } = true;

		public bool GenIdTag { get; set; } = true;

		public ObservableCollection<IJsonAble> Tag = new ObservableCollection<IJsonAble>();
		private string _id;

		public bool HasTags => Tag.Count > 0;

		public string SlotTitle { get; set; } = null;

		public bool CanAddTags { get; set; } = false;

		public bool HasId => !string.IsNullOrWhiteSpace(Id);

		public Item()
		{
			Tag.Add(new ItemTagsGeneral());
			Tag.Add(new ItemTagsBlock());
			Tag.Add(new ItemTagsEnchantments());
			//Tag.Add(new ItemTagsAttributes());
			//Tag.Add(new ItemTagsPotionEffects());
			Tag.Add(new ItemTagsDisplay());
			Tag.Add(new ItemTagsBook());
			//Tag.Add(new ItemTagsPlayerSkulls());
			Tag.Add(new ItemTagsFireworkStar());
			Tag.Add(new ItemTagsMap());
		}

		public Item(bool allTags = true)
		{
			if (!allTags) return;
			Tag.Add(new ItemTagsGeneral());
			Tag.Add(new ItemTagsBlock());
			Tag.Add(new ItemTagsEnchantments());
			//Tag.Add(new ItemTagsAttributes());
			//Tag.Add(new ItemTagsPotionEffects());
			Tag.Add(new ItemTagsDisplay());
			Tag.Add(new ItemTagsBook());
			//Tag.Add(new ItemTagsPlayerSkulls());
			Tag.Add(new ItemTagsFireworkStar());
			Tag.Add(new ItemTagsMap());
		}

		public string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder();

			if (string.IsNullOrWhiteSpace(Id)) return b.ToString();

			if (Count.HasValue && Count != 0)
				b.AppendFormat("Count:{0}b,", Count);
			if (Slot.HasValue)
				b.AppendFormat("Slot:{0}b,", Slot);
			if (Damage.HasValue && Damage != 0)
				b.AppendFormat("Damage:{0}s,", Damage);

			if (GenIdTag)
				b.AppendFormat("id:\"{0}\",", Id.EscapeJsonString());

			if (Tag.Count == 0) return b.ToString();

			var b2 = new StringBuilder("tag:{");

			foreach (var jsonAble in Tag)
			{
				b2.Append(jsonAble.GenerateJson(true));
			}
			if (b2[b2.Length - 1] == ',')
				b2.Remove(b2.Length - 1, 1);
			b2.Append("},");

			if (b2.Length > 7)
				b.Append(b2);
			return b.ToString();
		}

		public override string ToString()
		{
			return string.Format("\"{0}\", C:{1}, DV:{2}{3}", Id.Trim().EscapeJsonString(), Count, Damage, Slot.HasValue ? string.Format(", S:{0}", Slot.Value) :"");
		}
		[field: NonSerialized]
		public event PropertyChangedEventHandler PropertyChanged;

		[Properties.Annotations.NotifyPropertyChangedInvocator]
		protected virtual void PropChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
