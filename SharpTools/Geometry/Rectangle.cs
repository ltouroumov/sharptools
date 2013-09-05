using System;

namespace SharpTools.Geometry
{
	public class Rectangle
	{
		public Point2D Origin { get; private set; }
		public Size2D Size { get; private set; }

		public Rectangle(Point2D origin, Size2D size)
		{
			this.Origin = origin;
			this.Size = size;
		}

		public Rectangle(double x, double y, double width, double height) : this(new Point2D(x, y), new Size2D(width, height))
		{

		}

		public bool Contains(Point2D point)
		{
			var x0 = Origin.x;
			var x1 = x0 + Size.Width;
			var y0 = Origin.y;
			var y1 = y0 + Size.Height;

			return (x0 <= point.x && point.x <= x1) && (y0 <= point.y && point.y <= y1);
		}
	}
}

