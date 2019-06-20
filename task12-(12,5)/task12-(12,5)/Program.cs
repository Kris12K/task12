using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task12__12_5_
{
    class Program
    {
        //быстрая сортировка
        static void Quicksort(int[] array, int start, int end, ref int movements, ref int comparisons)
        {
            if (start >= end)
            {
                comparisons++;
                return;
            }
            int pivot = Divide(array, start, end, ref movements, ref comparisons);
            Quicksort(array, start, pivot - 1,ref movements,ref comparisons);
            Quicksort(array, pivot + 1, end, ref movements, ref comparisons);
        }
        static int Divide(int[] array, int start, int end, ref int movements, ref int comparisons)
        {
            int temp;
            int marker = start;
            for (int i = start; i <= end; i++)
            {
                if (array[i] < array[end])
                {
                    comparisons++;
                    
                    temp = array[marker];

                    array[marker] = array[i];
                    movements++;

                    array[i] = temp;
                    movements++;

                    marker += 1;
                }
            }

            temp = array[marker];
            array[marker] = array[end];
            movements++;

            array[end] = temp;
            movements++;

            return marker;
        }
        
        //сортировка двоичным деревом
        static void BinaryTreeSort(int[] array, ref int movements, ref int comparisons)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            BinaryTree<int> tree = new BinaryTree<int>();
            for (int i = 0; i < array.Length; i++)
            {
                tree.Add(array[i], ref movements, ref comparisons);
            }
            watch.Stop();
            Console.WriteLine("Время сортировки:" + watch.Elapsed);

            int count = 0;
            BinaryTree<int>.SortedTreeInArray(tree.head, ref array, ref count);
        }

        static Random rnd = new Random();

        static void Main(string[] args)
        {
            //программа сортирует неупорядоченный и упорядоченные по возрастанию и убыванию массивы
            //методами сортировки двоичным деревом и быстрой сортировки

            int movements = 0;//количество перемещений
            int comparisons = 0;//количество сравнений                                                        
            Stopwatch watch;
            int[] array = { 9, 1, 34, 234, 1, 56, 8, 96, 75, 15, 14, 13, 69, 15, 136,48,357,789,12,4 };
            int[] array2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            int[] array3 = { 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            Console.WriteLine("Сортировка двоичным деревом неупорядоченного массива");
            BinaryTreeSort(array, ref movements, ref  comparisons);//Сортировка двоичным деревом
            Console.WriteLine("Перемещения=" + movements);
            Console.WriteLine("Сравнения=" + comparisons);

            movements = 0;
            comparisons = 0;
            Console.WriteLine("Сортировка двоичным деревом упорядоченного по возрастанию массива");
            BinaryTreeSort(array2, ref movements, ref comparisons);//Сортировка двоичным деревом
            Console.WriteLine("Перемещения=" + movements);
            Console.WriteLine("Сравнения=" + comparisons);

            movements = 0;
            comparisons = 0;
            Console.WriteLine("Сортировка двоичным деревом упорядоченного по убыванию массива");
            BinaryTreeSort(array3, ref movements, ref comparisons);//Сортировка двоичным деревом
            Console.WriteLine("Перемещения=" + movements);
            Console.WriteLine("Сравнения=" + comparisons);

            Console.WriteLine();
            Console.WriteLine();

            movements = 0;
            comparisons = 0;
            Console.WriteLine("Быстрая сортировка неупорядоченного массива");
            watch = new Stopwatch();
            watch.Start();
            Quicksort(array, 0, array.Length - 1,ref movements,ref comparisons);//быстрая сортировка
            watch.Stop();
            Console.WriteLine("Время сортировки:" + watch.Elapsed);
            Console.WriteLine("Перемещения=" + movements);
            Console.WriteLine("Сравнения=" + comparisons);

            movements = 0;
            comparisons = 0;
            Console.WriteLine("Быстрая сортировка упорядоченного по возрастанию массива");
            watch = new Stopwatch();
            watch.Start();
            Quicksort(array2, 0, array.Length - 1, ref movements, ref comparisons);//быстрая сортировка
            watch.Stop();
            Console.WriteLine("Время сортировки:" + watch.Elapsed);
            Console.WriteLine("Перемещения=" + movements);
            Console.WriteLine("Сравнения=" + comparisons);

            movements = 0;
            comparisons = 0;
            Console.WriteLine("Быстрая сортировка упорядоченного по убыванию массива");
            watch = new Stopwatch();
            watch.Start();
            Quicksort(array3, 0, array.Length - 1, ref movements, ref comparisons);//быстрая сортировка
            watch.Stop();
            Console.WriteLine("Время сортировки:" + watch.Elapsed);
            Console.WriteLine("Перемещения=" + movements);
            Console.WriteLine("Сравнения=" + comparisons);
            
        }
    }
}
