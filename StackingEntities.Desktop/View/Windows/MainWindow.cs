using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;
using StackingEntities.Desktop.Model;
using StackingEntities.Desktop.ViewModel;
using StackingEntities.Model.Entities;
using StackingEntities.Model.Entities.Vehicles;
using StackingEntities.Model.Enums;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Desktop.View.Windows
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
		#region Variables

		EntityType _lastEntity = EntityType.NoEnt;

		readonly SaveFileDialog _saveFileDialog = new SaveFileDialog
		{
			Filter = "StackingEntities Project (*.sep)|*.sep",
			Title = "Save Project..."
		};

		readonly OpenFileDialog _openFileDialog = new OpenFileDialog
		{
			Filter = "StackingEntities Project (*.sep)|*.sep",
			Title = "Open Project..."
		};

		#endregion

		public MainWindow()
		{
			InitializeComponent();
			InputBindings.Add(new InputBinding(ApplicationCommands.SaveAs,
				new KeyGesture(Key.S, (ModifierKeys.Control | ModifierKeys.Shift))));

			var args = Environment.GetCommandLineArgs();

			// ReSharper disable InvertIf
			if (args.Length == 2)
			{
				if (File.Exists(args[1]))
					
				{
					DataModel m = null;
					var success = true;

					try
					{
						m = DataModel.Open(args[1]);
					}
					catch (Exception)
					{
						success = false;
					}

					if (success && m != null)
						DataContext = m;
					else
						MessageBox.Show(this, "Project could not be opened.");
				}
			}
			// ReSharper restore InvertIf


			//var values = Enum.GetValues(typeof(EntityTypes));
			//foreach (var eb in 
			//	from EntityTypes etype in values
			//	select etype.GetType().GetMember(etype.ToString())[0].GetCustomAttributes(typeof(ClassLinkAttribute))
			//	into props
			//	select (IList<Attribute>) (props as IList<Attribute> ?? props.ToList())
			//	into attributes
			//	select attributes.Cast<ClassLinkAttribute>().FirstOrDefault()
			//	into eb
			//	where eb != null
			//	select eb)
			//{
			//	_model.Entities.Insert(0, (EntityBase)Activator.CreateInstance(eb.LinkType));
			//}
		}

		public DataModel Model { set; get; }

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

		private bool CheckSave()
		{
			if (Model.SavePath == null && Model.Entities.Count == 0) return true;

			var r = MessageBox.Show(this, "Would you like to save your existing project?", "Save?", MessageBoxButton.YesNoCancel);

			switch (r)
			{
				case MessageBoxResult.Cancel:
					return false;
				case MessageBoxResult.Yes:
					CommandSaveAs_Execute(null, null);
					break;
			}

			return true;
		}

		#endregion

		#region UI Event Handlers

		private void AddButton_Clicked(object sender, RoutedEventArgs e)
		{
			var etype = (EntityType)EntityTypeComboBox.SelectedValue;

			var props = etype.GetType().GetMember(etype.ToString())[0].GetCustomAttributes(typeof(ClassLinkAttribute));
			var attributes = props as IList<Attribute> ?? props.ToList();
			var eb = attributes.Cast<ClassLinkAttribute>().FirstOrDefault();
			if (eb != null)
				Model.Entities.Insert(0, (EntityBase)Activator.CreateInstance(eb.LinkType));
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
			_lastEntity = EntityType.NoEnt;
		}

		private void GenerateButton_Clicked(object sender, RoutedEventArgs e)
		{
			SummonCommandOutputTxtBx.Text = Model.GenerateSummon();
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
				if (!string.IsNullOrWhiteSpace(text))
				{
					var lines = text.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

					foreach (var str in lines.Where(str => !string.IsNullOrWhiteSpace(str)))
					{
						Model.Entities.Insert(0, new MinecartCommandBlock { Command = str.Trim() });
					}
				}
				//do stuff
			}
			cmd.Close();
		}

		private void DeleteSelectedEntityButton_Clicked(object sender, MouseButtonEventArgs e)
		{
			Model.Entities.Remove((EntityBase)EntitiesListBox.SelectedItem);
		}

		private void MoveSelectedEntityUpBtn_Clicked(object sender, MouseButtonEventArgs e)
		{
			if (EntitiesListBox.SelectedIndex == -1)
				return;

			var ent = (EntityBase)EntitiesListBox.SelectedItem;
			var index = EntitiesListBox.SelectedIndex;

			if (index <= 0) return;
			EntitiesListBox.SelectedIndex = -1;
			Model.Entities.Remove(ent);
			if ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift) //Keyboard.IsKeyDown(Key.LeftShift))
			{
				Model.Entities.Insert(0, ent);
				EntitiesListBox.SelectedIndex = 0;
			}
			else
			{
				Model.Entities.Insert(--index, ent);
				EntitiesListBox.SelectedIndex = index;
			}
		}

		private void MoveSelectedEntityDownBtn_Clicked(object sender, MouseButtonEventArgs e)
		{
			if (EntitiesListBox.SelectedIndex == -1)
				return;
			var ent = (EntityBase)EntitiesListBox.SelectedItem;
			var index = EntitiesListBox.SelectedIndex;

			if (index == Model.Entities.Count - 1) return;
			EntitiesListBox.SelectedIndex = -1;
			Model.Entities.Remove(ent);

			if ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
			{
				var ind = Model.Entities.Count;
				Model.Entities.Insert(ind, ent);
				EntitiesListBox.SelectedIndex = ind;
			}
			else
			{
				Model.Entities.Insert(++index, ent);
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

		private void GiveGeneratorMenu_Clicked(object sender, RoutedEventArgs e)
		{
			var cmd = new GiveGeneratorDialog { Owner = this };
			cmd.ShowDialog();
			cmd.Close();
		}

		private void MainWindow_OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			Model = (DataModel)DataContext;
		}

		private void MainWindow_OnClosing(object sender, CancelEventArgs e)
		{
			if (!CheckSave())
				e.Cancel = true;
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
			
			Application.Current.Shutdown();
		}

		private void CommandNew_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}

		private void CommandNew_Execute(object sender, ExecutedRoutedEventArgs e)
		{
			if (!CheckSave()) return;

			DataContext = new DataModel();
		}

		private void CommandSave_Execute(object sender, ExecutedRoutedEventArgs e)
		{
			if (Model.SavePath == null)
				CommandSaveAs_Execute(sender, e);
			else
				Model.Save();
		}

		private void CommandOpen_Execute(object sender, ExecutedRoutedEventArgs e)
		{
			if (!CheckSave()) return;

			var result = _openFileDialog.ShowDialog(this);

			if (result != true) return;

			var path = _openFileDialog.FileName;

			DataContext = DataModel.Open(path);
		}

		private void CommandSaveAs_Execute(object sender, ExecutedRoutedEventArgs e)
		{
			var result = _saveFileDialog.ShowDialog(this);
			if (result != true) return;
			var path = _saveFileDialog.FileName;

			Model.Save(path);
		}

		#endregion
	}
}
