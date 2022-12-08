using BenchmarkDotNet.Attributes;
using BenchmarkDotNet;

using Lab3;

namespace Benchmark;

[MemoryDiagnoser]
public class SparseBenchmark
{
    private static readonly CRS test1_1_CRS10x10_10 = SparseGenerator.CRSFromFile(@"..\..\..\..\test_1_matrix1_10x10_10NNZ.txt");
    private static readonly CRS test1_2_CRS10x10_10 = SparseGenerator.CRSFromFile(@"..\..\..\..\test_1_matrix2_10x10_10NNZ.txt");

    private static readonly CRS test2_1_CRS100x100_100 = SparseGenerator.CRSFromFile(@"..\..\..\..\test_2_matrix1_100x100_100NNZ.txt");
    private static readonly CRS test2_2_CRS100x100_100 = SparseGenerator.CRSFromFile(@"..\..\..\..\test_2_matrix2_100x100_100NNZ.txt");

    private static readonly CRS test3_1_CRS1kx1k_1k = SparseGenerator.CRSFromFile(@"..\..\..\..\test_3_matrix1_1000x1000_1000NNZ.txt");
    private static readonly CRS test3_2_CRS1kx1k_1k = SparseGenerator.CRSFromFile(@"..\..\..\..\test_3_matrix2_1000x1000_1000NNZ.txt");

    //private static readonly CRS test4_1_CRS10kx10k_nnz10k = SparseGenerator.CRSFromFile(@"..\..\..\..\test_4_matrix1_10000x10000_10000NNZ.txt");
    //private static readonly CRS test4_2_CRS10kx10k_nnz10k = SparseGenerator.CRSFromFile(@"..\..\..\..\test_4_matrix2_10000x10000_10000NNZ.txt");

    [Benchmark]
    public void SumCRS10x10()
    {
        CRS.Sum(test1_1_CRS10x10_10, test1_2_CRS10x10_10);
    }

    [Benchmark]
    public void SumCRS100x100()
    {
        CRS.Sum(test2_1_CRS100x100_100, test2_2_CRS100x100_100);
    }

    [Benchmark]
    public void SumCRS1kx1k()
    {
        CRS.Sum(test3_1_CRS1kx1k_1k, test3_2_CRS1kx1k_1k);
    }

    //[Benchmark]
    //public void SumCRS10kx10k()
    //{
    //    CRS.Sum(test4_1_CRS10kx10k_nnz10k, test4_2_CRS10kx10k_nnz10k);
    //}


    [Benchmark]
    public void SumCRS10x10ToCCS()
    {
        CCS ccs = CCS.FromCRS(CRS.Sum(test1_1_CRS10x10_10, test1_2_CRS10x10_10));
    }

    [Benchmark]
    public void SumCRS100x100ToCCS()
    {
        CCS ccs = CCS.FromCRS(CRS.Sum(test2_1_CRS100x100_100, test2_2_CRS100x100_100));
    }

    [Benchmark]
    public void SumCRS1kx1kToCCS()
    {
        CCS ccs = CCS.FromCRS(CRS.Sum(test3_1_CRS1kx1k_1k, test3_2_CRS1kx1k_1k));
    }

    //[Benchmark]
    //public void SumCRS10kx10kToCCS()
    //{
    //    CCS ccs = CCS.FromCRS(CRS.Sum(test4_1_CRS10kx10k_nnz10k, test4_2_CRS10kx10k_nnz10k));
    //}
}

