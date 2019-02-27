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
	/// Interaction logic for Selection.xaml
	/// </summary>
	public partial class Selection : UserControl
	{
		public Selection()
		{
			InitializeComponent();
		}

		public ComboBox Options => options;

		public void SetOptions(params string[] options)
		{
			Options.Items.Clear();
			foreach (var item in options)
				Options.Items.Add(item);
		}

		public string Title {
			get { return (string)GetValue(TitleProperty); }
			set { SetValue(TitleProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty TitleProperty =
			DependencyProperty.Register("Title", typeof(string), typeof(Selection));

	}
}
