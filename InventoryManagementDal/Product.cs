// Code generated by DevUp technologies, 02/08/2024 14:36:00
using System;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementDAL
{
    public class Product
    {
		public System.Int64 Id { get; set; }
		public System.DateTime ProductionDate { get; set; }
		public System.String Name { get; set; }
		public System.Decimal NetPrice { get; set; }
		public System.Decimal SalesPrice { get; set; }
		public System.Double StockQuantity { get; set; }
		public Nullable<System.Int32> CategoryId { get; set; }
		public Nullable<System.Int32> Status { get; set; }

    }
}

