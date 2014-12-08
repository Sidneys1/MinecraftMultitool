using System;
using System.Collections;
using System.Windows;

namespace StackingEntities.Desktop.View.Controls
{
	/// <summary>
	/// Interaction logic for ItemListControl.xaml
	/// </summary>
	public partial class ItemListControl
	{
		private IList _context;
		private Type _listType;

		public ItemListControl()
		{
			InitializeComponent();
			DataContextChanged += ItemListControl_DataContextChanged;
		}

		private void ItemListControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (!(DataContext is IList)) return;
			_listType = DataContext.GetType().GetGenericArguments()[0];
			_context = (IList) DataContext;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var item = ItemsControl.SelectedItem;
			if (item != null && _context.Contains(item))
				_context.Remove(item);
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			var item = Activator.CreateInstance(_listType);
			_context.Add(item);
		}
	}
}
