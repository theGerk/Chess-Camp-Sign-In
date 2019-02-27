using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ChessCampSignIn
{
	/// <summary>
	/// Interaction logic for WeekSelection.xaml
	/// </summary>
	public partial class WeekSelection : Window
	{
		Window parent;
		public WeekSelection(Window parent)
		{
			this.parent = parent;
			InitializeComponent();
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (Week.Current == null) {
				MessageBox.Show("Error: You must have a valid week selected first");
				e.Cancel = true;
			} else {
				parent.Activate();
				parent.Show();
			}
		}

		private void LimitToNumeric(object sender, TextCompositionEventArgs e)
		{
			if (!e.Text.All(char.IsDigit)) {
				e.Handled = true;
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if(!TrySetWeek()) {

			}
		}

		private void TextChanged(object sender, TextCompositionEventArgs e)
		{
			TrySetWeek();
		}

		private bool TrySetWeek()
		{
			throw new NotImplementedException();
		}
	}
}
