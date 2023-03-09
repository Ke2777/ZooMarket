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
using ZooMarket.Entities;

namespace ZooMarket.Forms
{
	/// <summary>
	/// Логика взаимодействия для AuthPage.xaml
	/// </summary>
	public partial class AuthPage : Page
	{
		public AuthPage()
		{
			InitializeComponent();
		}

		private void ExitButtonClick(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}

		private void GuestButtonClick(object sender, RoutedEventArgs e)
		{
			Helper.user = null;
			MessageBox.Show("Вы вошли как гость!");
			Helper.frame.Navigate(new ManuPage());
		}

		private void LoginButtonClick(object sender, RoutedEventArgs e)
		{
			string login = LoginBox.Text;
			string password = PasswordBox.Password;

			if (String.IsNullOrEmpty(login) || String.IsNullOrEmpty(password))
			{
				MessageBox.Show("Пожалуйста, заполните все поля");
				return;
			}

			List<Entities.User> temp = Helper.db.User.Where(x => x.Login == login && x.Password == password).ToList();
			Helper.user = temp.FirstOrDefault();

			if (Helper.user == null)
			{
				MessageBox.Show("Проверьте введенные данные");
			}
			else
			{
				MessageBox.Show("Вы зашли как " + Helper.user.Role.TypeName);
				Helper.frame.Navigate(new ManuPage());

			}
		}
	}
}
