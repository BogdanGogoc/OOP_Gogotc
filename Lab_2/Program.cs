using System;
using static Program;

class Program
{
    static Random rnd = new Random();

    public class Task1
    {
        public int[] arr1;
        public int[] arr2;
        public int[] sum;
        public int n, min = -100, max = 101;
        public double result = 0;

        public void Task1_1()
        {
            Console.Write("Введіть кількість чисел: ");
            n = Convert.ToInt32(Console.ReadLine());
            arr1 = new int[n];
            result = 0;

            Console.Write("Масив: ");
            for (int i = 0; i < n; i++)
            {
                arr1[i] = rnd.Next(min, max);
                Console.Write(" " + arr1[i]);
                result += arr1[i];
            }
            Console.Write("\nСереднє арифметичне: " + (result / n));
        }

        public void Task1_2()
        {
            Console.Write("Введіть кількість вимірів: ");
            n = Convert.ToInt32(Console.ReadLine());
            arr1 = new int[n * 2];
            arr2 = new int[n * 2];
            sum = new int[n * 2];
            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = rnd.Next(min, max);
                arr2[i] = rnd.Next(min, max);
                if(i < n) sum[i] = arr1[i];
                else sum[i] = arr2[i];
            }
            Console.Write("\nВектор 1: ");
            foreach (int i in arr1) Console.Write(" " + i);
            Console.Write("\nВектор 2: ");
            foreach (int i in arr2) Console.Write(" " + i);
            Console.Write("\nВектор сума: ");
            foreach (int i in sum) Console.Write(" " + i);
        }

        public void Task1_3()
        {
            Console.Write("Введіть кількість чисел: ");
            n = Convert.ToInt32(Console.ReadLine());
            arr1 = new int[n];

            Console.Write("Масив: ");
            for (int i = 0; i < n; i++)
            {
                arr1[i] = rnd.Next(min, max);
                Console.Write(" " + arr1[i]);
            }
            Array.Sort(arr1);
            Console.Write("\nПосортований масив: ");
            foreach (int i in arr1) Console.Write(" " + i);
        }
    }

    public class Task2
    {
        public int[,] matrix;
        public int[] row;
        public int n, h, result = 0, min = -100, max = 101;

        public void Task2_1()
        {
            Console.Write("Введіть кількість чисел: ");
            n = Convert.ToInt32(Console.ReadLine());
            matrix = new int[n, n];
            row = new int[n];

            Console.WriteLine("Матриця: ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rnd.Next(min, max);
                    if (i % 2 == 1)
                        row[j] = matrix[i, j];
                    Console.Write(" " + matrix[i, j]);
                }
                Console.WriteLine();
                if (i % 2 == 1)
                {
                    Array.Sort(row);
                    for (int j = 0; j < n; j++)
                    {
                        matrix[i, j] = row[j];
                    }
                }
            }

            Console.WriteLine("\nПосортована матриця: ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++) Console.Write(" " + matrix[i, j]);
                Console.WriteLine();
            }
        }

        public void Task2_2()
        {
            Console.Write("Введіть кількість рядків: ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введіть кількість стовпців: ");
            h = Convert.ToInt32(Console.ReadLine());
            matrix = new int[n, h];
            int x = 1;
            result = 0;

            Console.WriteLine("Матриця: ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    matrix[i, j] = rnd.Next(0, 5);
                    if (matrix[i, j] == 0) x = 0;
                    Console.Write(" " + matrix[i, j]);
                }
                Console.WriteLine();
                result += x;
                x = 1;
            }
            Console.Write("Кількість рядків без нульових елементів: " + result);
        }

        public void Task2_3()
        {
            Console.Write("Введіть кількість рядків: ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введіть кількість стовпців: ");
            h = Convert.ToInt32(Console.ReadLine());
            matrix = new int[n, h];
            int x = 0, high = 10;
            result = -1;

            Console.WriteLine("Матриця: ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    matrix[i, j] = rnd.Next(0, 10);
                    Console.Write(" " + matrix[i, j]);
                }
                Console.WriteLine();
            }

            do {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < h; j++)
                    {
                        if (matrix[i, j] > result && matrix[i, j] < high) { result = matrix[i, j]; x = 0; }
                        if (matrix[i, j] == result) x++;
                    }
                }
                if (x > 1) break;
                high = result;
                result = -1;
            } while (true);
            Console.Write("Максимальне число, що зустрічається більше одного разу: " + result);
        }
    }

    static void Main(string[] args)
    {
        Task1 task1 = new Task1();
        Task2 task2 = new Task2();
        int x;
        while (true)
        {
            while (true)
            {
                Console.WriteLine("\n\n1. Завдання 1.1");
                Console.WriteLine("2. Завдання 1.2");
                Console.WriteLine("3. Завдання 1.3");
                Console.WriteLine("4. Завдання 2.1");
                Console.WriteLine("5. Завдання 2.2");
                Console.WriteLine("6. Завдання 2.3");
                Console.WriteLine("0. Вихід");

                x = Convert.ToInt32(Console.ReadLine());

                if (x > -1 && x < 7) break;
                Console.WriteLine("Помилка");
            }
            switch (x)
            {
                case 1: task1.Task1_1(); break;
                case 2: task1.Task1_2(); break;
                case 3: task1.Task1_3(); break;
                case 4: task2.Task2_1(); break;
                case 5: task2.Task2_2(); break;
                case 6: task2.Task2_3(); break;
                case 0: Environment.Exit(0); break;
            }
        }
    }
}
