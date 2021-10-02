using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace RobotWorld
{
    [TestClass]
    public class RobotTest
    {
        [TestMethod]
        public void whenRobotIsNotGivenFlatwarItCanNotEatFood()
        {
            //given 
            Robot robot = CreateRobot();

            //then
            Assert.IsFalse(robot.Eat("Rice"));
        }

        [TestMethod]
        public void WhenRobotIsGivenSpoonThenItCanEatRice()
        {
            //given
            Robot robot = CreateRobot();

            //when
            robot.addFlatware("Spoon");

            //them
            Assert.IsTrue(robot.Eat("Rice"));
        }

        [TestMethod]
        public void WhenRobotIsGivenForkThenItCanNotEatSoup()
        {
            //given
            Robot robot = CreateRobot();

            //when
            robot.addFlatware("Fork");

            //them
            Assert.IsFalse(robot.Eat("Soup"));
        }

        [TestMethod]
        public void WhenRobotIsGivenChopstickThenItCanEatRice()
        {
            //given
            Robot robot = CreateRobot();

            //when
            robot.addFlatware("Chopstick");

            //them
            Assert.IsTrue(robot.Eat("Rice"));
        }

        [TestMethod]
        public void WhenRobotIsGivenForkThenItCanEatRice()
        {
            //given
            Robot robot = CreateRobot();

            //when
            robot.addFlatware("Fork");

            //them
            Assert.IsTrue(robot.Eat("Rice"));
        }

        [TestMethod]
        public void WhenRobotIsGivenSpoonThenItCanNotEatRiceTwice()
        {
            //given
            Robot robot = CreateRobot();

            //when
            robot.addFlatware("Spoon");
            robot.Eat("Rice");

            //them
            Assert.IsFalse(robot.Eat("Rice"));
        }

        [TestMethod]
        public void WhenRobotIsGivenSpoonAndForkThenItCanEatRiceTwice()
        {
            //given
            Robot robot = CreateRobot();

            //when
            robot.addFlatware("Spoon");
            robot.addFlatware("Fork");
            robot.Eat("Rice");

            //them
            Assert.IsTrue(robot.Eat("Rice"));
        }

        private static Robot CreateRobot()
        {
            Mock<IKnowledge> mockKnowledge = new Mock<IKnowledge>();
            mockKnowledge.Setup(it => it.getRequiredFlatware("Rice")).Returns("Spoon;Chopstick;Fork");
            Robot robot = new Robot(mockKnowledge.Object);
            return robot;
        }
    }
}
