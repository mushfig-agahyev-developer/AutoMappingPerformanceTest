using AutoMapper;
using AutoMapper;
using AutoMappingPerformanceTest;
using BenchmarkDotNet.Running;


namespace AutoMappingPerformanceTest
{
	class Program
	{
		static void Main(string[] args)
		{

			
			var config = new MapperConfiguration(options =>
				options.CreateMap<Product, ProductDto>()
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
				.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
				.ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price - src.Price * src.DiscountProduct / 100))
				);

			var summary = BenchmarkRunner.Run<Benchmarks>();

			//Console.ReadLine();
		}
	}
}
/*
 * from cmd
 * dotnet build -c Release
 * dotnet run -c Release --filter *Benchmark
 */