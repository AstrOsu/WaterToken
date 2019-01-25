using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : StateMachine 
{
	public CameraRig cameraRig;
	public Board board;
	public LevelData levelData;
	public Transform SelectionIndicator;
	public Point pos;
	public GameObject heroPrefab;
	public GameObject villianPrefab;
	public Unit currentUnit;
	public Tile currentTile { get { return board.GetTile(pos); }}	
	public TurnController tc;
	//public Turn turn = new Turn();
	public List<Unit> units = new List<Unit>();
	//public List<Unit> badUnits = new List<Unit>();

	void Start ()
	{
		ChangeState<InitBattleState>();
	}
}