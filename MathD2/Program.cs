using System;

namespace MathD2
{
    class Program
    {
        static int ind = 0;
        static void Main(string[] args)
        {
            int[,] Matrix3 = new int[3, 3];
            int[,] Matrix4 = new int[4, 4];
            int[,] Matrix5 = new int[5, 5];
            Menu(ref Matrix3, ref Matrix4, ref Matrix5);
        }
        static void PrintMainMenu()
        {
            Console.WriteLine("1. Матрица 3х3" +
                "\n2. Матрица 4х4" +
                "\n3. Матрица 5х5" +
                "\n4. Выход");
            Console.Write("Вы выбрали: ");
        }
        static void PrintMatrixMenu()
        {
            Console.WriteLine("\n1. Заполнение матрицы" +
                "\n2. Печать матрицы" +
                "\n3. Вывод свойств" +
                "\n4. Выход");
            Console.Write("Вы выбрали: ");
        }
        static void PrintCreateMatrixMenu()
        {
            Console.WriteLine("\nКак заполнить матрицу?" +
                "\n1. Автоматически" +
                "\n2. Вручную" +
                "\n3. Назад");
            Console.Write("Вы выбрали: ");
        }
        static void PrintMatrix(int[,] Matrix)
        {
            Console.WriteLine();
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                    Console.Write($"\t\t{Matrix[i, j]}");
                Console.WriteLine("");
            }
        }
        static void PrintInfoMatrix(int[,] Matrix)
        {
            Console.WriteLine();
            Console.WriteLine($"Рефлексивность: {Raflex(Matrix)}");
            Console.WriteLine($"Симметричность: {Simmetr(Matrix)}");
            Console.WriteLine($"Связность: {Svyaznost(Matrix)}");
            Console.WriteLine($"Транзитивность: {Tranzit(Matrix)}");
        }
        static void PrintMenu(int SelectMenu)
        {
            switch (SelectMenu)
            {
                case 1: PrintMainMenu(); break;
                case 2: PrintMatrixMenu(); break;
                case 3: PrintCreateMatrixMenu(); break;
                case 4: break;

            }
        }
        static string Raflex(int[,] Matrix)
        {
            string tmp = "";
            for (int i = 0; (i < Matrix.GetLength(0)) && (tmp != "."); i++)
            {
                if (Matrix[0, 0] == Matrix[i, i] && Matrix[0, 0] == 1)
                    tmp = "Рефлекcивна";
                else
                    tmp = ".";
            }
            if (tmp == ".")
            {
                for (int i = 0; (i < Matrix.GetLength(0)) && (tmp != "Не обладает данным свойством"); i++)
                {
                    if (Matrix[0, 0] == Matrix[i, i] && Matrix[0, 0] == 0)
                        tmp = "Антирефлексивна";
                    else
                        tmp = "Не обладает данным свойством";
                }
            }
            return tmp;
        }
        static string Simmetr(int[,] Matrix)
        {
            string tmp = "";
            for (int i = 0; (i < Matrix.GetLength(0)) && tmp != "."; i++)
            {
                for (int j = 0; (j < Matrix.GetLength(1)) && tmp != "."; j++)
                {
                    if (Matrix[i, j] == 1)
                    {
                        if (Matrix[i, j] == Matrix[j, i])
                            tmp = "Симметрична";
                        else
                            tmp = ".";
                    }
                }
            }

            int[,] tmpMatrix = new int[Matrix.GetLength(0), Matrix.GetLength(1)];
            // ассиметричность
            if (tmp == ".")
            {
                for (int i = 0; i < Matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < Matrix.GetLength(1); j++)
                    {
                        tmpMatrix[j, i] = Matrix[i, j];
                    }
                }

                int count = 0;
                if (Raflex(Matrix) == "Антирефлексивна")
                {
                    bool f = true;
                    for (int i = 0; (i < Matrix.GetLength(0)) && f; i++)
                    {
                        for (int j = 0; (j < Matrix.GetLength(1) && f); j++)
                        {
                            if (i != j)
                            {
                                if (Matrix[i, j] == 1)
                                {
                                    count++;
                                }
                                f = Matrix[i, j] * tmpMatrix[i, j] == 0;
                            }
                        }
                    }
                    if (f && count != 0)
                        return "Асимметрична";
                    else
                        return "Не симметрична";
                }
                else
                {
                    count = 0;
                    bool f = true;
                    for (int i = 0; (i < Matrix.GetLength(0)) && f; i++)
                    {
                        for (int j = 0; (j < Matrix.GetLength(1) && f); j++)
                        {
                            if (i != j)
                            {
                                if (Matrix[i, j] == 1)
                                {
                                    count++;
                                }
                                f = Matrix[i, j] * tmpMatrix[i, j] == 0;
                            }
                        }
                    }
                    if (f && count != 0)
                        return "Антисимметрична";
                    else
                        return "Не симметрична";
                }
            }
            return tmp;

        }
        static string Svyaznost(int[,] Matrix)
        {
            bool f = true;
            for (int i = 0; i < Matrix.GetLength(0) && f; i++)
            {
                for (int j = 0; j < Matrix.GetLength(1) && f; j++)
                {
                    if (i != j)
                    {
                        if (Matrix[i, j] == 1 || Matrix[j, i] == 1)
                            f = true;
                        else
                            f = false;
                    }
                }
            }
            if (f == true)
                return "Связность выполняется";
            else
                return "Связность не выполняется";
        }
        static bool Tranzit2(int[,] Matrix, int i, int j)
        {
            bool f = true;
            for (int k = 0; k < Matrix.GetLength(1) && f == true; k++)
            {
                if (j != k && Matrix[j, k] == 1)
                {
                    if (Matrix[i, k] == 1)
                        f = true;
                    else
                        return false;
                }
            }
            return f;
        }
        static string Tranzit(int[,] Matrix)
        {
            int count = 0;
            bool f = true;
            for (int i = 0; i < Matrix.GetLength(0) && f != false; i++)
            {
                for (int j = 0; j < Matrix.GetLength(1) && f != false; j++)
                {
                    if (i != j)
                    {
                        if (Matrix[i, j] == 1)
                        {
                            count++;
                            f = Tranzit2(Matrix, i, j);
                        }
                    }
                }
            }
            if (f == true && count != 0)
                return "Транзитивно";
            else
                return "Не транзитивно";
        }
        static void CreateMatrixAuto(ref int[,] Matrix)
        {
            Random rand = new Random();
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                    Matrix[i, j] = rand.Next(0, 2);
            }
        }
        static void CreateMatrixManual(ref int[,] Matrix)
        {
            string buf;
            bool ok = false;
            Console.WriteLine();
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Console.WriteLine($"Заполнение {i} строки");
                    do
                    {
                        Console.Write($"Введите {j} элемент: ");
                        buf = Console.ReadLine();
                        ok = Int32.TryParse(buf, out Matrix[i, j]);
                    } while (!ok || Matrix[i, j] < 0 || Matrix[i, j] > 1);
                    Console.WriteLine();
                }
            }
        }
        static void CreateMatrixMenu(ref int[,] Matrix)
        {
            int choice = 0; // переменная, отвечающая за выбор действия в подменю
            bool exit = false;
            while (!exit)
            {
                choice = Input(choice, 3, 3); // выбор действия в меню
                switch (choice)
                {
                    case 1: CreateMatrixAuto(ref Matrix); PrintMatrix(Matrix); break;
                    case 2: CreateMatrixManual(ref Matrix); PrintMatrix(Matrix); break;
                    case 3: exit = true; break;
                }
            }
        }
        static void SubMenuMatrix(ref int[,] Matrix)
        {
            int choice = 0; // переменная, отвечающая за выбор действия в подменю
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine($"Работа с матрицей {Matrix.GetLength(0)} x {Matrix.GetLength(1)}");
                PrintMatrix(Matrix);
                choice = Input(choice, 4, 2);
                switch (choice)
                {
                    case 1: CreateMatrixMenu(ref Matrix); break;
                    case 2: PrintMatrix(Matrix); break;
                    case 3: PrintInfoMatrix(Matrix); break;
                    case 4: exit = true; break;
                }
            }
        }
        static int Input(int choice, int count, int SelectMenu)
        {
            bool ok = false;
            string buf;
            do
            {
                PrintMenu(SelectMenu); // печать меню в консоль
                buf = Console.ReadLine();
                ok = Int32.TryParse(buf, out choice);
                if (!ok || choice < 1 || choice > count)
                {
                    Console.WriteLine("\n\nНекорректный ввод\n\n");
                    ind--;
                }
            } while (!ok || choice < 1 || choice > count);
            return choice;
        }
        static void Menu(ref int[,] Matrix3, ref int[,] Matrix4, ref int[,] Matrix5)
        {
            int choice = 0;
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                choice = Input(choice, 4, 1);
                switch (choice)
                {
                    case 1: Console.Clear(); SubMenuMatrix(ref Matrix3); break;
                    case 2: Console.Clear(); SubMenuMatrix(ref Matrix4); break;
                    case 3: Console.Clear(); SubMenuMatrix(ref Matrix5); break;
                    case 4: exit = true; break;
                }
            }
        }
    }
}
