// Code generated by DevUp technologies, 02/08/2024 14:36:01
using System;
namespace CommonInterfaces
{
	/// <summary>
    /// A plain data object to carry filter details (for searching objects). It does not contain any business logic or validations, 
	/// and is used to transfer filter data in optimized format to be transferred between API and client or layer that will be using it.
	/// It also contains some properties at the bottom as instructions for API on how many records or what page to return etc.
	/// this object carries data from client to service layer, where it is mapped to its equivalent entity object and sent to data access layer
    /// </summary>
    public class ProductFilterDTO
    {
		public ProductFilterDTO()
        {
			// in case you want to set a default page size you may uncomment the line below and set a desired value
            //PageSize = 10;
        }
		
		public System.Int64 Id { get; set; }
		public Nullable<System.Int32> CategoryId { get; set; }
		public Nullable<System.Decimal> NetPrice { get; set; }
		public Nullable<System.Decimal> SalesPrice { get; set; }
		public Nullable<System.Double> StockQuantity { get; set; }
		public Nullable<System.Int32> Status { get; set; }
		public System.String? Name { get; set; }
		public Nullable<System.DateTime> ProductionDateFrom { get; set; }
		public Nullable<System.DateTime> ProductionDateTo { get; set; }

		
		//How to order the result and howmuch to package and return
        public Nullable<bool> Ascending { get; set; }
        public string? OrderByColumnName { get; set; }
        public Nullable<System.Int32> PageNumber { get; set; }
        public Nullable<System.Int32> PageSize { get; set; }
    }
}

