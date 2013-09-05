using System;

namespace SharpTools.Geometry
{
	public class Point2D
	{
		public double x { get; private set; }
		public double y { get; private set; }

		public Point2D(double x, double y)
		{
			this.x = x;
			this.y = y;
		}
	}
}

