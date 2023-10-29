using AutoMapper;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMappingPerformanceTest
{
	public class Benchmarks
	{
		public Product[] _products { get; set; }
		private IMapper _mapper;

		[Params(10, 100, 1000)]

		public int Capacity { get; set; }

		[GlobalSetup]
		public void Iint()
		{
			var config = new MapperConfiguration(options =>
			options.CreateMap<Product, ProductDto>()
			.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
			.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
			.ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price - src.Price * src.DiscountProduct / 100))
			);

			_mapper = config.CreateMapper();

			_products = Enumerable.Range(1, Capacity)
				.Select(num => new Product
				{
					ID = num,
					Name = $"Product anme {num}",
					Price = 452.87m,
					DiscountProduct = 15,
				}).ToArray();

		}

		[Benchmark]
		public void WithAutoMapper()
		{
			foreach (var item in _products)
			{
				var productDto = _mapper.Map<ProductDto>(item);
			}
		}

		[Benchmark]
		public void ImplicitOperator()
		{
			foreach (var item in _products)
			{
				var productDto = item;
			}
		}
	}
}