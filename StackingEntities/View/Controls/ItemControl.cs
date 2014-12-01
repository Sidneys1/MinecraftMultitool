using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using StackingEntities.Model.Items;
using StackingEntities.Model.Metadata;
using StackingEntities.ViewModel;

namespace StackingEntities.View.Controls
{
	/// <summary>
	/// Interaction logic for ItemControl.xaml
	/// </summary>
	public partial class ItemControl
	{
		public ItemControl()
		{
			InitializeComponent();
		}

		private void MoreOptsBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			MoreOptsBox.Children.Clear();

			if (!(DataContext is Item)) return;

			var ent = (Item)DataContext;

			var dict = new Dictionary<string, List<DisplayOption>>();

			#region Extract Options

			ExtractOptions(ent, dict);

			#endregion

			#region Add Groups

			foreach (var str in dict.Keys)
			{
				var g = new Expander { Header = str, Margin = new Thickness(10, 0, 10, 0) };

				var grid = new Grid();
				grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0, GridUnitType.Auto) });
				grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
				g.Content = grid;

				#region Add Controls

				MoreOptsBox.Children.Add(OptionsGenerator.AddGroup(str, dict, true, true));

				#endregion
			}

			#endregion
		}

		private static void ExtractOptions(Item ent, Dictionary<string, List<DisplayOption>> dict)
		{
			foreach (var jsonAble in ent.Tag)
			{
				var props = jsonAble.GetType().GetProperties();
				foreach (var info in props.Reverse())
				{
					if (!Attribute.IsDefined(info, typeof (PropertyAttribute))) continue;
					var prop = (PropertyAttribute) info.GetCustomAttribute(typeof (PropertyAttribute));
					if (!dict.ContainsKey(prop.Category))
						dict.Add(prop.Category, new List<DisplayOption>());

					object min = null, max = null;
					var multiline = Attribute.IsDefined(info, typeof (MultilineStringAttribute));

					if (Attribute.IsDefined(info, typeof (MinMaxAttribute)))
					{
						var att = (MinMaxAttribute) info.GetCustomAttribute(typeof (MinMaxAttribute));
						min = att.Minimum;
						max = att.Maximum;
					}

					dict[prop.Category].Insert(0,
						new DisplayOption(prop.Name, info.Name, info.PropertyType, jsonAble, min, max, multiline, prop.IsEnabledPath));
				}
			}
		}
	}
}
