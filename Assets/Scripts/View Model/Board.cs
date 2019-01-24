using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Board : MonoBehaviour 
{
	[SerializeField] GameObject tilePrefab;
	//[SerializeField] LevelData ld;
	public Dictionary<Point, Tile> tiles = new Dictionary<Point, Tile>();
	Point[] moves = new Point[4] {new Point(1,0), new Point(0,1), new Point(-1,0), new Point (0,-1)};
	Color selectedTileColor = Color.cyan;
	Color defaultTileColor = Color.clear;
	public void Load (LevelData data)
	{
	//	Debug.Log(data.ToString());
	//	Debug.Log(data.name);
	//	Debug.Log(data.tiles);
	//	Debug.Log(data.tiles.ToString());
		
	//	Debug.Log(data.tiles.Count);
	//	Debug.Log(data.tiles.ToArray()[0]);
	//	Debug.Log(string.Format ("({0},{1})", data.tiles[0].x));
		for (int i = 0; i < data.tiles.Count; ++i)
		{
			GameObject instance = Instantiate(tilePrefab) as GameObject;
			Tile t = instance.GetComponent<Tile>();
			t.Load(data.tiles[i]);
			tiles.Add(t.pos, t);
		}
	}

	public List<Tile> Search (Tile start, Func<Tile, Tile, bool> addTile)
	{
		List<Tile> retValue = new List<Tile>();
		
		ClearSearch();

		Queue<Tile> checkNext = new Queue<Tile>();
		Queue<Tile> checkNow = new Queue<Tile>();
		start.distance = 0;
		checkNow.Enqueue(start);
		retValue.Add(start);

		Tile temp;
		while (checkNow.Count > 0)
		{
			Tile t = checkNow.Dequeue();

			for(int i = 0; i <= 3 ; i++)
			{
				temp = GetTile(t.pos + moves[i]);
				if(temp == null || temp.distance <= t.distance + 1)
					continue;
				
				if (addTile(t, temp))
				{
					temp.distance = t.distance + 1;
					temp.prev = t;
					checkNext.Enqueue(temp);
					retValue.Add(temp);
				}
			}
			if(checkNow.Count == 0)
				SwapReference(ref checkNow, ref checkNext);

		}
		return retValue;
	}

	void ClearSearch ()
	{
		foreach (Tile t in tiles.Values)
		{
			t.prev = null;
			t.distance = int.MaxValue;
		}
	}

	public Tile GetTile (Point p)
	{
		return tiles.ContainsKey(p) ? tiles[p] : null;
	}

	void SwapReference (ref Queue<Tile> a, ref Queue<Tile> b)
	{
		Queue<Tile> temp = a;
		a = b;
		b = temp;
	}

	public void SelectTiles (List<Tile> tiles)
	{
		for (int i = tiles.Count - 1; i >= 0; i--)
			tiles[i].GetComponent<Renderer>().material.SetColor("_Color", selectedTileColor);
	}
	public void DeSelectTiles (List<Tile> tiles)
	{
		for (int i = tiles.Count - 1; i >= 0; i--)
			tiles[i].GetComponent<Renderer>().material.SetColor("_Color", defaultTileColor);
	}

}
