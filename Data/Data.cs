using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using Shared;
using Shared.Interfaces;

namespace Data
{

	#region Helper

	public static class DataHelper
	{
		/// <summary>
		/// Creates the mapper object from the given type.
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public static IMapper CreateMapper(String type)
		{
			return Activator.CreateInstance(Type.GetType(String.Format("Data.{0}", type))) as IMapper;
		}
	}

	#endregion Helper

	#region Mappers

	/// <summary>
	/// Abstract data mapper.
	/// </summary>
	public abstract class AbstractMapper : IMapper
	{
		protected Int32 _id;
		public abstract Object Get(DataType type);
		public void SetId(Int32 id)
		{
			_id = id;
		}
	}

	/// <summary>
	/// Product mapper to get data from the objects in the memory.
	/// </summary>
	public class InMemoryMapper : AbstractMapper
	{
		/// <summary>
		/// Get the data
		/// </summary>
		/// <returns></returns>
		public override Object Get(DataType type)
		{
			Object retVal = null;

			// Do Not use this when using a database
			switch (type)
			{
				case DataType.AllProducts:
					retVal = new ProductRepository().Products;
					break;

				case DataType.IndividualProduct:
					retVal = new ProductRepository().GetById(_id);
					break;
			}

			return retVal;
		}
	}

	/// <summary>
	/// Concrete mapper class
	/// </summary>
	public class ProductMapper : IProductMapper
	{
		private IMapper _mapper = null;

		public IMapper Mapper 
		{
			get { return _mapper; }
			set { _mapper = value; }
		}

		public ProductMapper(IMapper mapper)
		{
			_mapper = mapper;
		}

		public List<Product> GetAllProducts()
		{
			return _mapper.Get(DataType.AllProducts) as List<Product>;
		}

		public Product GetProductById(Int32 id)
		{
			_mapper.SetId(id);
			return _mapper.Get(DataType.IndividualProduct) as Product;
		}
	}

	#endregion Mappers

	#region Static Data

	/// <summary>
	/// Product repository class that contains the static product information
	/// </summary>
	public class ProductRepository
	{
		private List<Product> _products;

		/// <summary>
		/// Get all products
		/// </summary>
		public List<Product> Products { get { return _products; } }

		public ProductRepository()
		{
			Product product;
			_products = new List<Product>();

			product = new Product(1, "iPhone 6", 38999, "iphone.jpg",
				"Apple iPhone 6 exudes elegance and excellence at its best. With iOS 8, the world’s most advanced mobile operating system, and a larger and superior 4.7 inches high definition Retina display screen, this device surpasses any expectations you might have with a mobile phone. ",
				"This new generation device comes with improved Wi-Fi speed to enhance your surfing experience. Its sleek body and seamless design along with a perfect unison between its software and hardware system gives you marvellous navigation results. Just double tap the home screen and the entire screen shifts down to your thumb for easy operation. In terms of security, this iPhone is a class apart from its predecessors as it allows you fingerprint lock. The multitude of features in Apple iPhone 6 makes it powerful, efficient, smooth and super easy to use. With this phone in your hands, you can manage your world with just a single touch!",
				true);
			product.Reviews = new List<Review>();
			product.Attributes = new List<ProductAttribute>();

			product.Reviews.Add(new Review("John", "Very good phone!!", 4));
			product.Attributes.Add(new ProductAttribute("Brand", "Apple"));

			_products.Add(product);

			product = new Product(2, "Sony Xperia E4", 8569, "xperia.jpg",
				"Encased in an extremely stylish design along with Sony’s legendary expertise, the all-new Sony Xperia E4 smartphone will certainly impress you with its outstanding performance. Access internet, listen to high-octane music and stay up-to-date with what’s happening around you with Sony Xperia smartphone.",
				"Stay connected with your friends 24 x 7, play games online and browse web without any interruption with the high performance Sony Xperia E4 smartphone. Equipped with a powerful 2300 mAh battery, the Sony smartphone enables you to easily accomplish your important tasks without any interruption.  Sony Xperia offers a two-day battery life to always keep you on the go. It delivers a talk time of up to 12 hours 43 minutes and a standby time of 696 hours. Additionally, you can activate the Ultra Stamina Mode to keep your battery running longer.",
				true);
			product.Reviews = new List<Review>();
			product.Attributes = new List<ProductAttribute>();

			product.Reviews.Add(new Review("Eric", "Amazing phone!! I just love it.", 5));
			product.Attributes.Add(new ProductAttribute("Brand", "Sony"));
			
			_products.Add(product);

			product = new Product(3, "Panasonic Eluga Z", 10210, "Panasonic-Eluga-Z-16GB-Champagne-SDL795062898-1-c97dc.jpg",
				"Panasonic Eluga Z is latest smartphone with a metal frame based on CNC based metal grinding technique. It has a 5-inch (1280 x 720 pixels) OnCell HD AMOLED display, is powered by a 1.4 GHz True Octa-Core processor and runs on Android 4.4 (KitKat).The Panasonic Eluga Z sports a 13-megapixel rear camera with LED flash, and a 5-megapixel front facing camera. It bears 16GB of inbuilt storage that's expandable via microSD card (up to 32GB). The smartphone is powered by a 2050mAh battery that features fast charging support. The Eluga Z is 141.3x70.6x6.85mm and weighs 120 grams.",
				"Panasonic Eluga Z is latest smartphone with a metal frame based on CNC based metal grinding technique. It has a 5-inch (1280 x 720 pixels) OnCell HD AMOLED display, is powered by a 1.4 GHz True Octa-Core processor and runs on Android 4.4 (KitKat).The Panasonic Eluga Z sports a 13-megapixel rear camera with LED flash, and a 5-megapixel front facing camera. It bears 16GB of inbuilt storage that's expandable via microSD card (up to 32GB). The smartphone is powered by a 2050mAh battery that features fast charging support. The Eluga Z is 141.3x70.6x6.85mm and weighs 120 grams. Connectivity options on the Panasonic Eluga Z include 3G, USB OTG, Wi-Fi 802.11 b/g/n with hotspot and direct functionality, GPS/ A-GPS, and Bluetooth 4.0 with EDR. The smartphone features an ambient light sensor, proximity sensor, e-compass, and accelerometer. It is with a flip cover, protective case, and screen guard.",
				true);
			product.Reviews = new List<Review>();
			product.Attributes = new List<ProductAttribute>();

			product.Reviews.Add(new Review("Tory", "Not so good phone.", 2));
			product.Attributes.Add(new ProductAttribute("Brand", "Panasonic"));

			_products.Add(product);

			product = new Product(4, "Microsoft Lumia 540", 7777, "Microsoft_Lumia_540_8_GB_SDL086763097_1_8cb46-b5a08.jpg",
				"Microsoft Lumia 540 8 GB is a smartphone that runs on Quad-core 1.2 GHz processor. Using this phone, you can view the apps and games in HD on its large 12.7 cm (5) screen. Microsoft Lumia 540 is supported by the latest windows phone 8.1 Operating System (OS).",
				"Microsoft Lumia 540 8 GB is a smartphone that runs on Quad-core 1.2 GHz processor. Using this phone, you can view the apps and games in HD on its large 12.7 cm (5) screen. Microsoft Lumia 540 is supported by the latest windows phone 8.1 Operating System (OS). All your favourite applications such as Candy Crush Saga, Mindcraft, Instagram or Lumia Selfie are available for you to download from the Windows Phone Store. Using its 8 MP main camera and 5 MP wide-angle front facing camera, you can click and capture as many pictures in high definition. This smartphone by Microsoft offers innumerable connectivity options. It not only provides wireless connectivity option but you can also connect it using the Bluetooth.",
				true);
			product.Reviews = new List<Review>();
			product.Attributes = new List<ProductAttribute>();

			product.Reviews.Add(new Review("Jessica", "Good budget phone.", 3));
			product.Attributes.Add(new ProductAttribute("Brand", "Microsoft"));

			_products.Add(product);

			product = new Product(5, "Lenovo A6000", 6749, "Lenovo-A6000-Black-SDL702289202-1-7d544.jpg",
				"Lenovo A6000",
				"Lenovo A6000",
				true);
			product.Reviews = new List<Review>();
			product.Attributes = new List<ProductAttribute>();

			product.Reviews.Add(new Review("John", "Cheap phone, don't buy.", 1));
			product.Attributes.Add(new ProductAttribute("Brand", "Lenovo"));

			_products.Add(product);

			product = new Product(6, "Microsoft Lumia 640", 13192, "Microsoft-Lumia-640-XL-Dual-SDL205661902-1-f8f5c.jpg",
				"Take your multimedia experience a notch higher with the all new Microsoft Lumia 640 XL Dual SIM smartphone.  Specially designed to meet your active lifestyle and business requirements, this ultimate smartphone makes your everyday tasks smooth and more interesting. ",
				"Take your multimedia experience a notch higher with the all new Microsoft Lumia 640 XL Dual SIM smartphone.  Specially designed to meet your active lifestyle and business requirements, this ultimate smartphone makes your everyday tasks smooth and more interesting. Organize high quality video calls on Skype, track your ideas on OneNote, click beautiful pictures and keep a balance between your work and Play with the high performance smartphone brought to you by Microsoft. Power packed with the latest processor along with an advanced operating system, the Microsoft Lumia smartphone facilitates you with seamless multitasking and smooth operating experience. It comes with an excellent storage capacity and helps you to stay social 24 x 7 through its Wi-Fi connectivity. Moreover, the astounding battery performance of the smartphone makes it more reliable and user-friendly.",
				true);
			product.Reviews = new List<Review>();
			product.Attributes = new List<ProductAttribute>();

			product.Reviews.Add(new Review("John", "Cheap phone, don't buy.", 1));
			product.Attributes.Add(new ProductAttribute("Brand", "Microsoft"));

			_products.Add(product);

			product = new Product(7, "Samsung Galaxy A5", 18982, "Samsung-Galaxy-A5-SDL108484327-1-7dd0c.jpg",
				"Samsung A5 comes with a dual SIM phone embodies a 12.5 cm (5) Super AMOLED display that can display an image with a TFT resolution of 1280 x 720 pixels. This appealing dual SIM smart phone runs on a 1.2 GHz quad-core processor. It is backed with a 2 GB RAM memory, 16 GB internal memory storage and a 13 MP camera.",
				"This Samsung A5 facilitates a Dual SIM connectivity comprising the GSM+GSM accessibility. This characteristic will allow you to make use of two SIM cards at a time. You can take advantage of this facility to be available for both the personal and the professional spheres.",
				true);
			product.Reviews = new List<Review>();
			product.Attributes = new List<ProductAttribute>();

			product.Reviews.Add(new Review("Kavita", "Really good phone.", 5));
			product.Attributes.Add(new ProductAttribute("Brand", "Samsung"));

			_products.Add(product);

			product = new Product(8, "Mi4 16 GB White", 12999, "Mi4_1_-9342b.jpg",
				"Encased in an extremely stylish design along with the most advanced features, the new MI 4 is ready to impress you with its outstanding performance.",
				"Powered by the latest processor along with the advanced operating system (OS), the Mi smartphone thrills you seamless multitasking and smooth operating experience. Click beautiful pictures, stay connected with your social circle and enjoy blazing fast internet services with the high performance smartphone brought to you by Mi. Additionally, the powerful 3080 mAh battery of the Mi smartphone enables you to easily accomplish your important tasks without worrying about the battery getting drained out.",
				true);
			product.Reviews = new List<Review>();
			product.Attributes = new List<ProductAttribute>();

			product.Reviews.Add(new Review("Jacob", "Okay phone.", 3));
			product.Attributes.Add(new ProductAttribute("Brand", "Mi"));

			_products.Add(product);

		}

		/// <summary>
		/// Get product by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Product GetById(Int32 id)
		{
			return _products.Find(p => p.Id == id);
		}
	}

	#endregion Static Data

}
