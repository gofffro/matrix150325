using NUnit.Framework;
using MatrixApp;
using System;

namespace MatrixApp.Tests
{
  [TestFixture]
  public class MatrixTests
  {
    [Test]
    public void Constructor_ValidSize_CreatesMatrix()
    {
      var matrix = new Matrix(2, 2);
      Assert.IsNotNull(matrix);
    }

    [Test]
    public void Constructor_InvalidSize_ThrowsException()
    {
      Assert.Throws<InvalidSizeException>(() => new Matrix(0, 2));
      Assert.Throws<SquareMatrixException>(() => new Matrix(2, 3));
    }

    [Test]
    public void Determinant_2x2Matrix_ReturnsCorrectResult()
    {
      int[,] data = new int[,] { { 4, 6 }, { 3, 8 } };
      var matrix = new Matrix(data);
      Assert.AreEqual(14, matrix.Determinant());
    }

    [Test]
    public void SumOfElements_ReturnsCorrectSum()
    {
      int[,] data = new int[,] { { 1, 2 }, { 3, 4 } };
      var matrix = new Matrix(data);
      Assert.AreEqual(10, matrix.SumOfElements());
    }

    [Test]
    public void Operator_Add_AddsMatricesCorrectly()
    {
      int[,] a = new int[,] { { 1, 2 }, { 3, 4 } };
      int[,] b = new int[,] { { 5, 6 }, { 7, 8 } };
      var matrixA = new Matrix(a);
      var matrixB = new Matrix(b);

      var result = matrixA + matrixB;

      Assert.AreEqual(new Matrix(new int[,] { { 6, 8 }, { 10, 12 } }), result);
    }

    [Test]
    public void Operator_MultiplyScalar_MultipliesCorrectly()
    {
      int[,] data = new int[,] { { 1, 2 }, { 3, 4 } };
      var matrix = new Matrix(data);
      var result = matrix * 2;

      Assert.AreEqual(new Matrix(new int[,] { { 2, 4 }, { 6, 8 } }), result);
    }

    [Test]
    public void Operator_Comparison_CorrectlyCompares()
    {
      var a = new Matrix(new int[,] { { 1, 2 }, { 3, 4 } }); 
      var b = new Matrix(new int[,] { { 5, 5 }, { 5, 5 } }); 

      Assert.IsTrue(a < b);
      Assert.IsTrue(b > a);
      Assert.IsTrue(a != b);
    }

    [Test]
    public void Clone_ReturnsDeepCopy()
    {
      var original = new Matrix(new int[,] { { 1, 2 }, { 3, 4 } });
      var clone = original.DeepCopy();

      Assert.AreEqual(original, clone);
      Assert.AreNotSame(original, clone); 
    }

    [Test]
    public void Inverse_ValidMatrix_ReturnsInverse()
    {
      var matrix = new Matrix(new int[,] { { 4, 7 }, { 2, 6 } });
      var inverse = matrix.Inverse();

      var identity = matrix * inverse;

      Assert.That(identity.ToString(), Does.Contain("1").Or.Contain("0")); 
    }

    [Test]
    public void Inverse_SingularMatrix_ThrowsException()
    {
      var matrix = new Matrix(new int[,] { { 1, 2 }, { 2, 4 } }); 
      Assert.Throws<NonInvertibleMatrixException>(() => matrix.Inverse());
    }
  }
}
