using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labar9
{
    public class Runner
    {
        private double speed;
        private double distance;
        public static int counter = 0;

        public double Speed
        {
            get => speed;
            set
            {
                speed = value;
            }
        }
        public double Distance
        {
            get => distance;
            set
            {
                distance = value;
            }
        }

        public Runner()// конструктор без параметров
        {
            Speed = 1;
            Distance = 1;
            counter++;
        }
        public Runner(double distance, double speed)///конструктор с параметрами
        {
            Distance = distance;
            Speed = speed;
            counter++;
        }
        public Runner(Runner r)// конструктор копирования
        {
            Speed = r.speed;
            Distance = r.distance;
            counter++;
        }
        public double GetTime()
        {
            return Distance / Speed;
        }

        public static double GetTime(double distance, double speed)
        {
            return distance / speed;
        }

        public static double GetTime(Runner runner)
        {
            return GetTime(runner.Distance, runner.Speed);
        }

        public void Show()
        {
            Console.WriteLine($"Скорость бегуна: {Speed}, дистанция: {Distance}, время за котрое бегун пробежит дистанцию (в часах): {GetTime()}");
        }

        public static Runner operator ++(Runner runner)
        {
            runner.Distance += 0.1;
            return runner;
        }

        public static Runner operator --(Runner runner)
        {
            runner.Speed -= 0.05;
            return runner;
        }

        public static explicit operator double(Runner runner)
        {
            double requiredSpeed = runner.Distance / (runner.Distance / runner.Speed * 0.95);
            double speedIncrease = requiredSpeed - runner.Speed;
            return speedIncrease;
        }

        public static implicit operator string(Runner runner)
        {
            int hours = (int)(runner.Distance / runner.Speed);
            int minutes = (int)((runner.Distance % runner.Speed) * 60 / runner.Speed);
            int seconds = (int)((runner.Distance % runner.Speed) * 3600 / runner.Speed - minutes * 60);

            return $"{hours:D2}:{minutes:D2}:{seconds:D2}";
        }

        public static double operator -(Runner r1, Runner r2)
        {
            double distance = 15;
            double Meet = distance / (r1.Speed + r2.Speed);

            if (Meet * r1.Speed >= 15 || Meet * r2.Speed >= 15)
            {
                return -1;
            }
            if (r1.Speed > r2.Speed)
            {
                return Meet * r1.Speed;
            }
            return Meet * r2.Speed;

        }

        public static Runner operator ^(Runner r, double increaseSpeed)
        {
            Runner r2 = new Runner(r);
            r2.Speed += increaseSpeed;
            return r2;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var otherRunner = (Runner)obj;
            return Distance == otherRunner.Distance && Speed == otherRunner.Speed;
        }
        public override string ToString()

        {
            return $"Скорость бегуна: {this.Distance}, дистанция: {this.Speed}, время за котрое бегун пробежит дистанцию (в часах): {this.GetTime()}) ";
        }
    }
}
