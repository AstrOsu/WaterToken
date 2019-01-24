using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour 
{
	[SerializeField] GameObject tilePrefab;
	//[SerializeField] LevelData ld;
	public Dictionary<Point, Tile> tiles = new Dictionary<Point, Tile>();
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
}
