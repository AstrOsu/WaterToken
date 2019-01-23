using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchEvents : MonoBehaviour 
{

	void OnEnable ()
	{
		InputControler.move += OnMoveEvent;
		InputControler.click += OnClickEvent;
	}
	void OnDisable ()
	{
		InputControler.move -= OnMoveEvent;
		InputControler.click -= OnClickEvent;
	}

	void OnMoveEvent (object sender, InfoEventArgs<Point> e)
	{
		Debug.Log("Move: " + e.data.ToString());
		
  		//throw new System.NotImplementedException ();
	}
	void OnClickEvent (object sender, InfoEventArgs<int> e)
	{
		Debug.Log("Click: " + e.data.ToString());
  		//throw new System.NotImplementedException ();
	}

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {
		
	}
}
