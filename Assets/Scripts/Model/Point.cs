using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Point 
{
	public int x;
	public int y;

	public Point (int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	public static Point operator +(Point a, Point b)
	{
	return new Point(a.x + b.x, a.y + b.y);
	}

	public static Point operator -(Point p1, Point p2) 
	{
	return new Point(p1.x - p2.x, p1.y - p2.y);
	}

	public static bool operator ==(Point a, Point b)
	{
	return a.x == b.x && a.y == b.y;
	}

	public static bool operator !=(Point a, Point b)
	{
	return !(a == b);
	}

	public override bool Equals (object obj)
	{
		if (obj is Point)
		{
			Point p = (Point)obj;
			return x == p.x && y == p.y;
		}
	return false;
	}

	public bool Equals (Point p)
	{
	return x == p.x && y == p.y;
	}

	//Using the Cantor method, which only works for positive numbers. //To get around this, I flip negatives and add 10000.  Works so long as point never goes beyond 10000
	public override int GetHashCode ()
	{
		int a = (x >= 0 ? x : -x + 10000);
		int b = (y >= 0 ? y : -y + 10000);
		return (a + b) * (a + b + 1) / 2 + a;;
	}

	public override string ToString()
	{
		//Debug.Log("WE MADE IT");
		return string.Format ("({0},{1})", x, y);
	}
}
