using System;
using System.Collections.Generic;
using System.IO;
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
	/// Interaction logic for ModifyActivites.xaml
	/// </summary>
	public partial class ModifyActivites : Window
	{
		private Window parent;

		public ModifyActivites(Window parent)
		{
			this.parent = parent;
			InitializeComponent();
			MorningList.SetText(Activities.Current.Morning);
			AfternoonList.SetText(Activities.Current.Afternoon);
		}

		private void Window_Closed(object sender, EventArgs e)
		{
			Activities.Current = new Activities(MorningList.GetText(), AfternoonList.GetText());
			parent.Show();
			parent.Activate();
		}
	}
}
