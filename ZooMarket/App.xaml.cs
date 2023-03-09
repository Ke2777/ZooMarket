using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ZooMarket.Entities;

namespace ZooMarket
{
	/// <summary>
	/// Логика взаимодействия для App.xaml
	/// </summary>
	public partial class App : Application
	{
		public App()
		{
			try
			{
				Helper.db = new Entities.ZooMarket();
			}
			catch (Exception dberror)
			{
				MessageBox.Show(dberror.Message);
				Application.Current.Shutdown();
				throw;
			}	
		}
	}

}
