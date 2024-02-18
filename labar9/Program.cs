using System.Text;

namespace labar9
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("task 1");
            Runner r = new Runner(); // Создание объекта без параметров
            r.Show();
            Runner r1 = new Runner(42, 10); // Создание объекта с параметрами
            r1.Show();
            Runner r2 = new Runner(r1); // Создание объекта с помощью конструктора копирования
            r2.Show();
            Console.WriteLine($"Время преодоления дистанции бегуном r1 в часах (Статический метод): {r1.GetTime()}");
            Console.WriteLine($"Время преодоления дистанции бегуном r2 в часах (Метод класса): {Runner.GetTime(r2)}");
            Console.WriteLine($"Число созданных объектов: {Runner.counter}");

            Console.WriteLine("\ntask 2");
            Runner r3 = new Runner(1200, 1);
            Runner r4 = new Runner(5, 2);
            Console.WriteLine($"Дистанция бегуна r3: {r3.Distance}, Скорость: {r3.Speed}");
            Console.WriteLine($"Дистанция бегуна r4: {r4.Distance}, Скорость: {r4.Speed}");

            ++r3;
            Console.WriteLine($"Дистанция r3 после ++: {r3.Distance}");

            --r4;
            Console.WriteLine($"Скорость r4 после --: {r4.Speed}");

            double delta = (double)r3;
            Console.WriteLine($"Значение на которое нужно увеличить скорость r3 чтобы время преодоления дистанции сократилось на 5%: {delta}");

            string time = r4;
            Console.WriteLine($"Время, необходимое для преодоления дистанции r4: {time}");

            double meetDistance = r3 - r4;
            Console.WriteLine($"Дистанция точки встречи r3 и r4: {meetDistance}");

            Runner newRunnerspeed = r3 ^ 2;
            Console.WriteLine($"Скорость нового бегуна на основе r3 с увеличенной скоростью: {newRunnerspeed.Speed}");

            Console.WriteLine($"r3 равен r4?: {r3.Equals(r4)}");

            Console.WriteLine("\ntask 3");
            Console.WriteLine("Инициация пустого массива бегунов:");
            RunnerArray runners = new RunnerArray();
            runners.DisplayRunners();
            Console.WriteLine("\nСкопированный массив:");
            RunnerArray copiedRunners = new RunnerArray(runners);
            copiedRunners.DisplayRunners();
            runners.SortRunners();
            Console.WriteLine("\nПосле сортировки:");
            runners.DisplayRunners();
            Console.WriteLine($"\nЧисло созданных объектов: {RunnerArray.counterArr}");

            while (true)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Создать массив с помощью датчика случайных чисел");
                Console.WriteLine("2. Создать массив, вводя элементы с клавиатуры");

                int choice = GetChoice(1, 2);

                switch (choice)
                {
                    case 1:
                        Console.Write("Введите количество элементов массива: ");
                        int n = PositiveInput();
                        RunnerArray runn = new RunnerArray(n);
                        Console.WriteLine("Инициация массива бегунов:");
                        runn.DisplayRunners();
                        Console.WriteLine("Массив создан.");
                        RunnerArray copiedRunners2 = new RunnerArray(runn);
                        Console.WriteLine("\nСкопированный массив:");
                        copiedRunners2.DisplayRunners();
                        runn.SortRunners();
                        Console.WriteLine("\nМассив после сортировки:");
                        runn.DisplayRunners();
                        try
                        {
                            Console.WriteLine("\nВведите индекс для записи");
                            int index = PositiveInput() - 1;
                            Console.Write($"Введите значение дистанции для нового бегуна: ");
                            double distanceIndex = DoublePositiveInput();
                            Console.Write($"Введите значение скорости для нового бегуна: ");
                            double speedIndex = DoublePositiveInput();
                            runn[index] = new Runner(distanceIndex, speedIndex);
                            Console.WriteLine("\nВведите индекс для чтения");
                            index = PositiveInput() - 1;
                            Console.WriteLine(runn[index].ToString());
                        }
                        catch (Exception Index)
                        {
                            Console.WriteLine(Index.Message);
                        }
                        Console.WriteLine($"\nЧисло созданных объектов: {RunnerArray.counterArr}");
                        break;

                    case 2:
                        Console.Write("Введите количество элементов массива: ");
                        n = PositiveInput();
                        Runner[] arr = new Runner[n];
                        for (int i = 0; i < n; i++)
                        {
                            Console.Write($"Введите значение дистанции для {i + 1} бегуна: ");
                            double distance = DoublePositiveInput();
                            Console.Write($"Введите значение скорости для {i + 1} бегуна: ");
                            double speed = DoublePositiveInput();
                            Runner run = new Runner(distance, speed);
                            arr[i] = run;
                        }
                        RunnerArray runnerArr = new RunnerArray(arr);
                        Console.WriteLine("Инициация массива бегунов:");
                        runnerArr.DisplayRunners();
                        Console.WriteLine("Массив создан.");
                        runnerArr.SortRunners();
                        Console.WriteLine("\nМассив после сортировки:");
                        runnerArr.DisplayRunners();
                        try
                        {
                            Console.WriteLine("\nВведите индекс для записи");
                            int index = PositiveInput() - 1;
                            Console.Write($"Введите значение дистанции для нового бегуна: ");
                            double distanceIndex = DoublePositiveInput();
                            Console.Write($"Введите значение скорости для нового бегуна: ");
                            double speedIndex = DoublePositiveInput();
                            runnerArr[index] = new Runner(distanceIndex, speedIndex);
                            Console.WriteLine("\nВведите индекс для чтения");
                            index = PositiveInput() - 1;
                            Console.WriteLine(runnerArr[index].ToString());
                        }
                        catch (Exception Index)
                        {
                            Console.WriteLine(Index.Message);
                        }
                        Console.WriteLine($"\nЧисло созданных объектов: {RunnerArray.counterArr}");
                        break;
                }
            }
            static int GetChoice(int min, int max)
            {
                int choice;
                bool isValidChoice = false;

                do
                {
                    Console.Write("Ваш выбор: ");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out choice) && choice >= min && choice <= max)
                    {
                        isValidChoice = true;
                    }
                    else
                    {
                        Console.WriteLine("Некорректный выбор. Попробуйте еще раз.");
                    }
                } while (!isValidChoice);

                return choice;
            }

            static int PositiveInput()
            {
                int value;
                bool isValidInput = false;

                do
                {
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out value) && value > 0)
                    {
                        isValidInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод. Пожалуйста, введите положительное целое число.");
                    }
                } while (!isValidInput);

                return value;
            }

            static double DoublePositiveInput()
            {
                double value;
                bool isValidInput = false;

                do
                {
                    string input = Console.ReadLine();

                    if (double.TryParse(input, out value) && value > 0)
                    {
                        isValidInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод. Пожалуйста, введите положительное число.");
                    }
                } while (!isValidInput);

                return value;
            }
        }
    }
}