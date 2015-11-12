using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
	/// <summary>
	/// Product class
	/// </summary>
	public class Product
	{
		public Int32 Id { get; set; }
		public String Name { get; set; }
		public Decimal Price { get; set; }
		public String Image { get; set; }
		public String SmallDescription { get; set; }
		public String LargeDescription { get; set; }
		public List<Review> Reviews { get; set; }
		public List<ProductAttribute> Attributes { get; set; }
		public Boolean InStock { get; set; }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="name"></param>
		/// <param name="image"></param>
		/// <param name="smallDescription"></param>
		/// <param name="largeDescription"></param>
		/// <param name="inStock"></param>
		public Product(Int32 id, String name, Decimal price, String image, String smallDescription, String largeDescription, Boolean inStock)
		{
			Id = id;
			Name = name;
			Price = price;
			Image = image;
			SmallDescription = smallDescription;
			LargeDescription = largeDescription;
			InStock = inStock;
		}
	}

	/// <summary>
	/// Product review class
	/// </summary>
	public class Review
	{
		public String ReviewedBy { get; set; }
		public String ReviewText { get; set; }
		public Int32 Rating { get; set; }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="reviewedBy"></param>
		/// <param name="reviewText"></param>
		/// <param name="rating"></param>
		public Review(String reviewedBy, String reviewText, Int32 rating)
		{
			ReviewedBy = reviewedBy;
			ReviewText = reviewText;
			Rating = rating;
		}
	}

	/// <summary>
	/// Product attribute class
	/// </summary>
	public class ProductAttribute
	{
		public String Name { get; set; }
		public String Value { get; set; }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		public ProductAttribute(String name, String value)
		{
			Name = name;
			Value = value;
		}
	}
}
