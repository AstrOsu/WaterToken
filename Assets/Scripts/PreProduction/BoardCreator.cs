using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class BoardCreator : MonoBehaviour 
{
	[SerializeField] GameObject tileViewPrefab;
	[SerializeField] GameObject SelectionIndicatorPrefab;
	[SerializeField] const int  widthMax = 16;
	[SerializeField] const int depthMax = 16;
	[SerializeField] const int heightMax = 10;
	[SerializeField] Point pos;
	[SerializeField] LevelData ld;
	Dictionary<Point, Tile> tiles = new Dictionary<Point, Tile>();

	Transform _marker;
	Transform marker
	{
		get
		{
			if (_marker == null)
			{
				GameObject instance = Instantiate(SelectionIndicatorPrefab) as GameObject;
				_marker = instance.transform;
			}
			return _marker;
		}
	}

	public void GrowArea ()
	{
		Rect r = RandomRect();
		GrowRect(r);
	}
	public void ShrinkArea ()
	{
		Rect r = RandomRect();
		ShrinkRect(r);
	}

	//Generates a rectangle of random size within the legal area
	private Rect RandomRect ()
	{
		int x = UnityEngine.Random.Range(0, widthMax);
		int y = UnityEngine.Random.Range(0, depthMax);
		int w = UnityEngine.Random.Range(1, widthMax - x + 1);
		int h = UnityEngine.Random.Range(1, depthMax - y + 1);
		return new Rect(x, y, w, h);
	}

	public void GrowRect (Rect rect)
	{
		for (int y = (int)rect.yMin; y < (int)rect.yMax; ++y)
		{
			for (int x = (int)rect.xMin; x < (int)rect.xMax; ++x)
			{
				Point p = new Point(x, y);
				GrowSingle(p);
			}
		}
	}

	public void ShrinkRect (Rect rect)
	{
		for (int y = (int)rect.yMin; y < (int)rect.yMax; ++y)
		{
			for (int x = (int)rect.xMin; x < (int)rect.xMax; ++x)
			{
				Point p = new Point(x, y);
				ShrinkSingle(p);
			}
		}
	}

	public void ShrinkSingle()
	{
		ShrinkSingle(pos);
	}
	public void ShrinkSingle(Point p)
	{
		if(!tiles.ContainsKey(p))
			return;
		Tile t = tiles[p];

		if(t.height <= 1)
		{
			tiles.Remove(p);
			DestroyImmediate(t.gameObject);
			return;
		}

		t.Shrink();
	}

	public void GrowSingle()
	{
		GrowSingle(pos);
	}
	void GrowSingle (Point p)
	{
		Tile t = GetOrCreate(p);
		if (t.height < heightMax)
			t.Grow();
	}

	Tile GetOrCreate (Point p)
	{
		if (tiles.ContainsKey(p))
			return tiles[p];
		
		Tile t = Create();
		t.Load(p, 0);
		tiles.Add(p, t);
		
		return t;
	}

	Tile Create ()
	{
		GameObject instance = Instantiate(tileViewPrefab) as GameObject;
		instance.transform.parent = transform;
		return instance.GetComponent<Tile>();
	}

	public void UpdateMarker()
	{
		Tile t = tiles.ContainsKey(pos) ? tiles[pos] : null;
		marker.localPosition = t != null ? t.center : new Vector3(pos.x, 0, pos.y);
	}

	public void Clear()
	{
  		for (int i = transform.childCount - 1; i >= 0; i--)
    		DestroyImmediate(transform.GetChild(i).gameObject);
  		tiles.Clear();
	}

	public void Save ()
	{
  		string filePath = Application.dataPath + "/Resources/Levels";
  		if (!Directory.Exists(filePath))
    		CreateSaveDirectory();
  
  		LevelData board = ScriptableObject.CreateInstance<LevelData>();
  		board.tiles = new List<Vector3>( tiles.Count );
  		foreach (Tile t in tiles.Values)
    		board.tiles.Add( new Vector3(t.pos.x, t.height, t.pos.y) );
  
  		string fileName = string.Format("Assets/Resources/Levels/{1}.asset", filePath, name);
  		AssetDatabase.CreateAsset(board, fileName);
	}
	void CreateSaveDirectory ()
	{
		string filePath = Application.dataPath + "/Resources";
		if (!Directory.Exists(filePath))
			AssetDatabase.CreateFolder("Assets", "Resources");
		filePath += "/Levels";
		if (!Directory.Exists(filePath))
			AssetDatabase.CreateFolder("Assets/Resources", "Levels");
		AssetDatabase.Refresh();
	}

	public void Load ()
	{
		Clear();
		if (ld == null)
			return;
		foreach (Vector3 v in ld.tiles)
		{
			Tile t = Create();
			t.Load(v);
			tiles.Add(t.pos, t);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
