using UnityEngine;
using System.Collections;
 
public class Breathing : MonoBehaviour {
 
    public float delta = .1f;  // Amount to move left and right from the start point
    public float speed = 2.0f; 
    public int direction;
    private Vector3 pos;
    private Vector3 scale;

    void Start () 
    {
        scale = transform.localScale;
        pos = transform.position;
    }
     
    void Update () 
    { 
        Vector3 v = pos, s = scale;
        switch (direction)
        {
            case 0:
                v.x += delta * Mathf.Sin (Time.time * speed);
                break;
            case 1:
                v.x -= delta * Mathf.Sin (Time.time * speed);
                break;            
            case 2:
                v.z += delta * Mathf.Sin (Time.time * speed);
                break;
            case 3:
                v.z -= delta * Mathf.Sin (Time.time * speed);
                break;
        }
        //v.x += delta * Mathf.Sin (Time.time * speed);
        transform.position = v;
        s.z += 2 * delta * Mathf.Sin (Time.time * speed);
        transform.localScale = s;
    }

}