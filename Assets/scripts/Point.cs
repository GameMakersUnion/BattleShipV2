using System;
using UnityEngine;

public struct Point : IEquatable<Point>
{
	public static readonly Point Zero = new Point (0, 0);
	public int x, y;
	
	public Point (int x, int y)
	{
		this.x = x;
		this.y = y;
	}
	
	public Point (Vector2 src)
	{
		x = Mathf.FloorToInt (src.x);
		y = Mathf.FloorToInt (src.y);
	}
	
	public bool Equals (Point other)
	{
		return other.x == x && other.y == y;
	}
}

