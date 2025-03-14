using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixApp
{
  public class UnsupportedSizeException : MatrixException
  {
    public UnsupportedSizeException() : base("К сожалению, определитель в этой программе можно посчитать только для матриц размерностью 1х1, 2х2, 3х3") { }
  }
}