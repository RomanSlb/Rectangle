using System;
using System.Collections.Generic;
using System.Linq;

namespace Rectangle.Impl
{
	public static class Service
	{
		/// <summary>
		/// See TODO.txt file for task details.
		/// Do not change contracts: input and output arguments, method name and access modifiers
		/// </summary>
		/// <param name="points"></param>
		/// <returns></returns>
		public static Rectangle FindRectangle(List<Point> points)
		{

			

			try
			{
				if (!points.Contains(null))
				{
					if (points.Count() > 1)
					{
						if (points.GroupBy(mx=>new { mx.X, mx.Y}).Count() == points.Count())
						{
							bool isTheBiggestXUnique = points.OrderByDescending(mx => mx.X).Select(mx => mx.X).First() != points.OrderByDescending(mx => mx.X).Select(mx => mx.X).Skip(1).First();
							bool isTheBiggestYUnique = points.OrderByDescending(mx => mx.Y).Select(mx => mx.Y).First() != points.OrderByDescending(mx => mx.Y).Select(mx => mx.Y).Skip(1).First();
							bool isTheLeastXUnique = points.OrderBy(mx => mx.X).Select(mx => mx.X).FirstOrDefault() != points.OrderBy(mx => mx.X).Select(mx => mx.X).Skip(1).FirstOrDefault();
							bool isTheLeastYUnique = points.OrderBy(mx => mx.Y).Select(mx => mx.Y).FirstOrDefault() != points.OrderBy(mx => mx.Y).Select(mx => mx.Y).Skip(1).FirstOrDefault();

							if (isTheBiggestXUnique)
							{
								points.Remove(points.OrderByDescending(mx => mx.X).FirstOrDefault());   // Remove the biggest value on X


								int topLeftX = points.Min(value => value.X);
								int topLeftY = points.Max(value => value.Y);

								int bottomLeftX = points.Min(value => value.X);
								int bottomLeftY = points.Min(value => value.Y);

								int bottomRightX = points.Max(value => value.X);
								int bottomRightY = points.Min(value => value.Y);

								int heightX = topLeftX - bottomLeftX;
								int heightY = topLeftY - bottomLeftY;

								int height = Convert.ToInt32(Math.Sqrt(Math.Pow(heightX, 2) + Math.Pow(heightY, 2)));

								int widthX = bottomRightX - bottomLeftX;
								int widthY = bottomRightY - bottomLeftY;

								int width = Convert.ToInt32(Math.Sqrt(Math.Pow(widthX, 2) + Math.Pow(widthY, 2)));

								return new Rectangle { X = topLeftX, Y = topLeftY, Width = width, Height = height };
							}
							else if (isTheBiggestYUnique)
							{
								points.Remove(points.OrderByDescending(mx => mx.Y).FirstOrDefault());   // Remove the biggest value on Y


								int topLeftX = points.Min(value => value.X);
								int topLeftY = points.Max(value => value.Y);

								int bottomLeftX = points.Min(value => value.X);
								int bottomLeftY = points.Min(value => value.Y);

								int bottomRightX = points.Max(value => value.X);
								int bottomRightY = points.Min(value => value.Y);

								int heightX = topLeftX - bottomLeftX;
								int heightY = topLeftY - bottomLeftY;

								int height = Convert.ToInt32(Math.Sqrt(Math.Pow(heightX, 2) + Math.Pow(heightY, 2)));

								int widthX = bottomRightX - bottomLeftX;
								int widthY = bottomRightY - bottomLeftY;

								int width = Convert.ToInt32(Math.Sqrt(Math.Pow(widthX, 2) + Math.Pow(widthY, 2)));

								return new Rectangle { X = topLeftX, Y = topLeftY, Width = width, Height = height };
							}
							else if (isTheLeastXUnique)
							{
								points.Remove(points.OrderBy(mx => mx.X).FirstOrDefault());   // Remove the least value on X


								int topLeftX = points.Min(value => value.X);
								int topLeftY = points.Max(value => value.Y);

								int bottomLeftX = points.Min(value => value.X);
								int bottomLeftY = points.Min(value => value.Y);

								int bottomRightX = points.Max(value => value.X);
								int bottomRightY = points.Min(value => value.Y);

								int heightX = topLeftX - bottomLeftX;
								int heightY = topLeftY - bottomLeftY;

								int height = Convert.ToInt32(Math.Sqrt(Math.Pow(heightX, 2) + Math.Pow(heightY, 2)));

								int widthX = bottomRightX - bottomLeftX;
								int widthY = bottomRightY - bottomLeftY;

								int width = Convert.ToInt32(Math.Sqrt(Math.Pow(widthX, 2) + Math.Pow(widthY, 2)));

								return new Rectangle { X = topLeftX, Y = topLeftY, Width = width, Height = height };
							}
							else if (isTheLeastYUnique)
							{
								points.Remove(points.OrderBy(mx => mx.Y).FirstOrDefault());   // Remove the least value on Y


								int topLeftX = points.Min(value => value.X);
								int topLeftY = points.Max(value => value.Y);

								int bottomLeftX = points.Min(value => value.X);
								int bottomLeftY = points.Min(value => value.Y);


								int bottomRightX = points.Max(value => value.X);
								int bottomRightY = points.Min(value => value.Y);

								int heightX = topLeftX - bottomLeftX;
								int heightY = topLeftY - bottomLeftY;

								int height = Convert.ToInt32(Math.Sqrt(Math.Pow(heightX, 2) + Math.Pow(heightY, 2)));

								int widthX = bottomRightX - bottomLeftX;
								int widthY = bottomRightY - bottomLeftY;

								int width = Convert.ToInt32(Math.Sqrt(Math.Pow(widthX, 2) + Math.Pow(widthY, 2)));

								return new Rectangle { X = topLeftX, Y = topLeftY, Width = width, Height = height };
							}

							else
							{
								throw new Exception("The input list is invalid");
							}
						}
						else
						{
							throw new Exception("There shouldn't be points with a same coordinates");
							}
						}
					else
					{
						throw new Exception("'points' should contain at least 2 points");
					}
				}
                else
                {
					throw new Exception("'points' argument shouldn't be null");
				}
			}
            catch(Exception ex)
            {
				Console.WriteLine($"{ex.Message}");
				return  new Rectangle();
			}
		}
	}
}
