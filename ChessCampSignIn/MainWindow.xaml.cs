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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChessCampSignIn
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			this.OpenNewWindow(new WeekSelection(this));
		}


		private void ModifyActivites_click(object sender, RoutedEventArgs e)
		{
			this.OpenNewWindow(new ModifyActivites(this));
		}

		private void SignInCampers_click(object sender, RoutedEventArgs e)
		{
			this.OpenNewWindow(new SignInWindow(this));
		}

		private void MakeNewWeek_click(object sender, RoutedEventArgs e)
		{
			this.OpenNewWindow(new WeekSelection(this));
		}
	}
}
