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
		if (GUILayout.Button("Copy"))
			inUse.Copy();
		if (GUILayout.Button("Deault Grid"))
			inUse.GrowRect(new Rect(0f, 0f, 24f, 24f));
		if (GUILayout.Button("Specific grid"))
			inUse.GrowARect();
		if (GUILayout.Button("Grow"))
			inUse.GrowSingle();
		if (GUILayout.Button("Shrink"))
			inUse.ShrinkSingle();
		if (GUILayout.Button("Grow Area"))
			inUse.GrowArea();
		if (GUILayout.Button("Shrink Area"))
			inUse.ShrinkArea();
		if (GUILayout.Button("Add to Ps"))
			{
				for (int y = (int)inUse.rec.yMin; y <= (int)inUse.rec.yMax; ++y)
				{
					for (int x = (int)inUse.rec.xMin; x <= (int)inUse.rec.xMax; ++x)
					{
						inUse.ps.Add(new Point(x,y));
					}
				}
			}
		if (GUILayout.Button("Clear Ps"))
			inUse.ps.Clear();
		if (GUILayout.Button("Grow Ps"))
			inUse.GrowPs();
		if (GUILayout.Button("Shrink Ps"))
			inUse.ShrinkPs();
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
