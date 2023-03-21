// Задача HARD SORT необязательная. Считается за три обязательных
// Задайте двумерный массив из целых чисел. Количество строк и 
// столбцов задается с клавиатуры. Отсортировать элементы по 
// возрастанию слева направо и сверху вниз.
// Например, задан массив:
// 1 4 7 2
// 5 9 10 3
// После сортировки
// 1 2 3 4
// 5 7 9 10


void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
            Console.Write($"{array[i, j], 3}\t");
        Console.WriteLine();
    }
}

void FillArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
            array[i, j] = new Random().Next(-20, 21);
}
void SortPuzir(int size, int[] array)
{
    bool check = true;
    while (check)
    {
        check = false;
        for (int i = 1; i < size; i++)
        {
            if (array[i] <array[i - 1])
            {
                check = true;
                array[i] = array[i] + array[i - 1];
                array[i - 1] = array[i] - array[i - 1];
                array[i] = array[i] - array[i - 1];
            }
        }
    }
}
void PreSort(int[,] array)
{
    int[] tmp = new int[array.GetLength(0) * array.GetLength(1)];
    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
            tmp[j+i*array.GetLength(1)] = array[i, j];
    SortPuzir(array.GetLength(0) * array.GetLength(1), tmp);
    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
            array[i, j] = tmp[j+i*array.GetLength(1)];
}

Console.WriteLine("Введите количество строк двумерного массива");
int rows = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите количество столбцов двумерного массива");
int cols = Convert.ToInt32(Console.ReadLine());
int[,] array = new int[rows, cols];
FillArray(array);
PrintArray(array);
PreSort(array);
Console.WriteLine();
PrintArray(array);