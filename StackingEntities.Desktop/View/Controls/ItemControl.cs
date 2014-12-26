using System.Windows;
using System.Windows.Controls;
using StackingEntities.Model.Items;
using UIList = System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<StackingEntities.Desktop.ViewModel.DisplayOption>>;

namespace StackingEntities.Desktop.View.Controls
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

			SetValue(Grid.ColumnSpanProperty, ent.SlotTitle != null ? 2 : 1);

			#region Extract Options

			foreach (var jsonAble in ent.Tag)
			{
				var dict = new UIList();
				OptionsGenerator.ExtractOptions(jsonAble, dict);
				OptionsGenerator.AddGroups(dict, true).ForEach(o =>
				{
					o.DataContext = jsonAble;
					MoreOptsBox.Children.Add(o);
				});
			}

			#endregion
		}
	}
}
