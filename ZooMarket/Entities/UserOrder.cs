namespace ZooMarket.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserOrder")]
    public partial class UserOrder
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        public virtual User User { get; set; }
    }
}
