using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Shared;
using Shared.Interfaces;

namespace TestCart
{
	public class ProductController : ApiController
	{
		private readonly IProductMapper _mapper;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="mapper">Mapper dependency</param>
		public ProductController(IProductMapper mapper)
		{
			_mapper = mapper;
		}

		// GET api/<controller>
		public List<Shared.Product> Get()
		{
			return _mapper.GetAllProducts();
		}

		// GET api/<controller>/5
		public Shared.Product Get(int id)
		{
			return _mapper.GetProductById(id);
		}

		// POST api/<controller>
		public void Post([FromBody]string value)
		{
		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/<controller>/5
		public void Delete(int id)
		{
		}
	}
}