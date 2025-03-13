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
    int matrixRow = 3;
    int matrixColumn = 3;
    int[,] matrix;
    public Matrix(int matrixRow, int matrixColumn) 
    {
      if (matrixRow !=  matrixColumn)
      {
        throw new ArgumentException("Матрица должна быть квадратной.");
      }

      if (matrixRow <= 0 || matrixColumn <= 0)
      {
        throw new ArgumentException("Размеры матрицы, должны быть больше нуля");
      }
      this.matrixRow = matrixRow;
      this.matrixColumn = matrixColumn;
      matrix = new int[matrixRow, matrixColumn];
    }
  }
}
