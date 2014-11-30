using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using StackingEntities.Items;
using Xceed.Wpf.Toolkit;

namespace StackingEntities.Controls
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

			var ent = (Item) DataContext;

			var dict = new Dictionary<string, List<Tuple<string, string, Type, object, object, object>>>();

			#region Extract Options

			foreach (var jsonAble in ent.Tag)
			{
				var props = jsonAble.GetType().GetProperties();
				foreach (var info in props.Reverse())
				{
					if (!Attribute.IsDefined(info, typeof(PropertyAttribute))) continue;
					var prop = (PropertyAttribute)info.GetCustomAttribute(typeof(PropertyAttribute));
					if (!dict.ContainsKey(prop.Category))
						dict.Add(prop.Category, new List<Tuple<string, string, Type, object, object, object>>());

					object min = null, max = null;

					if (Attribute.IsDefined(info, typeof(MinMaxAttribute)))
					{
						var att = (MinMaxAttribute)info.GetCustomAttribute(typeof(MinMaxAttribute));
						min = att.Minimum;
						max = att.Maximum;
					}

					if (Attribute.IsDefined(info, typeof(MultilineStringAttribute)))
					{
						min = "Multiline";
					}

					dict[prop.Category].Insert(0, new Tuple<string, string, Type, object, object, object>(prop.Name, info.Name, info.PropertyType, min, max, jsonAble));
				}
			}
			

			#endregion

			#region Add Groups

			foreach (var str in dict.Keys)
			{
				var g = new Expander {Header = str, Margin = new Thickness(10,0,10,0)};

				var grid = new Grid();
				grid.ColumnDefinitions.Add(new ColumnDefinition {Width = new GridLength(0, GridUnitType.Auto)});
				grid.ColumnDefinitions.Add(new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)});
				g.Content = grid;
				var i = 0;

				#region Add Controls

				foreach (var tuple in dict[str])
				{
					grid.RowDefinitions.Add(new RowDefinition {Height = new GridLength(0, GridUnitType.Auto)});
					var l = new Label {Content = tuple.Item1};
					l.SetValue(Grid.RowProperty, i);

					grid.Children.Add(l);

					FrameworkElement elem = new Label();

					#region Bool

					if (tuple.Item3 == typeof (bool))
					{
						var ctrl = new CheckBox {Margin = new Thickness(3), VerticalAlignment = VerticalAlignment.Center};
						ctrl.SetBinding(ToggleButton.IsCheckedProperty, new Binding(tuple.Item2));
						elem = ctrl;
					}

					#endregion

					#region Int

					else if (tuple.Item3 == typeof (int))
					{
						var ctrl = new IntegerUpDown
						{
							Margin = new Thickness(3),
							HorizontalAlignment = HorizontalAlignment.Left,
							MinWidth = 50
						};
						ctrl.SetBinding(IntegerUpDown.ValueProperty, new Binding(tuple.Item2));

						if (tuple.Item4 is int)
							ctrl.Minimum = (int?) tuple.Item4;

						if (tuple.Item5 is int)
							ctrl.Maximum = (int?) tuple.Item5;

						elem = ctrl;
					}

					#endregion

					#region String

					else if (tuple.Item3 == typeof (string))
					{
						var ctrl = new TextBox {Margin = new Thickness(3)};

						if ((string) tuple.Item4 == "Multiline")
						{
							ctrl.TextWrapping = TextWrapping.Wrap;
							ctrl.AcceptsReturn = true;
							ctrl.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
							ctrl.MaxHeight = 100;
						}

						ctrl.SetBinding(TextBox.TextProperty, new Binding(tuple.Item2));
						elem = ctrl;
					}

					#endregion

					#region Double

					else if (tuple.Item3 == typeof (double))
					{
						var ctrl = new DoubleUpDown
						{
							FormatString = "F2",
							Margin = new Thickness(3),
							HorizontalAlignment = HorizontalAlignment.Left,
							MinWidth = 50
						};
						ctrl.SetBinding(DoubleUpDown.ValueProperty, new Binding(tuple.Item2));
						elem = ctrl;
					}

					#endregion

					#region Enum

					else if (tuple.Item3.IsEnum)
					{
						var ctrl = new ComboBox {Margin = new Thickness(3)};
						var m = typeof (EnumHelper).GetMethod("GetAllValuesAndDescriptions").MakeGenericMethod(tuple.Item3);
						var ie = m.Invoke(null, null) as IEnumerable;
						ctrl.ItemsSource = ie;
						ctrl.DisplayMemberPath = "Description";
						ctrl.SetBinding(Selector.SelectedValueProperty, new Binding(tuple.Item2));
						ctrl.SelectedValuePath = "Value";
						elem = ctrl;
					}

					#endregion

					else if (tuple.Item3.GetGenericTypeDefinition() == typeof (List<>))
					{
						var ctrl = new DataGrid {Margin = new Thickness(3), AutoGenerateColumns = true, CanUserAddRows = true, MinHeight = 50};
						ctrl.AutoGeneratingColumn += (sender1, e1) =>
						{
							var displayName = Helpers.GetPropertyDisplayName(e1.PropertyDescriptor);
							if (!string.IsNullOrEmpty(displayName))
							{
								e1.Column.Header = displayName;
							}
						};


						ctrl.SetBinding(ItemsControl.ItemsSourceProperty, new Binding(tuple.Item2));
						elem = ctrl;
					}

					elem.SetValue(Grid.ColumnProperty, 1);
					elem.SetValue(Grid.RowProperty, i);
					elem.DataContext = tuple.Item6;
					grid.Children.Add(elem);

					i++;
				}

				#endregion

				MoreOptsBox.Children.Add(g);
			}

			#endregion
		}
	}
}
