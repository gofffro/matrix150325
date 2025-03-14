using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixApp
{
  public class MatrixException : Exception
  {
    public MatrixException(string message) : base(message) { }
  }
}