using System;
using System.Windows;
using System.Windows.Controls;
using ItemList = System.Collections.ObjectModel.ObservableCollection<StackingEntities.Model.Items.Item>;

namespace StackingEntities.Desktop.View.Controls
{
	/// <summary>
	/// Interaction logic for InventoryControl.xaml
	/// </summary>
	public partial class InventoryControl
	{
		public int InvWidth { get; set; }
		public int InvHeight { get; set; }
		public InventoryControl()
		{
			InitializeComponent();
			DataContextChanged += InventoryControl_DataContextChanged;
		}

		private void InventoryControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			var itemList = DataContext as ItemList;

			if (itemList == null) return;

			invGrid.Children.Clear();
			invGrid.ColumnDefinitions.Clear();
			invGrid.RowDefinitions.Clear();

			if (itemList == null || itemList.Count != (InvWidth * InvHeight))
				throw new IndexOutOfRangeException("What the hell, Steve?");

			for (var i = 0; i < InvWidth; i++)
			{
				invGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
			}

			for (var i = 0; i < InvHeight; i++)
			{
				invGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
			}

			for (var x = 0; x < InvWidth; x++)
			{
				for (var y = 0; y < InvHeight; y++)
				{
					var itemDrop = new ItemDropdown { DataContext = itemList[(y * InvWidth) + x] };
					itemDrop.SetValue(Grid.ColumnProperty, x); itemDrop.SetValue(Grid.RowProperty, y);
					invGrid.Children.Add(itemDrop);
				}
			}
		}
	}
}
