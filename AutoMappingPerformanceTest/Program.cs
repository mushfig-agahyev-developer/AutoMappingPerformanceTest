using AutoMapper;
using AutoMappingPerformanceTest;
using BenchmarkDotNet.Running;


namespace AutoMappingPerformanceTest
{
	class Program
	{
		static void Main(string[] args)
		{
			var summary = BenchmarkRunner.Run<Benchmarks>();
		}
	}
}

/*
 * from cmd
 * dotnet build -c Release
 * dotnet run -c Release --filter *Benchmark
 */