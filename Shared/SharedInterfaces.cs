using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
	/// <summary>
	/// Mapper interface
	/// </summary>
	public interface IMapper
	{
		Object Get(DataType type);
		void SetId(Int32 id);
	}

	/// <summary>
	/// Product Mapper interface
	/// </summary>
	public interface IProductMapper
	{
		List<Product> GetAllProducts();
		Product GetProductById(Int32 id);
	}
}
