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
	}
	
	void Update ()
	{
		if (follow)
			trans.position = Vector3.Lerp(trans.position, follow.position, speed * Time.deltaTime);
		
		int i = (int)Input.GetAxis("Camera Rotate");
		if(i != 0)
			header.transform.Rotate(0, i*speed/2, 0, Space.World);

		i = Mathf.RoundToInt(Input.GetAxis("Mouse ScrollWheel"));
		if(i != 0)
			//Debug.Log(Camera.main.orthographicSize + "  " + i);
			Camera.main.orthographicSize -= (float)i * .5f;
	}
}
