using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using StackingEntities.Model.Entities;
using StackingEntities.Model.Items;

//using System.Attribute;

namespace StackingEntities.Desktop.Model
{
	[Serializable]
	public class DataModel: INotifyPropertyChanged
	{
		public ObservableCollection<EntityBase> Entities { get; } = new ObservableCollection<EntityBase>();

		public static Item GiveItem { get; set; } = new Item {Count = null, Damage = null, GenIdTag = false};

		[field: NonSerialized] public string SavePath;

		private string _x="~", _y="~", _z="~";
		public string X
		{
			get { return _x; }
			set 
			{
				if (_x == null || !_x.Equals(value))
				{
					_x = value;
					PropChanged("X");
				}
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

		[field:NonSerialized]
		public event PropertyChangedEventHandler PropertyChanged;

		private void PropChanged(string propertyName)
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
	}
}
