using BenchmarkDotNet.Attributes;

using Lab3;

namespace Benchmark;

[MemoryDiagnoser]
public class MatrixBenchmark
{
    private static readonly Matrix test_1_0_matrix_1_10x10_NNZ_1 = Matrix.FromFile(@"..\..\..\..\MATRIX_TEST\test_1.0_matrix_1_10x10_NNZ_1.txt");
    private static readonly Matrix test_1_0_matrix_2_10x10_NNZ_1 = Matrix.FromFile(@"..\..\..\..\MATRIX_TEST\test_1.0_matrix_2_10x10_NNZ_1.txt");

    private static readonly Matrix test_1_1_matrix_1_10x10_NNZ_10 = Matrix.FromFile(@"..\..\..\..\MATRIX_TEST\test_1.1_matrix_1_10x10_NNZ_10.txt");
    private static readonly Matrix test_1_1_matrix_2_10x10_NNZ_10 = Matrix.FromFile(@"..\..\..\..\MATRIX_TEST\test_1.1_matrix_2_10x10_NNZ_10.txt");

    private static readonly Matrix test_1_2_matrix_1_10x10_NNZ_50 = Matrix.FromFile(@"..\..\..\..\MATRIX_TEST\test_1.2_matrix_1_10x10_NNZ_50.txt");
    private static readonly Matrix test_1_2_matrix_2_10x10_NNZ_50 = Matrix.FromFile(@"..\..\..\..\MATRIX_TEST\test_1.2_matrix_2_10x10_NNZ_50.txt");


    private static readonly Matrix test_2_0_matrix_1_100x100_NNZ_100 = Matrix.FromFile(@"..\..\..\..\MATRIX_TEST\test_2.0_matrix_1_100x100_NNZ_100.txt");
    private static readonly Matrix test_2_0_matrix_2_100x100_NNZ_100 = Matrix.FromFile(@"..\..\..\..\MATRIX_TEST\test_2.0_matrix_2_100x100_NNZ_100.txt");

    private static readonly Matrix test_2_1_matrix_1_100x100_NNZ_1000 = Matrix.FromFile(@"..\..\..\..\MATRIX_TEST\test_2.1_matrix_1_100x100_NNZ_1000.txt");
    private static readonly Matrix test_2_1_matrix_2_100x100_NNZ_1000 = Matrix.FromFile(@"..\..\..\..\MATRIX_TEST\test_2.1_matrix_2_100x100_NNZ_1000.txt");

    private static readonly Matrix test_2_2_matrix_1_100x100_NNZ_5000 = Matrix.FromFile(@"..\..\..\..\MATRIX_TEST\test_2.2_matrix_1_100x100_NNZ_5000.txt");
    private static readonly Matrix test_2_2_matrix_2_100x100_NNZ_5000 = Matrix.FromFile(@"..\..\..\..\MATRIX_TEST\test_2.2_matrix_2_100x100_NNZ_5000.txt");


    private static readonly Matrix test_3_0_matrix_1_1000x1000_NNZ_1000 = Matrix.FromFile(@"..\..\..\..\MATRIX_TEST\test_3.0_matrix_1_1000x1000_NNZ_1000.txt");
    private static readonly Matrix test_3_0_matrix_2_1000x1000_NNZ_1000 = Matrix.FromFile(@"..\..\..\..\MATRIX_TEST\test_3.0_matrix_2_1000x1000_NNZ_1000.txt");

    private static readonly Matrix test_3_1_matrix_1_1000x1000_NNZ_10000 = Matrix.FromFile(@"..\..\..\..\MATRIX_TEST\test_3.1_matrix_1_1000x1000_NNZ_10000.txt");
    private static readonly Matrix test_3_1_matrix_2_1000x1000_NNZ_10000 = Matrix.FromFile(@"..\..\..\..\MATRIX_TEST\test_3.1_matrix_2_1000x1000_NNZ_10000.txt");

    private static readonly Matrix test_3_2_matrix_1_1000x1000_NNZ_500000 = Matrix.FromFile(@"..\..\..\..\MATRIX_TEST\test_3.2_matrix_1_1000x1000_NNZ_500000.txt");
    private static readonly Matrix test_3_2_matrix_2_1000x1000_NNZ_500000 = Matrix.FromFile(@"..\..\..\..\MATRIX_TEST\test_3.2_matrix_2_1000x1000_NNZ_500000.txt");

    [Benchmark]
    public void SumMatrix10x10_NNZ_1()
    {
        CCS ccs = new CCS();
        ccs.FromMatrix(Matrix.Sum(test_1_0_matrix_1_10x10_NNZ_1, test_1_0_matrix_2_10x10_NNZ_1).Values);
    }

    [Benchmark]
    public void SumMatrix10x10_NNZ_10()
    {
        CCS ccs = new CCS();
        ccs.FromMatrix(Matrix.Sum(test_1_1_matrix_1_10x10_NNZ_10, test_1_1_matrix_2_10x10_NNZ_10).Values);
    }

    [Benchmark]
    public void SumMatrix10x10_NNZ_50()
    {
        CCS ccs = new CCS();
        ccs.FromMatrix(Matrix.Sum(test_1_2_matrix_1_10x10_NNZ_50, test_1_2_matrix_2_10x10_NNZ_50).Values);
    }


    [Benchmark]
    public void SumMatrix100x100_NNZ_100()
    {
        CCS ccs = new CCS();
        ccs.FromMatrix(Matrix.Sum(test_2_0_matrix_1_100x100_NNZ_100, test_2_0_matrix_2_100x100_NNZ_100).Values);
    }

    [Benchmark]
    public void SumMatrix100x100_NNZ_1000()
    {
        CCS ccs = new CCS();
        ccs.FromMatrix(Matrix.Sum(test_2_1_matrix_1_100x100_NNZ_1000, test_2_1_matrix_2_100x100_NNZ_1000).Values);
    }

    [Benchmark]
    public void SumMatrix100x100_NNZ_5000()
    {
        CCS ccs = new CCS();
        ccs.FromMatrix(Matrix.Sum(test_2_2_matrix_1_100x100_NNZ_5000, test_2_2_matrix_2_100x100_NNZ_5000).Values);
    }


    [Benchmark]
    public void SumMatrix1000x1000_NNZ_1000()
    {
        CCS ccs = new CCS();
        ccs.FromMatrix(Matrix.Sum(test_3_0_matrix_1_1000x1000_NNZ_1000, test_3_0_matrix_2_1000x1000_NNZ_1000).Values);
    }

    [Benchmark]
    public void SumMatrix1000x1000_NNZ_10000()
    {
        CCS ccs = new CCS();
        ccs.FromMatrix(Matrix.Sum(test_3_1_matrix_1_1000x1000_NNZ_10000, test_3_1_matrix_2_1000x1000_NNZ_10000).Values);
    }

    [Benchmark]
    public void SumMatrix1000x1000_NNZ_500000()
    {
        CCS ccs = new CCS();
        ccs.FromMatrix(Matrix.Sum(test_3_2_matrix_1_1000x1000_NNZ_500000, test_3_2_matrix_2_1000x1000_NNZ_500000).Values);
    }




    [Benchmark]
    public void SumMatrix10x10_NNZ_1_ser()
    {
        Matrix test_1_0_matrix_1_10x10_NNZ_1 = Matrix.FromFile(@"..\..\..\..\MATRIX_TEST\test_1.0_matrix_1_10x10_NNZ_1.txt");
        Matrix test_1_0_matrix_2_10x10_NNZ_1 = Matrix.FromFile(@"..\..\..\..\MATRIX_TEST\test_1.0_matrix_2_10x10_NNZ_1.txt");

        CCS ccs = new CCS();
        ccs.FromMatrix(Matrix.Sum(test_1_0_matrix_1_10x10_NNZ_1, test_1_0_matrix_2_10x10_NNZ_1).Values);
    }

    [Benchmark]
    public void SumMatrix10x10_NNZ_10_ser()
    {
        Matrix test_1_1_matrix_1_10x10_NNZ_10 = Matrix.FromFile(@"..\..\..\..\MATRIX_TEST\test_1.1_matrix_1_10x10_NNZ_10.txt");
        Matrix test_1_1_matrix_2_10x10_NNZ_10 = Matrix.FromFile(@"..\..\..\..\MATRIX_TEST\test_1.1_matrix_2_10x10_NNZ_10.txt");

        CCS ccs = new CCS();
        ccs.FromMatrix(Matrix.Sum(test_1_1_matrix_1_10x10_NNZ_10, test_1_1_matrix_2_10x10_NNZ_10).Values);
    }

    [Benchmark]
    public void SumMatrix10x10_NNZ_50_ser()
    {
        Matrix test_1_2_matrix_1_10x10_NNZ_50 = Matrix.FromFile(@"..\..\..\..\MATRIX_TEST\test_1.2_matrix_1_10x10_NNZ_50.txt");
        Matrix test_1_2_matrix_2_10x10_NNZ_50 = Matrix.FromFile(@"..\..\..\..\MATRIX_TEST\test_1.2_matrix_2_10x10_NNZ_50.txt");

        CCS ccs = new CCS();
        ccs.FromMatrix(Matrix.Sum(test_1_2_matrix_1_10x10_NNZ_50, test_1_2_matrix_2_10x10_NNZ_50).Values);
    }


    [Benchmark]
    public void SumMatrix100x100_NNZ_100_ser()
    {
        Matrix test_2_0_matrix_1_100x100_NNZ_100 = Matrix.FromFile(@"..\..\..\..\MATRIX_TEST\test_2.0_matrix_1_100x100_NNZ_100.txt");
        Matrix test_2_0_matrix_2_100x100_NNZ_100 = Matrix.FromFile(@"..\..\..\..\MATRIX_TEST\test_2.0_matrix_2_100x100_NNZ_100.txt");

        CCS ccs = new CCS();
        ccs.FromMatrix(Matrix.Sum(test_2_0_matrix_1_100x100_NNZ_100, test_2_0_matrix_2_100x100_NNZ_100).Values);
    }

    [Benchmark]
    public void SumMatrix100x100_NNZ_1000_ser()
    {
        Matrix test_2_1_matrix_1_100x100_NNZ_1000 = Matrix.FromFile(@"..\..\..\..\MATRIX_TEST\test_2.1_matrix_1_100x100_NNZ_1000.txt");
        Matrix test_2_1_matrix_2_100x100_NNZ_1000 = Matrix.FromFile(@"..\..\..\..\MATRIX_TEST\test_2.1_matrix_2_100x100_NNZ_1000.txt");

        CCS ccs = new CCS();
        ccs.FromMatrix(Matrix.Sum(test_2_1_matrix_1_100x100_NNZ_1000, test_2_1_matrix_2_100x100_NNZ_1000).Values);
    }

    [Benchmark]
    public void SumMatrix100x100_NNZ_5000_ser()
    {
        Matrix test_2_2_matrix_1_100x100_NNZ_5000 = Matrix.FromFile(@"..\..\..\..\MATRIX_TEST\test_2.2_matrix_1_100x100_NNZ_5000.txt");
        Matrix test_2_2_matrix_2_100x100_NNZ_5000 = Matrix.FromFile(@"..\..\..\..\MATRIX_TEST\test_2.2_matrix_2_100x100_NNZ_5000.txt");

        CCS ccs = new CCS();
        ccs.FromMatrix(Matrix.Sum(test_2_2_matrix_1_100x100_NNZ_5000, test_2_2_matrix_2_100x100_NNZ_5000).Values);
    }


    [Benchmark]
    public void SumMatrix1000x1000_NNZ_1000_ser()
    {
        Matrix test_3_0_matrix_1_1000x1000_NNZ_1000 = Matrix.FromFile(@"..\..\..\..\MATRIX_TEST\test_3.0_matrix_1_1000x1000_NNZ_1000.txt");
        Matrix test_3_0_matrix_2_1000x1000_NNZ_1000 = Matrix.FromFile(@"..\..\..\..\MATRIX_TEST\test_3.0_matrix_2_1000x1000_NNZ_1000.txt");

        CCS ccs = new CCS();
        ccs.FromMatrix(Matrix.Sum(test_3_0_matrix_1_1000x1000_NNZ_1000, test_3_0_matrix_2_1000x1000_NNZ_1000).Values);
    }

    [Benchmark]
    public void SumMatrix1000x1000_NNZ_10000_ser()
    {
        Matrix test_3_1_matrix_1_1000x1000_NNZ_10000 = Matrix.FromFile(@"..\..\..\..\MATRIX_TEST\test_3.1_matrix_1_1000x1000_NNZ_10000.txt");
        Matrix test_3_1_matrix_2_1000x1000_NNZ_10000 = Matrix.FromFile(@"..\..\..\..\MATRIX_TEST\test_3.1_matrix_2_1000x1000_NNZ_10000.txt");

        CCS ccs = new CCS();
        ccs.FromMatrix(Matrix.Sum(test_3_1_matrix_1_1000x1000_NNZ_10000, test_3_1_matrix_2_1000x1000_NNZ_10000).Values);
    }

    [Benchmark]
    public void SumMatrix1000x1000_NNZ_500000_ser()
    {
        Matrix test_3_2_matrix_1_1000x1000_NNZ_500000 = Matrix.FromFile(@"..\..\..\..\MATRIX_TEST\test_3.2_matrix_1_1000x1000_NNZ_500000.txt");
        Matrix test_3_2_matrix_2_1000x1000_NNZ_500000 = Matrix.FromFile(@"..\..\..\..\MATRIX_TEST\test_3.2_matrix_2_1000x1000_NNZ_500000.txt");

        CCS ccs = new CCS();
        ccs.FromMatrix(Matrix.Sum(test_3_2_matrix_1_1000x1000_NNZ_500000, test_3_2_matrix_2_1000x1000_NNZ_500000).Values);
    }
}

