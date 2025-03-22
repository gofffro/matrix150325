using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixApp
{
  public class NonInvertibleMatrixException : MatrixException
  {
    public NonInvertibleMatrixException() : base("Матрица вырождена, обратной матрицы не существует") { }
  }
}