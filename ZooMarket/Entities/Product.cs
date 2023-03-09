namespace ZooMarket.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.IO;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            OrderProduct = new HashSet<OrderProduct>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        public int ProductTypeId { get; set; }

        public int Price { get; set; }
        public int Discount { get; set; }

        private string _imagePath;

		public string ImagePath { 
            get 
            {
				if (_imagePath == null) 
                {
                    return "/Res/ÑÏÁ_Êèò.jpg";
				}
                return _imagePath;
            }
            
            set => _imagePath = value;
        }

        public int Weight { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderProduct> OrderProduct { get; set; }

        public virtual ProductType ProductType { get; set; }
    }
}
