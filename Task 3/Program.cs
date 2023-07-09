// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

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

void Result(int[,] matrixOne, int[,] matrixTwo, int[,] resultMatrix)
{
    for (int i = 0; i < resultMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < resultMatrix.GetLength(1); j++)
        {
            resultMatrix[i, j] = 0;
            for (int k = 0; k < matrixOne.GetLength(1); k++)
            {
                resultMatrix[i, j] += matrixOne[i, k] * matrixTwo[k, j];
            }
        }
    }
}

//-----------------------------------------------------------------------------------------

int rows = ReadInt("Введите количество строк для первой матрицы (и для результирующей матрицы): ");
int columns = ReadInt("Введите количество столбцов для первой матрицы (и количество строк для второй): ");
int columns2 = ReadInt("Введите количество столбцов для второй матрицы (и для результирующей матрицы): ");

int[,] matrixOne = FillMatrix(rows, columns, 1, 4);
PrintMatrix(matrixOne);

Console.WriteLine();

int[,] matrixTwo = FillMatrix(columns, columns2, 1, 4);
PrintMatrix(matrixTwo);

int[,] resultMatrix = new int[rows, columns2];

Result(matrixOne, matrixTwo, resultMatrix);

System.Console.WriteLine();
PrintMatrix(resultMatrix);


