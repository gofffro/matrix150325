using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace MatrixApp
{
  public class Matrix : ICloneable, IComparable<Matrix>
  {
    int matrixRow;
    int matrixColumn;
    double[,] matrix;

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
      matrix = new double[matrixRow, matrixColumn];
    }

    public Matrix(int[,] arrayMatrix)
    {
      matrixRow = arrayMatrix.GetLength(0);
      matrixColumn = arrayMatrix.GetLength(1);

      if (matrixRow != matrixColumn)
      {
        throw new ArgumentException("Матрица должна быть квадратной");
      }

      matrix = new double[matrixRow, matrixColumn];
      
      for (int row = 0; row < matrixRow; ++row)
      {
        for (int column = 0; column < matrixColumn; ++column)
        {
          matrix[row, column] = arrayMatrix[row, column];
        }
      }
    }

    public void EntryMatrix()
    {
      for (int row = 0; row < matrixRow; ++row)
      {
        for (int column = 0; column < matrixColumn; ++column)
        {
          Console.Write($"Введите эначение ячейки [{row}, {column}]: ");
          matrix[row, column] = double.Parse(Console.ReadLine());
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

    public double Determinant()
    {
      if (matrixRow != matrixColumn)
      {
        throw new ArgumentException("Матрица должна быть квадратной");
      }

      int matrixSize = matrixRow;

      switch (matrixSize)
      {
        case 1:
          return matrix[0, 0];
        case 2:
          return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
        case 3:
          return matrix[0, 0] * (matrix[1, 1] * matrix[2, 2] - matrix[1, 2] * matrix[2, 1])
             - matrix[0, 1] * (matrix[1, 0] * matrix[2, 2] - matrix[1, 2] * matrix[2, 0])
             + matrix[0, 2] * (matrix[1, 0] * matrix[2, 1] - matrix[1, 1] * matrix[2, 0]);
        default:
          throw new ArgumentException("К сожалению, определитель в этой программе можно посчитать только для 1х1, 2х2, 3х3 матриц");
      }
    }

    public double SumElements()
    {
      double sumMatrix = 0;

      for (int row = 0; row < matrixRow; ++row)
      {
        for (int column = 0; column < matrixColumn; ++column)
        {
          sumMatrix += matrix[row, column];
        }
      }
      return sumMatrix;
    }

    public static Matrix operator +(Matrix matrixA, Matrix matrixB)
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

    public static Matrix operator *(Matrix matrix, double scalarNumber)
    {
      Matrix resultMatrix = new Matrix(matrix.matrixRow, matrix.matrixColumn);
      for (int row = 0; row < matrix.matrixRow; ++row)
      {
        for (int column = 0; column < matrix.matrixColumn; ++column)
        {
          resultMatrix.matrix[row, column] = (matrix.matrix[row, column] * scalarNumber);
        }
      }
      return resultMatrix;
     }

    public static bool operator >(Matrix matrixA, Matrix matrixB)
    {
      return matrixA.SumElements() > matrixB.SumElements();
    }

    public static bool operator <(Matrix matrixA, Matrix matrixB)
    {
      return matrixA.SumElements() < matrixB.SumElements();
    }

    public static bool operator ==(Matrix matrixA, Matrix matrixB)
    {
      if (matrixA.matrixRow != matrixB.matrixRow || matrixA.matrixColumn != matrixB.matrixColumn)
      {
        return false;
      }

      for (int row = 0; row < matrixA.matrixRow; ++row)
      {
        for (int column = 0; column < matrixA.matrixColumn; ++column)
        {
          if (matrixA.matrix[row, column] != matrixB.matrix[row, column])
          {
            return false;
          }
        }
      }
      return true;
    }

    public static bool operator !=(Matrix matrixA, Matrix matrixB)
    {
      return !(matrixA == matrixB);
    }

    public static bool operator >=(Matrix matrixA, Matrix matrixB)
    {
      return matrixA > matrixB || matrixA == matrixB;
    }

    public static bool operator <=(Matrix matrixA, Matrix matrixB)
    {
      return matrixA < matrixB || matrixA == matrixB;
    }

    public static bool operator true(Matrix matrix)
    {
      return matrix.matrixRow > 0 && matrix.Determinant() != 0;
    }

    public static bool operator false(Matrix matrix)
    {
      return matrix.matrixRow <= 0 || matrix.Determinant() == 0;
    }

    public override string ToString()
    {
      string resultMatrix = "";

      for (int row = 0; row < matrixRow; ++row)
      {
        for (int column = 0; column < matrixColumn; ++column)
        {
          resultMatrix += matrix[row, column].ToString();

          if (column < matrixColumn - 1)
          {
            resultMatrix += " ";
          }
        }
        if (row < matrixRow - 1)
        {
          resultMatrix += Environment.NewLine;
        }
      }
      return resultMatrix;
    }


    public static implicit operator string(Matrix m)
    {
      return m.ToString();
    }

    public static implicit operator Matrix(int[,] array)
    {
      return new Matrix(array);
    }

    public int CompareTo(Matrix otherMatrix)
    {
      if (this > otherMatrix)
      {
        return 1;
      }
      if (this < otherMatrix)
      {
        return -1;
      }
      return 0;
    }

    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    public bool Equals(Matrix matrixA, Matrix matrixB) 
    {
      return matrixA == matrixB;
    }

    public Matrix Inverse()
    {
      double detMatrix = Determinant();
      if (detMatrix == 0)
      {
        throw new ArgumentException(""); 
      }

      Matrix adjugate = new Matrix(matrixRow, matrixColumn);

      for (int row = 0; row < matrixRow; ++row)
      {
        for (int column = 0; column < matrixColumn; ++column)
        {
          double sign = (row + column) % 2 == 0 ? 1 : -1;
          adjugate.matrix[row, column] = (sign * Minor(row, column));
        }
      }

      adjugate = Transpose(adjugate);
      return adjugate * (1 / detMatrix); 
    }

    private double Minor(int skipRow, int skipColumn)
    {
      Matrix subMatrix = new Matrix(matrixRow - 1, matrixColumn - 1);
      int subRow = 0;

      for (int row = 0; row < matrixRow; ++row)
      {
        if (row == skipRow)
        {
          continue;
        }

        int subColumn = 0;

        for (int column = 0; column < matrixColumn; ++column)
        {
          if (column == skipColumn)
          {
            continue;
          }
          subMatrix.matrix[subRow, subColumn] = matrix[row, column];
          subColumn++;
        }
        subRow++;
      }
      return subMatrix.Determinant();
    }

    private Matrix Transpose(Matrix originalMatrix)
    {

      Matrix transposedMatrix = new Matrix(originalMatrix.matrixRow, originalMatrix.matrixColumn);

      for (int row = 0; row < originalMatrix.matrixRow; ++row)
      {
        for (int column = 0; column < originalMatrix.matrixColumn; ++column)
        {
          transposedMatrix.matrix[column, row] = originalMatrix.matrix[row, column];
        }
      }
      return transposedMatrix;
    }

    public Matrix(Matrix matrix)
    {
      matrixRow = matrix.matrixRow;
      matrixColumn = matrix.matrixColumn;
      this.matrix = (double[,])matrix.matrix.Clone();
    }

    public object Clone()
    {
      return new Matrix(this);
    }

  }
}
