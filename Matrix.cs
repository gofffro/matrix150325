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
    int matrixSize = 9;
    int[,] matrix;
    public Matrix(int matrixRow, int matrixColumn) 
    {
      this.matrixRow = matrixRow;
      this.matrixColumn = matrixColumn;
      matrix = new int[matrixRow, matrixColumn];
    }
  }
}
