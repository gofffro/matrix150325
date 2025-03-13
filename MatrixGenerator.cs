using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixApp
{
  public class MatrixGenerator
  {
    public static Matrix Generate(int sizeMatrix, int minValue, int maxValue)
    {
      if (sizeMatrix <= 0)
      {
        throw new ArgumentException("Размер матрицы должен быть больше 0");
      }

      var random = new Random();
      var generateMatrix = new int[sizeMatrix, sizeMatrix];
      for (int row = 0; row < sizeMatrix; ++row)
      {
        for (int column = 0; column < sizeMatrix; ++column)
        {
          generateMatrix[row, column] = random.Next(minValue, maxValue);
        }
      }
      return new Matrix(generateMatrix);
    }
  }
}
