using System.Collections;
using System;
using UnityEngine;



public class InputControler : MonoBehaviour 
{
	public static event EventHandler<InfoEventArgs<Point>> move;
	public static event EventHandler<InfoEventArgs<Point>> scroll;  //Currently only used in Camera 
	public static event EventHandler<InfoEventArgs<int>> click;
	public static event EventHandler<InfoEventArgs<int>> key;
	Repeater h = new Repeater("Horizontal"), v = new Repeater("Vertical");

	//accept, back, and menu/pause
	string[] clicks = new string[] {"Fire1", "Fire2", "Fire3"};
	string[] keys = new string[] {"Fire4", "Fire5", "Fire6"};

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Debug.Log(Input.GetAxis("Camera Rotate"));
		int x = h.Update(), i;
		int y = v.Update();
		if (x != 0 || y != 0)
  		{
    		if (move != null)
      			move(this, new InfoEventArgs<Point>(new Point(x, y)));
  		}
		//Debug.Log(Input.GetAxisRaw("Horizontal"));
		for (i = 0; i < 3; i++)
		{
			if (Input.GetButtonUp(clicks[i]))
			{
				if (click != null)
					click(this, new InfoEventArgs<int>(i));
			}
		}

		if(key != null)
			for (i = 0; i < 3; i++)
				if (Input.GetButtonUp(keys[i]))
					key(this, new InfoEventArgs<int>(i));
		
		if(scroll != null)
		{
			i = (int)(Input.GetAxis("Camera Rotate"));
			int i2 = (int)(Input.GetAxis("Mouse ScrollWheel"));
			if(i != 0 || i2 != 0)
				scroll(this, new InfoEventArgs<Point>(new Point(i, i2)));
		}
	}
}

//Allows for long presses of the movement keys
class Repeater
{
	const float threshold = 0.4f;
	const float rate = 0.25f;
	float next;
	bool held;
	string axis;
	public Repeater (string axisName)
	{
		axis = axisName;
	}
	public int Update ()
	{
		int retValue = 0;
		int value = Mathf.RoundToInt( Input.GetAxisRaw(axis) );
		if (value != 0)
		{
			if (Time.time > next)
			{
				retValue = value;
				next = Time.time + (held ? rate : threshold);
				held = true;
			}
		}
		else
		{
			held = false;
			next = 0;
		}
		return retValue;
	}
}
