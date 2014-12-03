using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using StackingEntities.Model;
using StackingEntities.Model.Entities;
using StackingEntities.Model.Entities.Vehicles;
using StackingEntities.Model.Metadata;
using StackingEntities.ViewModel;
using Attribute = System.Attribute;

namespace StackingEntities.View.Windows
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
		#region Variables

		EntityTypes _lastEntity = EntityTypes.NoEnt;
		readonly DataModel _model;

		#endregion

		public MainWindow()
		{
			InitializeComponent();
			_model = (DataModel)DataContext;
		}

		#region Methods

		private void GenControls(EntityBase ent)
		{
			var dict = new Dictionary<string, List<DisplayOption>>();

			#region Extract Options

			ExtractOptions(ent, dict);

			#endregion

			#region Add Groups

			foreach (var str in dict.Keys)
			{
				EditStackPanel.Children.Add(OptionsGenerator.AddGroup(str, dict));
			}

			#endregion
		}

		private static void ExtractOptions(EntityBase ent, IDictionary<string, List<DisplayOption>> dict)
		{
			var props = ent.GetType().GetPropertiesSorted();
			foreach (var info in props.Reverse())
			{
				//info
				if (!Attribute.IsDefined(info, typeof(EntityDescriptorAttribute))) continue;
				var prop = (EntityDescriptorAttribute)info.GetCustomAttribute(typeof(EntityDescriptorAttribute));
				if (!dict.ContainsKey(prop.Category))
					dict.Add(prop.Category, new List<DisplayOption>());

				object min = null, max = null;
				var multiline = Attribute.IsDefined(info, typeof(MultilineStringAttribute));

				if (Attribute.IsDefined(info, typeof(MinMaxAttribute)))
				{
					var att = (MinMaxAttribute)info.GetCustomAttribute(typeof(MinMaxAttribute));
					min = att.Minimum;
					max = att.Maximum;
				}

				dict[prop.Category].Insert(0,
					new DisplayOption(prop.Name, info.Name, info.PropertyType, ent, desc: prop.Description, min: min, max: max, mLine: multiline, epName: prop.IsEnabledPath,
						fSize: prop.FixedSize, dgRowPath: prop.DataGridRowHeaderPath));
			}
		}

		#endregion

		#region UI Event Handlers

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var etype = (EntityTypes)EntityTypeComboBox.SelectedValue;

			var props = etype.GetType().GetMember(etype.ToString())[0].GetCustomAttributes(typeof(ClassLinkAttribute));
			var attributes = props as IList<Attribute> ?? props.ToList();
			var eb = attributes.Cast<ClassLinkAttribute>().FirstOrDefault();
			if (eb != null)
				_model.Entities.Insert(0, (EntityBase)Activator.CreateInstance(eb.LinkType));
		}

		private void EntitiesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (EntitiesListBox.SelectedItem != null)
			{
				var ent = (EntityBase)EntitiesListBox.SelectedItem;

				if (_lastEntity == ent.Type) return;

				EditStackPanel.Children.Clear();
				GenControls(ent);
				_lastEntity = ent.Type;
				return;
			}

			EditStackPanel.Children.Clear();
			_lastEntity = EntityTypes.NoEnt;
		}

		private void GenerateButton_Clicked(object sender, RoutedEventArgs e)
		{
			SummonCommandOutputTxtBx.Text = _model.GenerateSummon();
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
			var cmd = new CommandListWindow { Owner = this };
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
				var ind = _model.Entities.Count;
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
			switch (e.Key)
			{
				case Key.Up:
					MoveSelectedEntityUpBtn_Clicked(this, null);
					e.Handled = true;
					break;
				case Key.Down:
					MoveSelectedEntityDownBtn_Clicked(this, null);
					e.Handled = true;
					break;
				case Key.Delete:
					DeleteSelectedEntityButton_Clicked(this, null);
					e.Handled = true;
					break;
			}
		}

		#endregion

		#region Command Handlers

		private void CommandAbout_Execute(object sender, RoutedEventArgs e)
		{
			var d = new AboutDialog { Owner = this };
			d.ShowDialog();
			d.Close();
		}

		private void CommandExit_Execute(object sender, ExecutedRoutedEventArgs e)
		{
			// TODO: Check if not saved...
			Application.Current.Shutdown();
		}

		private void CommandNew_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}

		private void CommandNew_Execute(object sender, ExecutedRoutedEventArgs e)
		{
			// TODO: Check if not saved...
		}

		#endregion
	}
}
