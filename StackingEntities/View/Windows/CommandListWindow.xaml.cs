using System.Windows;

namespace StackingEntities.View.Windows
{
	/// <summary>
	/// Interaction logic for CommandEntry.xaml
	/// </summary>
	public partial class CommandListWindow
	{
		public CommandListWindow()
		{
			InitializeComponent();
			Title = Properties.Resources.CommandBlockWindow_Title;
			Desc.Text = Properties.Resources.CommandBlockWindow_Description;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = true;
			Hide();
		}
	}
}
