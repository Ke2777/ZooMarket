using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
	/// Логика взаимодействия для ProductAddPage.xaml
	/// </summary>
	public partial class ProductAddPage : Page
	{
		public ProductAddPage()
		{
			InitializeComponent();

			Helper.mainWindow.Width = 800;
			Helper.mainWindow.Height = 450;
			var types = Helper.db.ProductType.ToList();
			CategoryComboBox.ItemsSource = types;
			DataContext = this;
		}

		private void BackBattonClick(object sender, RoutedEventArgs e)
		{
			Helper.frame.Navigate(new ManuPage());
		}

		private void AddButtonClick(object sender, RoutedEventArgs e)
		{
			Product product = new Product
			{
			ProductName = ProductNameBox.Text,
			Price = int.Parse(ProductCostBox.Text),
			Discount = int.Parse(ProductDiscountBox.Text),
			ProductTypeId = CategoryComboBox.SelectedIndex + 1
		};

			Helper.db.Product.Add(product);
			Helper.db.SaveChanges();
			MessageBox.Show("Товар успешно добавлен!", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
		}
	}
}
