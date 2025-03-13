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

    public static Matrix operator +(Matrix matrixA,  Matrix matrixB)
    {
      if (matrixA.matrixRow != matrixB.matrixRow || matrixA.matrixColumn != matrixB.matrixColumn)
      {
        throw new ArgumentException("Только матрицы одного размера, можно складывать");
      }

      Matrix matrixResult = new Matrix(matrixA.matrixRow, matrixB.matrixRow);

      int matrixRow = matrixA.matrixRow;
      int matrixColumn = matrixB.matrixColumn;

      for (int row = 0; row < matrixRow; ++row)
      {
        for (int column = 0; column < matrixColumn; ++column)
        {
          matrixResult.matrix[row, column] = matrixA.matrix[row, column] + matrixB.matrix[row, column];
        }
      }

      return matrixResult;
    }

    public static Matrix operator *(Matrix matrixA, Matrix matrixB)
    {
      if (matrixA.matrixColumn != matrixB.matrixRow)
      {
        throw new ArgumentException("Количество столбцов в первой матрице должно равняться количеству строк во втором");
      }

      Matrix matrixResult = new Matrix(matrixA.matrixRow, matrixB.matrixRow);

      int matrixRow = matrixA.matrixRow;
      int matrixColumn = matrixB.matrixColumn;

      for (int row = 0; row < matrixRow; ++row)
      {
        for (int column = 0; column < matrixColumn; ++column)
        {
          for (int sumIndex = 0; sumIndex < matrixA.matrixColumn; ++sumIndex)
          {
            matrixResult.matrix[row, column] += matrixA.matrix[row, sumIndex] * matrixB.matrix[sumIndex, column];
          }
        }
      }

      return matrixResult;
    }
  }
}
