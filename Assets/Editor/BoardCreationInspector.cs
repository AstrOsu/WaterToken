using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BoardCreator))]
public class BoardCreationInspector : Editor 
{

	public BoardCreator inUse
	{
		get
		{
			return (BoardCreator)target;
		}
	}

	public override void OnInspectorGUI ()
	{
		DrawDefaultInspector();
		if (GUILayout.Button("Clear"))
			inUse.Clear();
		if (GUILayout.Button("Deault Grid"))
			inUse.GrowRect(new Rect(0f, 0f, 16f, 16f));
		if (GUILayout.Button("Grow"))
			inUse.GrowSingle();
		if (GUILayout.Button("Shrink"))
			inUse.ShrinkSingle();
		if (GUILayout.Button("Grow Area"))
			inUse.GrowArea();
		if (GUILayout.Button("Shrink Area"))
			inUse.ShrinkArea();
		if (GUILayout.Button("Save"))
			inUse.Save();
		if (GUILayout.Button("Load"))
			inUse.Load();
		if (GUILayout.Button("Update Mark"))
			inUse.UpdateMarker();	
		if (GUI.changed)		
			inUse.UpdateMarker();
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
