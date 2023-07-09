// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

int ReadInt(string text)
{
    System.Console.Write(text);
    return Convert.ToInt32(Console.ReadLine());
}


int[,] FillMatrix(int row, int col, int leftRange, int rightRange)
{
    int[,] tempMatrix = new int[row, col];

    Random rand = new Random();

    for (int i = 0; i < tempMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < tempMatrix.GetLength(1); j++)
        {
            tempMatrix[i, j] = rand.Next(leftRange, rightRange + 1);
        }
    }
    return tempMatrix;
}


void PrintMatrix(int[,] matrixForPrint)
{
    for (int i = 0; i < matrixForPrint.GetLength(0); i++)
    {
        for (int j = 0; j < matrixForPrint.GetLength(1); j++)
        {
            System.Console.Write(matrixForPrint[i, j] + "\t");
        }
        System.Console.WriteLine();
    }
}

int SumInLine(int[,] matr, int i)
{
    int sumLine = matr[i, 0];
    for (int j = 1; j < matr.GetLength(1); j++)
    {
        sumLine += matr[i, j];
    }
    return sumLine;
}


void MinSum(int minSum, int sumLine, int[,] matrix)
{
    for (int i = 1; i < matrix.GetLength(0); i++)
    {
        int tempSum = SumInLine(matrix, i);
        if (sumLine > tempSum)
        {
            sumLine = tempSum;
            minSum = i;
        }
    }
    Console.WriteLine($"Cтрокa с наименьшей суммой ({sumLine}) элементов: {minSum + 1}");
}

//--------------------------------------------------------------------------

int rows = ReadInt("Введите количество строк: ");
int columns = ReadInt("Введите количество столбцов: ");

Console.WriteLine();

int[,] matrix = FillMatrix(rows, columns, 0, 10);
PrintMatrix(matrix);

Console.WriteLine();

MinSum(0, SumInLine(matrix, 0), matrix);
