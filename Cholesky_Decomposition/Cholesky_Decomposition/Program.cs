using System;

class CholeskyDecomposition
{
    // Cholesky Decomposition Fonksiyonu
    static bool Cholesky(double[,] A, double[,] L, int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                double sum = 0;

                if (j == i) // Diyagonal elemanlar
                {
                    for (int k = 0; k < j; k++)
                        sum += Math.Pow(L[j, k], 2);

                    double diff = A[j, j] - sum;

                    if (diff <= 0)
                    {
                        Console.WriteLine("Error: The matrix is not positive definite.");
                        return false;
                    }

                    L[j, j] = Math.Sqrt(diff);
                }
                else // Alt üçgensel elemanlar
                {
                    for (int k = 0; k < j; k++)
                        sum += L[i, k] * L[j, k];

                    L[i, j] = (A[i, j] - sum) / L[j, j];
                }
            }
        }
        return true;
    }

    // Kullanıcıdan Matris Girişi Alma Fonksiyonu
    static double[,] GetMatrixInput(int n)
    {
        double[,] matrix = new double[n, n];
        Console.WriteLine($"\nPlease Enter a symmetric positive definite matrix of size {n}x{n}:");

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"A[{i + 1},{j + 1}] = ");
                matrix[i, j] = Convert.ToDouble(Console.ReadLine());
            }
        }
        return matrix;
    }

    // Ana Program
    static void Main(string[] args)
    {
        Console.Write("Enter the size of matrix (n x n): ");
        int n = Convert.ToInt32(Console.ReadLine());

        double[,] A = GetMatrixInput(n);
        double[,] L = new double[n, n]; // Alt üçgensel matris

        Console.WriteLine("\n Enter Matrix A:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
                Console.Write($"{A[i, j]}\t");
            Console.WriteLine();
        }

        // Cholesky Decomposition'u çağır
        if (Cholesky(A, L, n))
        {
            Console.WriteLine("\nCholesky Decomposition result (Lower Triangular Matris L):");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                    Console.Write($"{L[i, j]:F4}\t");
                Console.WriteLine();
            }
        }
    }
}
