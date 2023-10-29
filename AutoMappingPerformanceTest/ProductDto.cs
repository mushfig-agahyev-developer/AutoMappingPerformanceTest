using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMappingPerformanceTest
{
	public class ProductDto
	{
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

		//public static implicit operator ProductDto(Product vs)
		public static explicit operator ProductDto(Product vs)
		{
			if (vs == null)
				return null;

			return new ProductDto()
			{
				Name = vs.Name,
				Description = vs.Description,
				Price = vs.Price - vs.Price * vs.DiscountProduct / 100
			};
		}
	}
}
