using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labar9
{
    public class RunnerArray
    {
        private Runner[] arr; // одномерный массив элементов типа Runner
        public static int counterArr = 0;

        // Конструктор без параметров
        public RunnerArray()
        {
            arr = new Runner[0];
            counterArr++;
        }

        // Конструктор с параметрами, заполняющий элементы случайными значениями
        public RunnerArray(int size)
        {
            arr = new Runner[size];
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                arr[i] = new Runner(random.Next(1, 100), random.Next(1, 100));
            }
            counterArr++;
        }

        // Конструктор с параметрами, позволяющий заполнить массив элементами, заданными пользователем с клавиатуры
        public RunnerArray(Runner[] runners)
        {
            arr = new Runner[runners.Length];
            Array.Copy(runners, arr, runners.Length);
            counterArr++;
        }

        public int Length
        {
            get => arr.Length;
        }

        // Конструктор копирования
        public RunnerArray(RunnerArray other)
        {
            this.arr = new Runner[other.Length];
            for (int i = 0; i < other.Length; i++)
            {
                this.arr[i] = new Runner(other.arr[i].Distance, other.arr[i].Speed);
            }
            counterArr++;
        }

        // Метод для просмотра элементов массива

        public void DisplayRunners()
        {
            if (arr != null && arr.Length > 0)
            {
                foreach (var runner in arr)
                {
                    string time = runner;
                    Console.WriteLine($"Дистанция: {runner.Distance}, Скорость {runner.Speed}, Время: {time}");
                }
            }
            else
            {
                Console.WriteLine("Массив пуст.");
            }
        }
        public void SortRunners()
        {
            Array.Sort(arr, (z, v) =>
            {
                if (z.Distance != v.Distance)
                {
                    return v.Distance.CompareTo(z.Distance);
                }
                return z.GetTime().CompareTo(v.GetTime());
            });
        }
        // Индексатор для доступа к элементам коллекции
        public Runner this[int index]
        {
            get
            {
                if (index < 0 || index >= arr.Length)
                {
                    throw new IndexOutOfRangeException("Индекс выходит за границы.");
                }
                return arr[index];
            }
            set
            {
                if (index < 0 || index >= arr.Length)
                {
                    throw new IndexOutOfRangeException("Индекс выходит за границы.");
                }
                arr[index] = value;
            }
        }
    }
}
