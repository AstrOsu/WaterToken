using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour 
{
	public float speed = 3f;
	public Transform follow;
	public Transform header;
	Transform trans;
	
	
	void Awake ()
	{
		trans = transform;
		AddListeners();
	}
	protected void AddListeners ()
	{
		InputControler.scroll += OnScroll;
	}
	
	protected void RemoveListeners ()
	{
		InputControler.scroll -= OnScroll;
	}
	protected void OnDestroy ()
	{	RemoveListeners();	}

	protected virtual void OnScroll (object sender, InfoEventArgs<Point> e)
	{	
		if(e.data.x != 0)
			header.transform.Rotate(0, -e.data.x * speed / 2, 0, Space.World);
		if(e.data.y != 0)
			Camera.main.orthographicSize -= (float)e.data.y * .5f;
		//Debug.Log(Camera.main.orthographicSize + "  " + i);
	}
	
	void Update ()
	{
		if (follow)
			trans.position = Vector3.Lerp(trans.position, follow.position, speed * Time.deltaTime);			
	}
}
