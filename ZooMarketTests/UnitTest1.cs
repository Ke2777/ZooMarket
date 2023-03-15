using ZooMarket.Entities;
using ZooMarket.Forms;

namespace ZooMarketTests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void AddProductToCart_Success()
		{
			// Arrange
			var product = new Product { ProductName = "TestProduct", Price = 100, Discount = 10, ProductTypeId = 1 };
			var page = new ProductAddPage();
			page.ProductNameBox.Text = product.ProductName;
			page.ProductCostBox.Text = product.Price.ToString();
			page.ProductDiscountBox.Text = product.Discount.ToString();
			page.CategoryComboBox.SelectedIndex = product.ProductTypeId - 1;

			// Act
			page.AddButtonClick(null, null);

			// Assert
			Assert.That(Helper.db.Product.Count(), Is.EqualTo(1));
		}

		[TestMethod]
		public void AddProductToCart_InvalidProduct()
		{
			// Arrange
			var page = new ProductAddPage();
			page.ProductNameBox.Text = "";
			page.ProductCostBox.Text = "abc";
			page.ProductDiscountBox.Text = "10";
			page.CategoryComboBox.SelectedIndex = 0;

			// Act
			page.AddButtonClick(null, null);

			// Assert
			Assert.That(Helper.db.Product.Count(), Is.EqualTo(0));
		}

		[TestMethod]
		public void EditProduct_Success()
		{
			// Arrange
			var product = new Product { ProductName = "TestProduct", Price = 100, Discount = 10, ProductTypeId = 1 };
			Helper.db.Product.Add(product);
			Helper.db.SaveChanges();

			var page = new ProductEditPage(product);
			page.ProductNameBox.Text = "EditedProduct";
			page.ProductCostBox.Text = "200";
			page.ProductDiscountBox.Text = "20";
			page.CategoryComboBox.SelectedIndex = 1;

			// Act
			page.SaveButtonCLick(null, null);

			// Assert
			var editedProduct = Helper.db.Product.Find(product.Id);
			Assert.That(editedProduct.ProductName, Is.EqualTo("EditedProduct"));
		}

		[TestMethod]
		public void EditProduct()
		{
			// Arrange
			var product = new Product
			{
				ProductName = "Test Product",
				Price = 100,
				Discount = 10,
				ProductTypeId = 1
			};
			Helper.db.Product.Add(product);
			Helper.db.SaveChanges();

			var editedProduct = new Product
			{
				ProductName = "Edited Product",
				Price = 200,
				Discount = 20,
				ProductTypeId = 2
			};
			Helper.db.Product.Add(editedProduct);
			Helper.db.SaveChanges();

			var page = new ProductEditPage(product);

			// Act
			page.ProductNameBox.Text = "Edited Product";
			page.ProductCostBox.Text = "200";
			page.ProductDiscountBox.Text = "20";
			page.CategoryComboBox.SelectedIndex = 1;
			page.SaveButtonCLick(null, null);

			// Assert
			var result = Helper.db.Product.Find(product.Id);
			Assert.That(result.ProductName, Is.EqualTo("Edited Product"));
			Assert.That(result.Price, Is.EqualTo(200));
			Assert.That(result.Discount, Is.EqualTo(20));
			Assert.That(result.ProductTypeId, Is.EqualTo(2));
		}
	}
}