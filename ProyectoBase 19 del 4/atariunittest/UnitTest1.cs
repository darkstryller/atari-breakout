using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Game;
using System.Reflection;

namespace atariunittest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void collisionBallBrick()
        {

            
            var ball = new Ball(new Vector2(5, 5));
            var brick = new Brick(new Vector2(5, 5), 100);


            PropertyInfo realWidthPropertyBall = typeof(Ball).GetProperty("RealWidth");
            PropertyInfo realHeightPropertyBall = typeof(Ball).GetProperty("RealHeight");
            PropertyInfo realWidthPropertyBrick = typeof(Brick).GetProperty("RealWidth");
            PropertyInfo realHeightPropertyBrick = typeof(Brick).GetProperty("RealHeight");

            realHeightPropertyBall.SetValue(ball, 10);
            realWidthPropertyBall.SetValue(ball, 10);
            realHeightPropertyBrick.SetValue(brick, 10);
            realWidthPropertyBrick.SetValue(brick, 10);

            bool result = ball.IsBoxColliding(brick);

            
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CreateBrick_ReturnsNewBrickInstance()
        {
            
            var expectedType = brickFactory.BrickSpawnPositions.glassBrick;

            
            var brick = brickFactory.CreateBrick(expectedType, new Vector2(0, 0));

            
            Assert.IsNotNull(brick);
            Assert.AreEqual(expectedType, brick.Type);
        }

        [TestMethod]
        public void GetBrick_ReturnsPooledBrickInstance()
        {
            
            var pool = new brickPool();
            var expectedType = brickFactory.BrickSpawnPositions.glassBrick;
            var position = new Vector2(0, 0);

            
            var brick1 = pool.GetBrick(expectedType, position);
            var brick2 = pool.GetBrick(expectedType, position);

            
            Assert.IsNotNull(brick1);
            Assert.IsNotNull(brick2);
            //Assert.AreSame(brick1, brick2);
            Assert.IsTrue(brick1.IsActive);
            Assert.AreEqual(expectedType, brick1.Type);
            Assert.AreEqual(position, brick1.Transform.position);
        }

        [TestMethod]
        public void ReleaseBrick_ResetsBrickInstance()
        {
           
            var pool = new brickPool();
            var brick = pool.GetBrick(brickFactory.BrickSpawnPositions.glassBrick, new Vector2(0, 0));

           
            pool.ReleaseBrick(brick);

            
            Assert.IsFalse(brick.IsActive);
        }

    }
}
