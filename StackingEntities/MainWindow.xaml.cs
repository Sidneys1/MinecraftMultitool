using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using StackingEntities.Controls;
using StackingEntities.Entities;
using StackingEntities.Entities.DynamicTiles;
using StackingEntities.Entities.ItemEntities;
using StackingEntities.Entities.Mobs.Friendly;
using StackingEntities.Entities.Mobs.Hostile;
using StackingEntities.Entities.Other;
using StackingEntities.Entities.Other.WallEntities;
using StackingEntities.Entities.Vehicles;
using StackingEntities.Items;
using Xceed.Wpf.Toolkit;
using Attribute = System.Attribute;

namespace StackingEntities
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
		readonly DataModel _model;
		public MainWindow()
		{
			InitializeComponent();
			_model = (DataModel)DataContext;
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			switch (_model.EType)
			{
				case EntityTypes.LavaSlime:
					_model.Entities.Insert(0, new LavaSlime());
					break;

				case EntityTypes.Slime:
					_model.Entities.Insert(0, new Slime());
					break;

				case EntityTypes.Guardian:
					_model.Entities.Insert(0, new Guardian());
					break;
				
				case EntityTypes.Giant:
					_model.Entities.Insert(0, new Giant());
					break;

				case EntityTypes.Ghast:
					_model.Entities.Insert(0, new Ghast());
					break;

				case EntityTypes.EyeOfEnderSignal:
					_model.Entities.Insert(0, new EyeOfEnder());
					break;

				case EntityTypes.EnderDragon:
					_model.Entities.Insert(0, new EnderDragon());
					break;

				case EntityTypes.CaveSpider:
					_model.Entities.Insert(0, new CaveSpider());
					break;

				case EntityTypes.EnderCrystal:
					_model.Entities.Insert(0, new EnderCrystal());
					break;

				case EntityTypes.Cow:
					_model.Entities.Insert(0, new Cow());
					break;

				case EntityTypes.Boat:
					_model.Entities.Insert(0, new Boat());
					break;

				case EntityTypes.Blaze:
					_model.Entities.Insert(0, new Blaze());
					return;

				case EntityTypes.ArmorStand:
					_model.Entities.Insert(0, new ArmorStand());
					break;
				case EntityTypes.Zombie:
					_model.Entities.Insert(0, new Zombie());
					break;

					case EntityTypes.Item:
					_model.Entities.Insert(0, new DroppedItem());
					break;

				case EntityTypes.Wolf:
					_model.Entities.Insert(0, new Wolf());
					break;

				case EntityTypes.Minecart:
					_model.Entities.Insert(0, new Minecart());
					break;

				case EntityTypes.MinecartCommandBlock:
					_model.Entities.Insert(0, new MinecartCommandBlock());
					break;

				case EntityTypes.MinecartTNT:
					_model.Entities.Insert(0, new MinecartTNT());
					break;

				case EntityTypes.FallingSand:
					_model.Entities.Insert(0, new FallingSand());
					break;

				case EntityTypes.PrimedTnt:
					_model.Entities.Insert(0, new PrimedTNT());
					break;

				case EntityTypes.MinecartFurnace:
					_model.Entities.Insert(0, new MinecartFurnace());
					break;

				case EntityTypes.ItemFrame:
					_model.Entities.Insert(0, new ItemFrame());
					break;

				case EntityTypes.Painting:
					_model.Entities.Insert(0, new Painting());
					break;

				case EntityTypes.FireworksRocketEntity:
					_model.Entities.Insert(0, new FireworkRocketEntity());
					break;

				case EntityTypes.Bat:
					_model.Entities.Insert(0, new Bat());
					break;

				case EntityTypes.Chicken:
					_model.Entities.Insert(0, new Chicken());
					break;

				case EntityTypes.Creeper:
					_model.Entities.Insert(0, new Creeper());
					break;

				case EntityTypes.Enderman:
					_model.Entities.Insert(0, new Enderman());
					break;

				case EntityTypes.Endermite:
					_model.Entities.Insert(0, new Endermite());
					break;

				case EntityTypes.XPOrb:
					_model.Entities.Insert(0, new XpOrb());
					break;
			}
		}

		EntityTypes _lastEntity = EntityTypes.NoEnt;
		private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (EntitiesListBox.SelectedItem != null)
			{
				var ent = (EntityBase)EntitiesListBox.SelectedItem;

				if (_lastEntity != ent.Type)
				{
					EditStackPanel.Children.Clear();

					GenControls(ent);
				}

				_lastEntity = ent.Type;
			}
			else
			{
				EditStackPanel.Children.Clear();
				_lastEntity = EntityTypes.Zombie+1;
			}

		}

		private void GenControls(EntityBase ent)
		{
			var dict = new Dictionary<string, List<Tuple<string, string, Type, object, object>>>();

			#region Extract Options

			var props = ent.GetType().GetProperties();
			foreach (var info in props.Reverse())
			{
				if (!Attribute.IsDefined(info, typeof (PropertyAttribute))) continue;
				var prop = (PropertyAttribute)info.GetCustomAttribute(typeof(PropertyAttribute));
				if (!dict.ContainsKey(prop.Category))
					dict.Add(prop.Category, new List<Tuple<string, string, Type, object, object>>());

				object min = null, max = null;

				if (Attribute.IsDefined(info, typeof(MinMaxAttribute)))
				{
					var att = (MinMaxAttribute)info.GetCustomAttribute(typeof(MinMaxAttribute));
					min = att.Minimum;
					max = att.Maximum;
				}

				if (Attribute.IsDefined(info, typeof (MultilineStringAttribute)))
				{
					min = "Multiline";
				}

				dict[prop.Category].Insert(0, new Tuple<string, string, Type, object, object>(prop.Name, info.Name, info.PropertyType, min, max));
			}

			#endregion

			#region Add Groups

			foreach (var str in dict.Keys)
			{
				var g = new GroupBox {Header = str};

				var grid = new Grid();
				grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0, GridUnitType.Auto) });
				grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
				g.Content = grid;
				var i = 0;

				#region Add Controls

				foreach (var tuple in dict[str])
				{
					grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0, GridUnitType.Auto) });
					var l = new Label {Content = tuple.Item1};
					l.SetValue(Grid.RowProperty, i);

					grid.Children.Add(l);

					UIElement elem = new Label();

					#region Bool

					if (tuple.Item3 == typeof(bool))
					{
						var ctrl = new CheckBox {Margin = new Thickness(3), VerticalAlignment = VerticalAlignment.Center};
						ctrl.SetBinding(ToggleButton.IsCheckedProperty, new Binding(tuple.Item2));
						elem = ctrl;
					}

					#endregion

					#region Int

					else if (tuple.Item3 == typeof(int))
					{
						var ctrl = new IntegerUpDown
						{
							Margin = new Thickness(3),
							HorizontalAlignment = HorizontalAlignment.Left,
							MinWidth = 50
						};
						ctrl.SetBinding(IntegerUpDown.ValueProperty, new Binding(tuple.Item2));

						if (tuple.Item4 is int)
							ctrl.Minimum = (int?)tuple.Item4;

						if (tuple.Item5 is int)
							ctrl.Maximum = (int?)tuple.Item5;

						elem = ctrl;
					}

					#endregion

					#region String

					else if (tuple.Item3 == typeof(string))
					{
						var ctrl = new TextBox {Margin = new Thickness(3)};

						if ((string) tuple.Item4 == "Multiline")
						{
							ctrl.TextWrapping = TextWrapping.Wrap;
							ctrl.AcceptsReturn = true;
							ctrl.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
							ctrl.MinHeight = 100;
						}

						ctrl.SetBinding(TextBox.TextProperty, new Binding(tuple.Item2));
						elem = ctrl;
					}

					#endregion

					#region Double

					else if (tuple.Item3 == typeof(double))
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
						//ctrl.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = new EnumerationExtension(tuple.Item3)});
						//var a = Enum.GetValues(tuple.Item3);
						//var m = typeof (Enumerable).GetMethod("Cast").MakeGenericMethod(new Type[] {tuple.Item3});
						var m = typeof (EnumHelper).GetMethod("GetAllValuesAndDescriptions").MakeGenericMethod(tuple.Item3);
						//ctrl.ItemsSource 
						var ie = m.Invoke(null, null) as IEnumerable;
						//ctrl.SetBinding(ItemsControl.ItemsSourceProperty,
						//	new Binding() {Source = ie, Converter = (IValueConverter) Resources["enumDesc"]});
						ctrl.ItemsSource = ie;
						//ctrl.DataContext = ent;
						ctrl.DisplayMemberPath = "Description";
						ctrl.SetBinding(Selector.SelectedValueProperty, new Binding(tuple.Item2));
						ctrl.SelectedValuePath = "Value";
						elem = ctrl;
					}

					#endregion

					else if (tuple.Item3 == typeof(Item))
					{
						var ctrl = new ItemControl {Margin = new Thickness(3)};
						ctrl.SetBinding(DataContextProperty, new Binding(tuple.Item2));
						elem = ctrl;
					}

					else if (tuple.Item3.GetGenericTypeDefinition() == typeof(List<>))
					{
						var ctrl = new DataGrid { Margin = new Thickness(3), AutoGenerateColumns = true, CanUserAddRows = true, MinHeight = 50 };
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
					grid.Children.Add(elem);

					i++;
				}

				#endregion

				EditStackPanel.Children.Add(g);
			}

			#endregion
		}

		private void GenerateButton_Clicked(object sender, RoutedEventArgs e)
		{
			var b = new StringBuilder("/summon ");
			if (_model.Entities.Count > 0)
			{
				b.Append(_model.Entities[0].Type);

				b.Append(" " + _model.X + " ");
				b.Append(_model.Y + " ");
				b.Append(_model.Z + " ");

				var data = new StringBuilder( _model.Entities[0].GenerateJSON(true));

				foreach (var ent in _model.Entities.Where(ent => ent != _model.Entities[0]))
				{
					if (data[data.Length - 1] != '{' && data[data.Length - 1] != ',')
						data.Append(',');

					data.Append("Riding:");
					data.Append(ent.GenerateJSON(false));
				}

				if (data[data.Length - 1] == ',')
					data.Remove(data.Length - 1, 1);

				for (var depth = _model.Entities.Count - 1; depth > 0; depth--)
				{
					data.Append("}");
				}
				
				if (data[data.Length - 1] == '{')
					data.Clear();

				if (data.Length > 0)
					data.Append("}");

				b.Append(data);
			}
			SummonCommandOutputTxtBx.Text = b.ToString();
		}

		private void CopyButton_Clicked(object sender, RoutedEventArgs e)
		{
			try
			{
				Clipboard.SetText(SummonCommandOutputTxtBx.Text, TextDataFormat.Text);
			}
			catch (Exception)
			{
				Trace.WriteLine("Clipboard failed.");
			}
		}

		private void CommandListDialogButton_Clicked(object sender, RoutedEventArgs e)
		{
			var cmd = new CommandEntry {Owner = this};
			if (cmd.ShowDialog() == true)
			{
				var text = (string)cmd.Tag;
				var lines = text.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

				foreach (var str in lines.Where(str => !string.IsNullOrWhiteSpace(str)))
				{
					_model.Entities.Insert(0, new MinecartCommandBlock { Command = str.Trim() });
				}
				

				//do stuff
			}
			cmd.Close();
		}

		private void DeleteSelectedEntityButton_Clicked(object sender, MouseButtonEventArgs e)
		{
			_model.Entities.Remove((EntityBase)EntitiesListBox.SelectedItem);
		}

		private void MoveSelectedEntityUpBtn_Clicked(object sender, MouseButtonEventArgs e)
		{
			if (EntitiesListBox.SelectedIndex == -1)
				return;

			var ent = (EntityBase)EntitiesListBox.SelectedItem;
			var index = EntitiesListBox.SelectedIndex;

			if (index <= 0) return;
			EntitiesListBox.SelectedIndex = -1;
			_model.Entities.Remove(ent);
			if ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift) //Keyboard.IsKeyDown(Key.LeftShift))
			{
				_model.Entities.Insert(0, ent);
				EntitiesListBox.SelectedIndex = 0;
			}
			else
			{
				_model.Entities.Insert(--index, ent);
				EntitiesListBox.SelectedIndex = index;
			}
		}

		private void MoveSelectedEntityDownBtn_Clicked(object sender, MouseButtonEventArgs e)
		{
			if (EntitiesListBox.SelectedIndex == -1)
				return;
			var ent = (EntityBase)EntitiesListBox.SelectedItem;
			var index = EntitiesListBox.SelectedIndex;

			if (index == _model.Entities.Count - 1) return;
			EntitiesListBox.SelectedIndex = -1;
			_model.Entities.Remove(ent);

			if ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
			{
				int ind = _model.Entities.Count;
				_model.Entities.Insert(ind, ent);
				EntitiesListBox.SelectedIndex = ind;
			}
			else
			{
				_model.Entities.Insert(++index, ent);
				EntitiesListBox.SelectedIndex = index;
			}
		}

		private void EntitiesListBox_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Up)
			{
				MoveSelectedEntityUpBtn_Clicked(this, null);
				e.Handled = true;
			}
			else if (e.Key == Key.Down)
			{
				MoveSelectedEntityDownBtn_Clicked(this, null);
				e.Handled = true;
			}
			else if (e.Key == Key.Delete)
			{
				DeleteSelectedEntityButton_Clicked(this, null);
				e.Handled = true;
			}
		}

		private void AboutMenuItem_Click(object sender, RoutedEventArgs e)
		{
			var d = new AboutDialog {Owner = this};
			d.ShowDialog();
			d.Close();
		}
	}
}
