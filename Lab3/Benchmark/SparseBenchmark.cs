using BenchmarkDotNet.Attributes;

using Lab3;

namespace Benchmark;

[MemoryDiagnoser]
public class SparseBenchmark
{
    private static readonly CRS test_1_0_CRS_1_10x10_NNZ_1 = SparseSerializer.DeserializeCRS(@"..\..\..\..\CRS_TEST\test_1.0_CRS_1_10x10_NNZ_1.txt");
    private static readonly CRS test_1_0_CRS_2_10x10_NNZ_1 = SparseSerializer.DeserializeCRS(@"..\..\..\..\CRS_TEST\test_1.0_CRS_2_10x10_NNZ_1.txt");

    private static readonly CRS test_1_1_CRS_1_10x10_NNZ_10 = SparseSerializer.DeserializeCRS(@"..\..\..\..\CRS_TEST\test_1.1_CRS_1_10x10_NNZ_10.txt");
    private static readonly CRS test_1_1_CRS_2_10x10_NNZ_10 = SparseSerializer.DeserializeCRS(@"..\..\..\..\CRS_TEST\test_1.1_CRS_2_10x10_NNZ_10.txt");

    private static readonly CRS test_1_2_CRS_1_10x10_NNZ_50 = SparseSerializer.DeserializeCRS(@"..\..\..\..\CRS_TEST\test_1.2_CRS_1_10x10_NNZ_50.txt");
    private static readonly CRS test_1_2_CRS_2_10x10_NNZ_50 = SparseSerializer.DeserializeCRS(@"..\..\..\..\CRS_TEST\test_1.2_CRS_2_10x10_NNZ_50.txt");


    private static readonly CRS test_2_0_CRS_1_100x100_NNZ_100 = SparseSerializer.DeserializeCRS(@"..\..\..\..\CRS_TEST\test_2.0_CRS_1_100x100_NNZ_100.txt");
    private static readonly CRS test_2_0_CRS_2_100x100_NNZ_100 = SparseSerializer.DeserializeCRS(@"..\..\..\..\CRS_TEST\test_2.0_CRS_2_100x100_NNZ_100.txt");

    private static readonly CRS test_2_1_CRS_1_100x100_NNZ_1000 = SparseSerializer.DeserializeCRS(@"..\..\..\..\CRS_TEST\test_2.1_CRS_1_100x100_NNZ_1000.txt");
    private static readonly CRS test_2_1_CRS_2_100x100_NNZ_1000 = SparseSerializer.DeserializeCRS(@"..\..\..\..\CRS_TEST\test_2.1_CRS_2_100x100_NNZ_1000.txt");

    private static readonly CRS test_2_2_CRS_1_100x100_NNZ_5000 = SparseSerializer.DeserializeCRS(@"..\..\..\..\CRS_TEST\test_2.2_CRS_1_100x100_NNZ_5000.txt");
    private static readonly CRS test_2_2_CRS_2_100x100_NNZ_5000 = SparseSerializer.DeserializeCRS(@"..\..\..\..\CRS_TEST\test_2.2_CRS_2_100x100_NNZ_5000.txt");


    private static readonly CRS test_3_0_CRS_1_1000x1000_NNZ_1000 = SparseSerializer.DeserializeCRS(@"..\..\..\..\CRS_TEST\test_3.0_CRS_1_1000x1000_NNZ_1000.txt");
    private static readonly CRS test_3_0_CRS_2_1000x1000_NNZ_1000 = SparseSerializer.DeserializeCRS(@"..\..\..\..\CRS_TEST\test_3.0_CRS_2_1000x1000_NNZ_1000.txt");

    private static readonly CRS test_3_1_CRS_1_1000x1000_NNZ_10000 = SparseSerializer.DeserializeCRS(@"..\..\..\..\CRS_TEST\test_3.1_CRS_1_1000x1000_NNZ_10000.txt");
    private static readonly CRS test_3_1_CRS_2_1000x1000_NNZ_10000 = SparseSerializer.DeserializeCRS(@"..\..\..\..\CRS_TEST\test_3.1_CRS_2_1000x1000_NNZ_10000.txt");

    private static readonly CRS test_3_2_CRS_1_1000x1000_NNZ_500000 = SparseSerializer.DeserializeCRS(@"..\..\..\..\CRS_TEST\test_3.2_CRS_1_1000x1000_NNZ_500000.txt");
    private static readonly CRS test_3_2_CRS_2_1000x1000_NNZ_500000 = SparseSerializer.DeserializeCRS(@"..\..\..\..\CRS_TEST\test_3.2_CRS_2_1000x1000_NNZ_500000.txt");

    [Benchmark]
    public void SumCRS10x10_NNZ_1()
    {
        CCS ccs = CCS.FromCRS(CRS.Sum(test_1_0_CRS_1_10x10_NNZ_1, test_1_0_CRS_2_10x10_NNZ_1));
    }

    [Benchmark]
    public void SumCRS10x10_NNZ_10()
    {
        CCS ccs = CCS.FromCRS(CRS.Sum(test_1_1_CRS_1_10x10_NNZ_10, test_1_1_CRS_2_10x10_NNZ_10));
    }

    [Benchmark]
    public void SumCRS10x10_NNZ_50()
    {
        CCS ccs = CCS.FromCRS(CRS.Sum(test_1_2_CRS_1_10x10_NNZ_50, test_1_2_CRS_2_10x10_NNZ_50));
    }


    [Benchmark]
    public void SumCRS100x100_NNZ_100()
    {
        CCS ccs = CCS.FromCRS(CRS.Sum(test_2_0_CRS_1_100x100_NNZ_100, test_2_0_CRS_2_100x100_NNZ_100));
    }

    [Benchmark]
    public void SumCRS100x100_NNZ_1000()
    {
        CCS ccs = CCS.FromCRS(CRS.Sum(test_2_1_CRS_1_100x100_NNZ_1000, test_2_1_CRS_1_100x100_NNZ_1000));
    }

    [Benchmark]
    public void SumCRS100x100_NNZ_5000()
    {
        CCS ccs = CCS.FromCRS(CRS.Sum(test_2_2_CRS_1_100x100_NNZ_5000, test_2_2_CRS_2_100x100_NNZ_5000));
    }


    [Benchmark]
    public void SumCRS1000x1000_NNZ_1000()
    {
        CCS ccs = CCS.FromCRS(CRS.Sum(test_3_0_CRS_1_1000x1000_NNZ_1000, test_3_0_CRS_2_1000x1000_NNZ_1000));
    }

    [Benchmark]
    public void SumCRS1000x1000_NNZ_10000()
    {
        CCS ccs = CCS.FromCRS(CRS.Sum(test_3_1_CRS_1_1000x1000_NNZ_10000, test_3_1_CRS_1_1000x1000_NNZ_10000));
    }

    [Benchmark]
    public void SumCRS1000x1000_NNZ_500000()
    {
        CCS ccs = CCS.FromCRS(CRS.Sum(test_3_2_CRS_1_1000x1000_NNZ_500000, test_3_2_CRS_1_1000x1000_NNZ_500000));
    }




    [Benchmark]
    public void SumCRS10x10_NNZ_1_ser()
    {
        CRS test_1_0_CRS_1_10x10_NNZ_1 = SparseSerializer.DeserializeCRS(@"..\..\..\..\CRS_TEST\test_1.0_CRS_1_10x10_NNZ_1.txt");
        CRS test_1_0_CRS_2_10x10_NNZ_1 = SparseSerializer.DeserializeCRS(@"..\..\..\..\CRS_TEST\test_1.0_CRS_2_10x10_NNZ_1.txt");
        CCS ccs = CCS.FromCRS(CRS.Sum(test_1_0_CRS_1_10x10_NNZ_1, test_1_0_CRS_2_10x10_NNZ_1));
    }

    [Benchmark]
    public void SumCRS10x10_NNZ_10_ser()
    {
        CRS test_1_1_CRS_1_10x10_NNZ_10 = SparseSerializer.DeserializeCRS(@"..\..\..\..\CRS_TEST\test_1.1_CRS_1_10x10_NNZ_10.txt");
        CRS test_1_1_CRS_2_10x10_NNZ_10 = SparseSerializer.DeserializeCRS(@"..\..\..\..\CRS_TEST\test_1.1_CRS_2_10x10_NNZ_10.txt");
        CCS ccs = CCS.FromCRS(CRS.Sum(test_1_1_CRS_1_10x10_NNZ_10, test_1_1_CRS_2_10x10_NNZ_10));
    }

    [Benchmark]
    public void SumCRS10x10_NNZ_50_ser()
    {
        CRS test_1_2_CRS_1_10x10_NNZ_50 = SparseSerializer.DeserializeCRS(@"..\..\..\..\CRS_TEST\test_1.2_CRS_1_10x10_NNZ_50.txt");
        CRS test_1_2_CRS_2_10x10_NNZ_50 = SparseSerializer.DeserializeCRS(@"..\..\..\..\CRS_TEST\test_1.2_CRS_2_10x10_NNZ_50.txt");
        CCS ccs = CCS.FromCRS(CRS.Sum(test_1_2_CRS_1_10x10_NNZ_50, test_1_2_CRS_2_10x10_NNZ_50));
    }


    [Benchmark]
    public void SumCRS100x100_NNZ_100_ser()
    {
        CRS test_2_0_CRS_1_100x100_NNZ_100 = SparseSerializer.DeserializeCRS(@"..\..\..\..\CRS_TEST\test_2.0_CRS_1_100x100_NNZ_100.txt");
        CRS test_2_0_CRS_2_100x100_NNZ_100 = SparseSerializer.DeserializeCRS(@"..\..\..\..\CRS_TEST\test_2.0_CRS_2_100x100_NNZ_100.txt");
        CCS ccs = CCS.FromCRS(CRS.Sum(test_2_0_CRS_1_100x100_NNZ_100, test_2_0_CRS_2_100x100_NNZ_100));
    }

    [Benchmark]
    public void SumCRS100x100_NNZ_1000_ser()
    {
        CRS test_2_1_CRS_1_100x100_NNZ_1000 = SparseSerializer.DeserializeCRS(@"..\..\..\..\CRS_TEST\test_2.1_CRS_1_100x100_NNZ_1000.txt");
        CRS test_2_1_CRS_2_100x100_NNZ_1000 = SparseSerializer.DeserializeCRS(@"..\..\..\..\CRS_TEST\test_2.1_CRS_2_100x100_NNZ_1000.txt");
        CCS ccs = CCS.FromCRS(CRS.Sum(test_2_1_CRS_1_100x100_NNZ_1000, test_2_1_CRS_1_100x100_NNZ_1000));
    }

    [Benchmark]
    public void SumCRS100x100_NNZ_5000_ser()
    {
        CRS test_2_2_CRS_1_100x100_NNZ_5000 = SparseSerializer.DeserializeCRS(@"..\..\..\..\CRS_TEST\test_2.2_CRS_1_100x100_NNZ_5000.txt");
        CRS test_2_2_CRS_2_100x100_NNZ_5000 = SparseSerializer.DeserializeCRS(@"..\..\..\..\CRS_TEST\test_2.2_CRS_2_100x100_NNZ_5000.txt");
        CCS ccs = CCS.FromCRS(CRS.Sum(test_2_2_CRS_1_100x100_NNZ_5000, test_2_2_CRS_2_100x100_NNZ_5000));
    }


    [Benchmark]
    public void SumCRS1000x1000_NNZ_1000_ser()
    {
        CRS test_3_0_CRS_1_1000x1000_NNZ_1000 = SparseSerializer.DeserializeCRS(@"..\..\..\..\CRS_TEST\test_3.0_CRS_1_1000x1000_NNZ_1000.txt");
        CRS test_3_0_CRS_2_1000x1000_NNZ_1000 = SparseSerializer.DeserializeCRS(@"..\..\..\..\CRS_TEST\test_3.0_CRS_2_1000x1000_NNZ_1000.txt");
        CCS ccs = CCS.FromCRS(CRS.Sum(test_3_0_CRS_1_1000x1000_NNZ_1000, test_3_0_CRS_2_1000x1000_NNZ_1000));
    }

    [Benchmark]
    public void SumCRS1000x1000_NNZ_10000_ser()
    {
        CRS test_3_1_CRS_1_1000x1000_NNZ_10000 = SparseSerializer.DeserializeCRS(@"..\..\..\..\CRS_TEST\test_3.1_CRS_1_1000x1000_NNZ_10000.txt");
        CRS test_3_1_CRS_2_1000x1000_NNZ_10000 = SparseSerializer.DeserializeCRS(@"..\..\..\..\CRS_TEST\test_3.1_CRS_2_1000x1000_NNZ_10000.txt");
        CCS ccs = CCS.FromCRS(CRS.Sum(test_3_1_CRS_1_1000x1000_NNZ_10000, test_3_1_CRS_1_1000x1000_NNZ_10000));
    }

    [Benchmark]
    public void SumCRS1000x1000_NNZ_500000_ser()
    {
        CRS test_3_2_CRS_1_1000x1000_NNZ_500000 = SparseSerializer.DeserializeCRS(@"..\..\..\..\CRS_TEST\test_3.2_CRS_1_1000x1000_NNZ_500000.txt");
        CRS test_3_2_CRS_2_1000x1000_NNZ_500000 = SparseSerializer.DeserializeCRS(@"..\..\..\..\CRS_TEST\test_3.2_CRS_2_1000x1000_NNZ_500000.txt");
        CCS ccs = CCS.FromCRS(CRS.Sum(test_3_2_CRS_1_1000x1000_NNZ_500000, test_3_2_CRS_1_1000x1000_NNZ_500000));
    }
}

