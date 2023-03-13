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
	/// Логика взаимодействия для ProductEditPage.xaml
	/// </summary>
	public partial class ProductEditPage : Page
	{
		public ProductEditPage(Product selectedProduct)
		{
			InitializeComponent();

			Helper.mainWindow.Width = 800;
			Helper.mainWindow.Height = 450;
			var types = Helper.db.ProductType.ToList();
			CategoryComboBox.ItemsSource = types;
			Product = selectedProduct;
			typ = types.Where(x => x.Id == selectedProduct.ProductTypeId).First();
			CategoryComboBox.SelectedIndex= typ.Id - 1;
			DataContext= this;
			
		}

		ProductType typ;

		public Product Product { get; set; }

		private void BackBattonClick(object sender, RoutedEventArgs e)
		{
			Helper.frame.Navigate(new ManuPage());
		}

		private void SaveButtonCLick(object sender, RoutedEventArgs e)
		{
			Product.ProductName = ProductNameBox.Text;
			Product.Price = int.Parse(ProductCostBox.Text);
			Product.Discount = int.Parse(ProductDiscountBox.Text);
			Product.ProductTypeId = CategoryComboBox.SelectedIndex + 1;
			Helper.db.SaveChanges();
			MessageBox.Show("Измненения успешно внесены!");
			Helper.frame.Navigate(new ManuPage());
		}
		private void DeleteButtonCLick(object sender, RoutedEventArgs e)
		{
			MessageBoxResult result = MessageBox.Show("Вы уверены что хотите удалить пользователя?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
			if (result == MessageBoxResult.Yes)
			{
				Helper.db.Product.Remove(Product);
				Helper.db.SaveChanges();
				MessageBox.Show("Товар успешно удалён!", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
				Helper.frame.Navigate(new ManuPage());
			}
		}


	}
}
