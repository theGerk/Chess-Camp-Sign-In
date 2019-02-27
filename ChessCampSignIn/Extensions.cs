using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChessCampSignIn
{
    public static class Extensions
    {
		public static Window OpenNewWindow(this Window current, Window newWindow)
		{
			newWindow.Show();
			newWindow.Activate();
			current.Hide();
			return newWindow;
		}
    }
}
