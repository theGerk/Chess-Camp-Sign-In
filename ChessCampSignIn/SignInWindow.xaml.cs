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
	/// Interaction logic for SignInWindow.xaml
	/// </summary>
	public partial class SignInWindow : Window
	{
		private Window parent;
		public SignInWindow(Window parent)
		{
			this.parent = parent;
			InitializeComponent();
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			parent.Activate();
			parent.Show();
		}

		private void Button_MouseDown(object sender, MouseButtonEventArgs e)
		{

		}

		private void Button_KeyDown(object sender, KeyEventArgs e)
		{

		}

		private bool ValidateData(string name, string morningActivity, string afternoonActivity)
		{
			throw new NotImplementedException();
		}
	}
}
