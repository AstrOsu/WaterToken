using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    public const float step = .25f;
    public Point pos;
    public int height;
    public GameObject content;
	public int moveCost = 1;
    [HideInInspector] public Tile prev;

    [HideInInspector] public int distance;

    public Vector3 center { get { return new Vector3(pos.x, height * step, pos.y); }}

    public void Grow ()
    {
        height++;
        Update();
    }
    public void Grow (int h)
    {
        height += h;
        Update();
    }
    public void Shrink ()
    {
        height--;
        Update();
    }
    public void Shrink (int h)
    {
        height -= h;
        Update();
    }
    
    public void Load (Point p, int h)
    {
        pos = p;
        height = h;
        Update();
    }
    public void Load (Vector3 v)
    {
        Load(new Point((int)v.x, (int)v.z), (int)v.y);
    }

    private void Update ()
    {
        transform.localPosition = new Vector3( pos.x, height * step / 2f, pos.y );
        transform.localScale = new Vector3(1, height * step, 1);
    }
}
