using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Loggers;

namespace ConsoleApp1;

public class SerialiserBenchmarksConfig : ManualConfig
{
    public SerialiserBenchmarksConfig()
    {
        AddDiagnoser(MemoryDiagnoser.Default);
        AddLogger(ConsoleLogger.Default);
        AddColumn(TargetMethodColumn.Method, StatisticColumn.Median, StatisticColumn.StdDev,
            StatisticColumn.Q1, StatisticColumn.Q3, new ParamColumn("Size"));
    }
}