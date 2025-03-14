using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixApp
{
  public class SquareMatrixException : MatrixException
  {
    public SquareMatrixException() : base("Матрица должна быть квадратной") { }
  }
}