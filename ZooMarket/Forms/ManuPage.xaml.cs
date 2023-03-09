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
	/// Логика взаимодействия для ManuPage.xaml
	/// </summary>
	public partial class ManuPage : Page
	{
		int count, fullCount;
		string sort, search = "";
		int[,] arrayDisc = new int[,] { { 0, 100 }, { 0, 4 }, { 5, 14 }, { 15, 29 }, { 30, 69 }, {70, 99} };
		int discFilter, catFilter;
		public ManuPage()
		{
			InitializeComponent();
			Helper.mainWindow.Width = 1600; 
			Helper.mainWindow.Height = 800;
			count = Helper.db.Product.Count();
			if(Helper.user != null) { RoleLabel.Content = Helper.user.Surname.ToString(); }
			showList();
		}

		private void ExitButtonClick(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}

		private void CategoryChanged(object sender, SelectionChangedEventArgs e)
		{
			catFilter = CategoryComboBox.SelectedIndex;
			showList();
		}

		private void SearchChanged(object sender, TextChangedEventArgs e)
		{
			search = searchTextBox.Text;
			showList();
		}

		private void DiscountChanged(object sender, SelectionChangedEventArgs e)
		{
			discFilter = discountComboBox.SelectedIndex;
			showList();
		}

		private void SortChange(object sender, SelectionChangedEventArgs e)
		{
			sort = "ASC";
			if (SortComboBox.SelectedIndex == 1)
			{
				sort = "DESC";
			}
			showList();
		}

		private void showList()
		{
			var products = Helper.db.Product.ToList();
			
			//подсчет позиций
			allCount.Text = count.ToString();


			//сортировка по цене
			if (sort == "ASC")
			{
				products = Helper.db.Product.OrderBy(x => x.Price).ToList();
			}
			else
			{
				products = Helper.db.Product.OrderByDescending(x => x.Price).ToList();
			}

			//Сортировка по категории
			
			if(catFilter != 0)
			{
			products = products.Where(x => x.ProductTypeId == catFilter).ToList();
			}

			var types = Helper.db.ProductType.ToList();
			types.Insert(0, new ProductType { ProductTypeName = "Все" });
			
			//сортировка по поиску
			products = products.Where(x => x.ProductName.Contains(search)).ToList();
			
			//сортировка по скидке
			products = products.Where(x => (x.Discount >= arrayDisc[discFilter, 0] &&
							x.Discount <= arrayDisc[discFilter, 1])).ToList();
			

			//вывод
			CategoryComboBox.ItemsSource = types;
			CatalogListView.ItemsSource = products;
			fullCount= products.Count;
			searchCount.Text = fullCount.ToString();

		}
	}
}
