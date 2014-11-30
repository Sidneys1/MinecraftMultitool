using System.Collections.ObjectModel;
using System.ComponentModel;
using StackingEntities.Entities;

namespace StackingEntities
{
	internal class DataModel: INotifyPropertyChanged
	{
		public EntityTypes EType { get; set; }

		public DataModel()
		{
			Entities = new ObservableCollection<EntityBase>();
		}

		public ObservableCollection<EntityBase> Entities { get; private set; }

		private string _x, _y, _z;
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
				if (_y == null || !_y.Equals(value))
				{
					_y = value;
					PropChanged("Y");
				}
			}
		}
		public string Z
		{
			get { return _z; }
			set
			{
				if (_z == null || !_z.Equals(value))
				{
					_z = value;
					PropChanged("Z");
				}
			}
		}

		#region Property Changed

		public event PropertyChangedEventHandler PropertyChanged;

		private void PropChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion
	}
}
