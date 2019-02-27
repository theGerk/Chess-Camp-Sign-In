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
	/// Interaction logic for CreateNewWeek.xaml
	/// </summary>
	public partial class EditWeek : Window
	{
		protected Week TargetWeek;

		public EditWeek(Week target)
		{
			InitializeComponent();
			TargetWeek = target;
			SetDisplay();
		}

		private void SetDisplay()
		{
			
		}
	}
}
