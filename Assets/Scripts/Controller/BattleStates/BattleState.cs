using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleState : State 
{
	protected BattleController owner;
	public CameraRig cameraRig { get { return owner.cameraRig; }}
	public Board board { get { return owner.board; }}
	public LevelData levelData { get { return owner.levelData; }}
	public Transform SelectionIndicator { get { return owner.SelectionIndicator; }}
	public Point pos { get { return owner.pos; } set { owner.pos = value; }}
	public Turn turn { get { return owner.turn; }}
	public List<Unit> units { get { return owner.units; }}
	//public List<Unit> badUnits { get { return owner.badUnits; }}


	protected virtual void Awake ()
	{
		owner = GetComponent<BattleController>();
	}
	protected override void AddListeners ()
	{
		InputControler.move += OnMove;
		InputControler.click += OnClick;
	}
	
	protected override void RemoveListeners ()
	{
		InputControler.move -= OnMove;
		InputControler.click -= OnClick;
	}
	protected virtual void OnMove (object sender, InfoEventArgs<Point> e)
	{	}
	
	protected virtual void OnClick (object sender, InfoEventArgs<int> e)
	{	}

	protected virtual void SelectTile (Point p)
	{
		if (pos == p || !board.tiles.ContainsKey(p))
			return;
		pos = p;
		SelectionIndicator.localPosition = board.tiles[p].center;
	}
}
