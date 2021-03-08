using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Rectangle.Impl;

namespace Rectangle.Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Test1()
		{
			var rectangle = Service.FindRectangle(new[] { new Point() }.ToList());
			Assert.IsNotNull(rectangle);
		}

		[Test]
		public void Test_OnlyOnePoint()
		{
			List<Point> points = new List<Point>();
			points.Add(new Point { X = 1, Y = 7 });
			var rectangle = Service.FindRectangle(points.ToList());

			Assert.AreEqual((0, 0, 0, 0), (rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height));
		}

		[Test]
		public void Test_SamePoints()
		{
			List<Point> points = new List<Point>();
			points.Add(new Point{X = 1, Y = 7});
			points.Add(new Point{X = 1,Y = 7});
			points.Add(new Point{X = 3,Y = 4});
			var rectangle = Service.FindRectangle(points.ToList());

			Assert.AreEqual((0, 0, 0, 0), (rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height));
		}

		[Test]
		public void Test_CorrectPoints_MaxXIsOnlyOne()
		{
			List<Point> points = new List<Point>();
			points.Add(new Point { X = 1, Y = 7 }); 
			points.Add(new Point { X = 5, Y = 2 });
			points.Add(new Point { X = 3, Y = 4 });
			var rectangle = Service.FindRectangle(points.ToList());

			Assert.AreEqual((1, 7, 2, 3), (rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height));
		}

		[Test]
		public void Test_CorrectPoints_MaxYIsOnlyOne()
		{
			//Max X is not unique
			List<Point> points = new List<Point>();
			points.Add(new Point { X = 1, Y = 7 });
			points.Add(new Point { X = 5, Y = 2 });
			points.Add(new Point { X = 5, Y = 6 });
			points.Add(new Point { X = 3, Y = 4 });
			var rectangle = Service.FindRectangle(points.ToList());

			Assert.AreEqual((3, 6, 2, 4), (rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height));
		}

		[Test]
		public void Test_CorrectPoints_MinXIsOnlyOne()
		{
			//Max X, Max Y are not unique
			List<Point> points = new List<Point>();
			points.Add(new Point { X = 1, Y = 7 });
			points.Add(new Point { X = 2, Y = 7 });
			points.Add(new Point { X = 5, Y = 2 });
			points.Add(new Point { X = 5, Y = 6 });
			points.Add(new Point { X = 3, Y = 4 });
			var rectangle = Service.FindRectangle(points.ToList());

			Assert.AreEqual((2, 7, 3, 5), (rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height));
		}
		[Test]
		public void Test_CorrectPoints_MinYIsOnlyOne()
		{
			//Max X, Max Y, Min X are not unique
			List<Point> points = new List<Point>();
			points.Add(new Point { X = 1, Y = 7 });
			points.Add(new Point { X = 2, Y = 7 });
			points.Add(new Point { X = 5, Y = 2 });
			points.Add(new Point { X = 1, Y = 3 });
			points.Add(new Point { X = 5, Y = 6 });
			points.Add(new Point { X = 3, Y = 4 });
			var rectangle = Service.FindRectangle(points.ToList());

			Assert.AreEqual((1, 7, 4, 4), (rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height));
		}

		[Test]
		public void Test_CorrectPoints_AreNotUniqueXYMaxMin()
		{
			//Max X, Max Y, Min X, Min Y are not unique
			List<Point> points = new List<Point>();
			points.Add(new Point { X = 1, Y = 7 });
			points.Add(new Point { X = 2, Y = 7 });
			points.Add(new Point { X = 5, Y = 2 });
			points.Add(new Point { X = 1, Y = 3 });
			points.Add(new Point { X = 5, Y = 6 });
			points.Add(new Point { X = 3, Y = 4 });
			points.Add(new Point { X = 4, Y = 2 });
			var rectangle = Service.FindRectangle(points.ToList());

			Assert.AreEqual((0, 0, 0, 0), (rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height));
		}
	}
}