using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using StackingEntities.Desktop.Model.Enums;
using StackingEntities.Model.Annotations;
using StackingEntities.Model.BlockEntities;
using StackingEntities.Model.BlockEntities.BaseClasses;
using StackingEntities.Model.Helpers;
using StackingEntities.Model.Items;
using StackingEntities.Model.Objects;
using EntityBaseList = System.Collections.ObjectModel.ObservableCollection<StackingEntities.Model.Entities.EntityBase>;

namespace StackingEntities.Desktop.Model
{
	[Serializable]
	public class DataModel : INotifyPropertyChanged
	{
		public EntityBaseList Entities { get; } = new EntityBaseList();

		#region Static

		public Item GiveItem { get; set; } = new Item { Count = null, Damage = null, GenIdTag = false };
		public int GiveCount { get; set; } = 1;
		public int GiveDv { get; set; }
		public string GiveTarget { get; set; } = "@p";

		public TextCommandType TextCommandType { get; set; }
		public string TellRawTarget { get; set; } = "@a";
		public JsonTextElement TellrawText { get; } = new JsonTextElement();

		private BlockEntityBase _blockDataModel = new Banner();

		public BlockEntityBase BlockDataModel { get { return _blockDataModel; } set { _blockDataModel = value; PropChanged("BlockDataModel"); } }

		public string BlockDataX { get; set; } = "~";
		public string BlockDataY { get; set; } = "~";
		public string BlockDataZ { get; set; } = "~";
		#endregion


		[field: NonSerialized]
		public string SavePath;

		private string _x = "~", _y = "~", _z = "~";


		public string X
		{
			get { return _x; }
			set
			{
				if (_x != null && _x.Equals(value)) return;
				_x = value;
				PropChanged("X");
			}
		}
		public string Y
		{
			get { return _y; }
			set
			{
				if (_y != null && _y.Equals(value)) return;
				_y = value;
				PropChanged("Y");
			}
		}
		public string Z
		{
			get { return _z; }
			set
			{
				if (_z != null && _z.Equals(value)) return;
				_z = value;
				PropChanged("Z");
			}
		}

		#region Property Changed

		[field: NonSerialized]
		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void PropChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion

		public string GenerateSummon()
		{
			var b = new StringBuilder("/summon ");
			if (Entities.Count > 0)
			{
				b.Append(Entities[0].Type);

				b.Append(" " + X + " ");
				b.Append(Y + " ");
				b.Append(Z + " ");

				var data = new StringBuilder(Entities[0].GenerateJson(true));

				foreach (var ent in Entities.Where(ent => ent != Entities[0]))
				{
					if (data[data.Length - 1] != '{' && data[data.Length - 1] != ',')
						data.Append(',');

					data.Append("Riding:");
					data.Append(ent.GenerateJson(false));
				}

				if (data[data.Length - 1] == ',')
					data.Remove(data.Length - 1, 1);

				for (var depth = Entities.Count - 1; depth > 0; depth--)
				{
					data.Append("}");
				}

				if (data[data.Length - 1] == '{')
					data.Clear();

				if (data.Length > 0)
					data.Append("}");

				b.Append(data);
			}
			var s = b.ToString();
			return s;
		}

		public void Save(string path = null)
		{
			if (path == null)
				path = SavePath;

			using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
			{
				var f = new BinaryFormatter();

				f.Serialize(fs, this);
				fs.Flush();
				fs.Close();
			}

			SavePath = path;
		}

		public static DataModel Open(string path)
		{
			DataModel m;
			using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
			{
				var f = new BinaryFormatter();

				m = (DataModel)f.Deserialize(fs);
				m.SavePath = path;
				fs.Close();
			}
			return m;
		}

		public string GenerateGive()
		{
			var b = new StringBuilder();

			b.AppendFormat("/give {0} {1} {2} {3} ", GiveTarget.EscapeJsonString(),
				GiveItem.Id.EscapeJsonString(), GiveCount, GiveDv);

			var b2 = new StringBuilder();

			foreach (var jsonAble in GiveItem.Tag)
			{
				b2.Append(jsonAble.GenerateJson(true));
			}
			if (b2.Length > 0 && b2[b2.Length - 1] == ',')
				b2.Remove(b2.Length - 1, 1);

			if (b2.Length > 0)
				b.AppendFormat("{{{0}}}", b2);

			var s = b.ToString();
			return s;
		}

		public string GenerateJsonText()
		{
			var b = new StringBuilder("/");

			switch (TextCommandType)
			{
				case TextCommandType.Tellraw:
					b.AppendFormat("tellraw {0} ", TellRawTarget);
					break;
				case TextCommandType.Title:
					b.AppendFormat("title {0} title ", TellRawTarget);
					break;
				case TextCommandType.Subtitle:
					b.AppendFormat("title {0} subtitle ", TellRawTarget);
					break;
			}

			b.Append(TellrawText.GenerateJson(false));

			return b.ToString();
		}

		public string GenerateBlockdata()
		{
			var generateJson = BlockDataModel.GenerateJson(false);
			if (generateJson.Length == 1) generateJson = string.Empty;
			else
			{
				generateJson = generateJson.Remove(generateJson.Length - 1, 1);
				generateJson += "}";
			}

			return string.Format("/blockdata {0} {1} {2} {3}", BlockDataX, BlockDataY, BlockDataZ, generateJson);
		}
	}
}
