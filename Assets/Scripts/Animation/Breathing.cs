using UnityEngine;
using System.Collections;
 
 public class Breathing : MonoBehaviour {
 
     public float delta = 1.5f;  // Amount to move left and right from the start point
     public float speed = 2.0f; 
     private Vector3 pos
	 {
		 get
		 {
			return transform.position;
		 }
	 }
 
     void Start () {
        //pos = transform.position;
     }
     
     void Update () {
         Vector3 v = pos;
         v.x += delta * Mathf.Sin (Time.time * speed);
         transform.position = v;
     }
 }