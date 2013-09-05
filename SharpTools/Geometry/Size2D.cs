using System;

namespace SharpTools.Geometry
{
	public class Size2D
	{
		public double Width { get; private set; }
		public double Height { get; private set; }

		public Size2D(double width, double height)
		{
			this.Width = width;
			this.Height = height;
		}
	}
}

