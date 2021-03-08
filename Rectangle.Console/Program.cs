using System;
using System.Collections.Generic;
using System.Linq;
using Rectangle.Impl;

namespace Rectangle.Console
{
	class Program
	{
		/// <summary>
		/// Use this method for local debugging only. The implementation should remain in Rectangle.Impl project.
		/// See TODO.txt file for task details.
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			//	var rectangle = Service.FindRectangle(new[] { new Point() }.ToList());
			List<Point> points = new List<Point>();
			points.Add(new Point { X = 1, Y = 7 });
			points.Add(new Point { X = 2, Y = 7 });
			points.Add(new Point { X = 5, Y = 2 });
			points.Add(new Point { X = 1, Y = 3 });
			points.Add(new Point { X = 5, Y = 6 });
			points.Add(new Point { X = 3, Y = 4 });

			points.ToList(); 
			var rectangle = Service.FindRectangle(points.ToList());
			System.Console.WriteLine($"{rectangle.X}, {rectangle.Y}, {rectangle.Width}, {rectangle.Height}");

			System.Console.ReadKey();
		}
	}
}
