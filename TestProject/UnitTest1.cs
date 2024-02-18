using labar9;
using System.Text;

namespace TestProject
{
    [TestClass]
    public class RunnerTest
    {
        [TestMethod]
        public void TestRunnerDefaultConstructor()
        {
            // Arrange
            Runner runner = new Runner();

            // Act

            // Assert
            Assert.AreEqual(1, runner.Speed);
            Assert.AreEqual(1, runner.Distance);
        }
        [TestMethod]
        public void TestRunnerParameterizedConstructor()
        {
            // Arrange
            double distance = 5;
            double speed = 2.5;

            // Act
            Runner runner = new Runner(distance, speed);

            // Assert
            Assert.AreEqual(distance, runner.Distance);
            Assert.AreEqual(speed, runner.Speed);
        }
        [TestMethod]
        public void TestRunnerCopiedConstructor()
        {
            // Arrange
            Runner runner = new Runner(7, 8);

            // Act
            Runner runner2 = new Runner(runner);

            // Assert
            Assert.AreEqual(runner.Distance, runner2.Distance);
            Assert.AreEqual(runner.Speed, runner2.Speed);
        }
        [TestMethod]
        public void GetTime_ReturnsCorrectTime()
        {
            // Arrange
            Runner runner = new Runner(10, 2);

            // Act
            double time = runner.GetTime();

            // Assert
            Assert.AreEqual(5, time);
        }
        [TestMethod]
        public void GetTime_Static_ReturnsCorrectTime()
        {
            // Arrange
            double distance = 10;
            double speed = 2;

            // Act
            double time = Runner.GetTime(distance, speed);

            // Assert
            Assert.AreEqual(5, time);
        }
        [TestMethod]
        public void GetTime_Static_ReturnsCorrectTime2()
        {
            // Arrange
            Runner runner = new Runner(10, 2);
            double distance = 10;
            double speed = 2;

            // Act
            double time = Runner.GetTime(runner);
            double time2 = Runner.GetTime(distance, speed);

            // Assert
            Assert.AreEqual(time, time2);
        }
        [TestMethod]
        public void OperatorIncrement_IncreasesDistance()
        {
            // Arrange
            Runner runner = new Runner(10, 2);

            // Act
            runner++;

            // Assert
            Assert.AreEqual(10.1, runner.Distance);
        }

        [TestMethod]
        public void OperatorDecrement_DecreasesSpeed()
        {
            // Arrange
            Runner runner = new Runner(10, 2);

            // Act
            runner--;

            // Assert
            Assert.AreEqual(1.95, runner.Speed);
        }
        [TestMethod]
        public void Test()
        {
            // Arrange
            Runner runner = new Runner { Distance = 1000, Speed = 10 };

            // Act
            double speedIncrease = (double)runner;

            // Assert
            Assert.AreEqual((runner.Distance / (runner.Distance / runner.Speed * 0.95)) - runner.Speed, speedIncrease); // ѕредположим, что увеличение скорости должно быть 0.5 с небольшой погрешностью
        }
        [TestMethod]
        public void TestImplicitOperator_ConvertsToTimeString()
        {
            // Arrange
            Runner runner = new Runner(10, 2);

            // Act
            string timeString = runner;

            // Assert
            Assert.AreEqual("05:00:00", timeString);
        }
        [TestMethod]
        public void MinusOperatorTest()
        {
            // Arrange
            Runner r1 = new Runner(10, 2);
            Runner r2 = new Runner(8, 3);
            double expectedDistance = 9.0;

            // Act
            double result = r1 - r2;

            // Assert
            Assert.AreEqual(expectedDistance, result);
        }
        [TestMethod]
        public void MinusOperatorTest2()
        {
            // Arrange
            Runner r1 = new Runner(8, 3);
            Runner r2 = new Runner(10, 2);
            double expectedDistance = 9.0;

            // Act
            double result = r1 - r2;

            // Assert
            Assert.AreEqual(expectedDistance, result);
        }
        [TestMethod]
        public void MinusOperatorTest3()
        {
            // Arrange
            Runner r1 = new Runner(10, 2);
            Runner r2 = new Runner(8, 9999999999999999999);
            double expectedDistance = -1;

            // Act
            double result = r1 - r2;

            // Assert
            Assert.AreEqual(expectedDistance, result);
        }
        [TestMethod]
        public void OperatorPalkaZagibulinaVverh()
        {
            // Arrange
            var originalRunner = new Runner(10, 5);
            double increaseSpeed = 2;

            // Act
            var newRunner = originalRunner ^ increaseSpeed;

            // Assert
            Assert.AreEqual(originalRunner.Distance, newRunner.Distance);
            Assert.AreEqual(originalRunner.Speed + increaseSpeed, newRunner.Speed);
        }
        [TestMethod]
        public void TestEquals_EqualRunners_ReturnsTrue()
        {
            // Arrange
            Runner runner1 = new Runner(10, 5);
            Runner runner2 = new Runner(10, 5);

            // Act
            bool result = runner1.Equals(runner2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestEquals_DifferentRunners_ReturnsFalse()
        {
            // Arrange
            Runner runner1 = new Runner(10, 5);
            Runner runner2 = new Runner(15, 7);

            // Act
            bool result = runner1.Equals(runner2);

            // Assert
            Assert.IsFalse(result);
        }
    }
    [TestClass]
    public class RunnerArrayTests
    {
        [TestMethod]
        public void TestRunnerArrayConstructorWithoutParameters()
        {
            // Arrange
            RunnerArray runnerArray = new RunnerArray();

            // Act

            // Assert
            Assert.IsNotNull(runnerArray);
            Assert.AreEqual(0, runnerArray.Length);
        }
        [TestMethod]
        public void TestConstructorWithSize()
        {
            // Arrange
            int size = 5;

            // Act
            RunnerArray runnerArray = new RunnerArray(size);

            // Assert
            Assert.IsNotNull(runnerArray);
            Assert.AreEqual(size, runnerArray.Length);
        }
        [TestMethod]
        public void TestConstructorWithRunnersParameter()
        {
            // Arrange
            Runner[] runners = new Runner[]
            {
                new Runner(10, 5),
                new Runner(15, 7),
                new Runner(8, 4)
            };

            // Act
            RunnerArray runnerArray = new RunnerArray(runners);

            // Assert
            Assert.AreEqual(runners.Length, runnerArray.Length);
            for (int i = 0; i < runners.Length; i++)
            {
                Assert.AreEqual(runners[i].Distance, runnerArray[i].Distance);
                Assert.AreEqual(runners[i].Speed, runnerArray[i].Speed);
            }
        }
        [TestMethod]
        public void TestRunnerArrayCopyConstructor()
        {
            // Arrange
            Runner runner1 = new Runner(10, 5);
            RunnerArray originalArray = new RunnerArray(new Runner[] { runner1 });

            // Act
            RunnerArray copiedArray = new RunnerArray(originalArray);

            // Assert
            Assert.AreEqual(originalArray.Length, copiedArray.Length);

            for (int i = 0; i < originalArray.Length; i++)
            {
                Assert.AreEqual(originalArray[i].Distance, copiedArray[i].Distance);
                Assert.AreEqual(originalArray[i].Speed, copiedArray[i].Speed);
            }
        }
        [TestMethod]
        public void TestSortRunners()
        {
            // Arrange
            Runner runner1 = new Runner(10, 5);
            Runner runner2 = new Runner(5, 2);
            Runner runner3 = new Runner(5, 3);
            Runner runner4 = new Runner(15, 4);

            RunnerArray runnerArray = new RunnerArray(new Runner[] { runner1, runner2, runner3, runner4 });

            // Act
            runnerArray.SortRunners();

            // Assert
            Assert.AreEqual(runnerArray[0].Distance, 15); // ѕроверка, что первый элемент имеет наибольшую дистанцию
            Assert.AreEqual(runnerArray[1].Distance, 10); // ѕроверка, что второй элемент имеет вторую по величине дистанцию
            Assert.AreEqual(runnerArray[2].Speed, 3);  // ѕроверка, что третий элемент имеет большую скорость чем четвертый вследствие чего имеет меньшее врем€ прохождени€ и находитс€ выше по сортировке
            Assert.AreEqual(runnerArray[3].Speed, 2);  // ѕроверка, что третий элемент имеет наименьшую дистанцию и скорость
        }
        [TestMethod]
        public void TestOutOfRangeIndex()
        {
            // Arrange
            RunnerArray runnerArray = new RunnerArray(3);
            int index = 5;

            // Act & Assert
            Assert.ThrowsException<IndexOutOfRangeException>(() =>
            {
                var runner = runnerArray[index];
            });
        }
    }
}