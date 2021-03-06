using System;

namespace StackingEntities.Desktop.ViewModel
{
	public class DisplayOption
	{
		public DisplayOption(string rName, string pName, Type pType, 
			string desc = null, object min = null, object max = null,
			bool mLine = false, string epName = null, bool fSize = false, 
			string dgRowPath = null, bool wide = false)
		{
			ReadableName = rName;
			PropertyName = pName;
			PropertyType = pType;
			//DataContext = dContext;

			Minimum = min;
			Maximum = max;
			Multiline = mLine;

			EnabledPropertyName = epName;

			FixedSize = fSize;

			DataGridRowHeaderPath = dgRowPath;

			Description = desc;

			Wide = wide;
		}

		public string DataGridRowHeaderPath { get; set; }

		public bool FixedSize { get; set; }

		public string ReadableName { get; set; }

		public string PropertyName { get; set; }

		public Type  PropertyType { get; set; }

		public object Minimum { get; set; }

		public object Maximum { get; set; }

		public bool Multiline { get; set; }
		public bool Wide { get; set; }

		//public object DataContext { get; set; }

		public string EnabledPropertyName { get; set; }

		public string Description { get; set; }
	}
}