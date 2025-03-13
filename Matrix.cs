using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MatrixApp
{
  public class Matrix
  {
    int matrixRow;
    int matrixColumn;
    int[,] matrix;

    public Matrix(int matrixRow, int matrixColumn) 
    {
      if (matrixRow !=  matrixColumn)
      {
        throw new ArgumentException("Матрица должна быть квадратной");
      }

      if (matrixRow <= 0 || matrixColumn <= 0)
      {
        throw new ArgumentException("Размеры матрицы, должны быть больше нуля");
      }
      this.matrixRow = matrixRow;
      this.matrixColumn = matrixColumn;
      matrix = new int[matrixRow, matrixColumn];
    }

    public void EntryMatrix()
    {
      for (int row = 0; row < matrixRow; ++row)
      {
        for (int column = 0; column < matrixColumn; ++column)
        {
          Console.Write($"Введите эначение ячейки [{row}, {column}]: ");
          matrix[row, column] = int.Parse(Console.ReadLine());
        }
      }
    }

    public void OutputMatrix()
    {
      for (int row = 0; row < matrixRow; ++row)
      {
        for (int column = 0; column < matrixColumn; ++column)
        {
          Console.Write(matrix[row, column] + " ");
        }
        Console.WriteLine();
      }
    }
  }
}
