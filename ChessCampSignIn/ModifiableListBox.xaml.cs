using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChessCampSignIn
{
	/// <summary>
	/// Interaction logic for ModifiableListBox.xaml
	/// </summary>
	public partial class ModifiableListBox : UserControl
	{
		public ModifiableListBox()
		{
			InitializeComponent();
			Root.DataContext = this;
		}

		private void Text_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter) {
				List.Items.Add(Text.Text);
				Text.Text = "";
			}
		}

		private void List_KeyDown(object sender, KeyEventArgs e)
		{

			if (e.Key == Key.Delete || e.Key == Key.Back) {
				while (List.SelectedIndex != -1)
					List.Items.RemoveAt(List.SelectedIndex);
			}
		}

		public void SetText(IEnumerable<string> values) {
			List.Items.Clear();
			foreach (var str in values) {
				List.Items.Add(str);
			}
		}

		public IEnumerable<string> GetText()
		{
			return List.Items.Cast<string>();
		}
	}
}