using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixApp
{
  public class InvalidSizeException : MatrixException
  {
    public InvalidSizeException() : base("Размеры матрицы должны быть больше нуля") { }
  }
}