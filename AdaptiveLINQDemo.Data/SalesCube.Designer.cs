using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdaptiveLINQDemo.Data
{
	/// <summary>
	/// Sales analysis cube
	/// </summary>
	public sealed partial class SalesCubeDefinition : global::AdaptiveLINQ.ICubeDefinition<global::AdaptiveLINQDemo.Data.SalesOrderDetail, global::AdaptiveLINQDemo.Data.SalesCubeItem>
	{
		public static readonly global::System.Linq.Expressions.Expression<global::System.Func<global::AdaptiveLINQDemo.Data.SalesOrderDetail, global::System.String>>
			Customer = item => item.SalesOrderHeader.Customer.Person.LastName;
		public static readonly global::System.Linq.Expressions.Expression<global::System.Func<global::AdaptiveLINQDemo.Data.SalesOrderDetail, global::System.String>>
			Product = item => item.SpecialOfferProduct.Product.Name;
		public static readonly global::System.Linq.Expressions.Expression<global::System.Func<global::AdaptiveLINQDemo.Data.SalesOrderDetail, global::System.String>>
			ProductCategory = item => item.SpecialOfferProduct.Product.ProductSubcategory.ProductCategory.Name;
		public static readonly global::System.Linq.Expressions.Expression<global::System.Func<global::AdaptiveLINQDemo.Data.SalesOrderDetail, global::System.String>>
			Country = item => item.SalesOrderHeader.SalesTerritory.CountryRegionCode;
		public static readonly global::System.Linq.Expressions.Expression<global::System.Func<global::System.Collections.Generic.IEnumerable<global::AdaptiveLINQDemo.Data.SalesOrderDetail>, global::System.Decimal>>
			TotalSales = items => items.Sum(i => i.LineTotal);
		public static readonly global::System.Linq.Expressions.Expression<global::System.Func<global::System.Collections.Generic.IEnumerable<global::AdaptiveLINQDemo.Data.SalesOrderDetail>, global::System.Int64>>
			TotalQty = items => items.Sum(i => i.OrderQty);
	}

	public sealed partial class SalesCubeItem
	{
		/// <summary>
		/// Customer name
		/// </summary>
		public global::System.String Customer { get; set; }
		/// <summary>
		/// Product name
		/// </summary>
		public global::System.String Product { get; set; }
		/// <summary>
		/// Product category name
		/// </summary>
		public global::System.String ProductCategory { get; set; }
		/// <summary>
		/// Country code
		/// </summary>
		public global::System.String Country { get; set; }
		/// <summary>
		/// Total sales
		/// </summary>
		public global::System.Decimal TotalSales { get; set; }
		/// <summary>
		/// Total quantity
		/// </summary>
		public global::System.Int64 TotalQty { get; set; }
	}
}
