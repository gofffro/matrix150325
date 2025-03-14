﻿using System.CodeDom.Compiler;

namespace MatrixApp
{
  internal class Program
  {
    static void Main(string[] args)
    {
      try
      {
        Console.Write("Матрица A");
        Matrix matrixA = CreateMatrix();
        Matrix cloneMatrixA = matrixA.Clone();

        Console.Write("Матрица B");
        Matrix matrixB = CreateMatrix();
        Matrix cloneMatrixB = matrixB.Clone();

        string menuMethod;
        while (true)
        {
          Console.WriteLine();
          Console.WriteLine($"Matrix A:\n{matrixA.ToString()}\n");
          Console.WriteLine($"Matrix B:\n{matrixB.ToString()}\n");
          Console.WriteLine("Меню:");
          Console.WriteLine("1 - Сложить матрицы");
          Console.WriteLine("2 - Умножить матрицы");
          Console.WriteLine("3 - Умножить A на число");
          Console.WriteLine("4 - Умножить B на число");
          Console.WriteLine("5 - Сравнить A и B (A > B)");
          Console.WriteLine("6 - Сравнить A и B (A < B)");
          Console.WriteLine("7 - Определитель A (размерность матрицы от 1х1 до 3х3)");
          Console.WriteLine("8 - Определитель B (размерность матрицы от 1х1 до 3х3)");
          Console.WriteLine("9 - GetHashCode A");
          Console.WriteLine("10 - GetHashCode B");
          Console.WriteLine("11 - Проверить A.Equals(B)");
          Console.WriteLine("12 - Обратная матрица A");
          Console.WriteLine("13 - Обратная матрица B");
          Console.WriteLine("0 - Выход");
          Console.Write("Ввод: ");
          menuMethod = Console.ReadLine();
          Console.Clear();

          try
          {
            switch (menuMethod)
            {
              case "0":
                Console.WriteLine("Программа завершила работу");
                return;
              case "1":
                Console.WriteLine("Сумма A + B:\n" + (cloneMatrixA + cloneMatrixB));
                break;
              case "2":
                Console.WriteLine("Произведение A * B:\n" + (cloneMatrixA * cloneMatrixB));
                break;
              case "3":
                Console.Write("Введите число - множитель для элементов матрицы A: ");
                double scalarA = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("A * число:\n" + (cloneMatrixA * scalarA));
                break;
              case "4":
                Console.Write("Введите число - множитель для элементов матрицы В: ");
                double scalarB = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("B * число:\n" + (cloneMatrixB * scalarB));
                break;
              case "5":
                Console.WriteLine($"A > B: {matrixA > matrixB}");
                break;
              case "6":
                Console.WriteLine($"A < B: {matrixA < matrixB}");
                break;
              case "7":
                Console.WriteLine($"det(A): {matrixA.Determinant()}");
                break;
              case "8":
                Console.WriteLine($"det(B): {matrixB.Determinant()}");
                break;
              case "9":
                Console.WriteLine($"HashCode A: {matrixA.GetHashCode()}");
                break;
              case "10":
                Console.WriteLine($"HashCode B: {matrixB.GetHashCode()}");
                break;
              case "11":
                Console.WriteLine($"A == B: {matrixA == matrixB}");
                break;
              case "12":
                Console.WriteLine("Обратная A:\n" + matrixA.Inverse());
                break;
              case "13":
                Console.WriteLine("Обратная B:\n" + matrixB.Inverse());
                break;
              default:
                Console.WriteLine("Некорректный ввод.");
                break;
            }
          }
          catch (NonInvertibleMatrixException ex)
          {
            Console.WriteLine($"Ошибка: {ex.Message}");
          }
          catch (MatrixException ex)
          {
            Console.WriteLine($"Ошибка матрицы: {ex.Message}");
          }
          catch (Exception ex)
          {
            Console.WriteLine($"Непредвиденная ошибка: {ex.Message}");
          }
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Ошибка: {ex.Message}");
      }
    }

    public static Matrix CreateMatrix()
    {
      Console.Write("\nУкажите 1 число - размерность для квадратной матрицы: ");
      int sizeMatrix = Convert.ToInt32(Console.ReadLine());

      Console.Write("Выберите метод заполнения матрицы: 1 - вручную, 2 - сгенерировать: ");
      string method = Console.ReadLine();

      Matrix matrix;
      if (method == "1")
      {
        matrix = new Matrix(sizeMatrix, sizeMatrix);
        matrix.EntryMatrix();
      }
      else if (method == "2")
      {
        Console.Write("Введите минимальное значение: ");
        int minValue = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите максимальное значение: ");
        int maxValue = Convert.ToInt32(Console.ReadLine());
        matrix = MatrixGenerator.Generate(sizeMatrix, minValue, maxValue);
      }
      else
      {
        throw new InvalidOperationException("Неверный выбор метода создания");
      }
      return matrix;
    }
  }
}