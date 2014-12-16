using System.Windows;
using StackingEntities.Model.Objects;

namespace StackingEntities.Desktop.View.Controls
{
	/// <summary>
	/// Interaction logic for JsonTextControl.xaml
	/// </summary>
	public partial class JsonTextControl
	{
		public JsonTextControl()
		{
			InitializeComponent();
			
		}

		private void JsonTextControl_OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			Extra.DataContext = ((JsonTextElement)DataContext)?.Extra;
			TranslateWithControl.DataContext = ((JsonTextElement) DataContext)?.TranslateWith;
		}
	}
}
