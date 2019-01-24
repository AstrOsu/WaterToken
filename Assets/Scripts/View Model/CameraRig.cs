using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour 
{
	public float speed = 3f;
	public Transform follow;
	Transform trans;
	
	void Awake ()
	{
		trans = transform;
	}
	
	void Update ()
	{
		if (follow)
			trans.position = Vector3.Lerp(trans.position, follow.position, speed * Time.deltaTime);
	}
}
