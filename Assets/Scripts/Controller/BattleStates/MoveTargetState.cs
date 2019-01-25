﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTargetState : BattleState 
{
	List<Tile> tiles;
	public override void Enter ()
	{
		base.Enter ();
		
		Movement mover = owner.currentUnit.GetComponent<Movement>();
		tiles = mover.GetTilesInRange(board);
		board.SelectTiles(tiles);
	}
  
	public override void Exit ()
	{
		base.Exit ();
		board.DeSelectTiles(tiles);
		tiles = null;
	}
  
	protected override void OnMove (object sender, InfoEventArgs<Point> e)
	{
		SelectTile(e.data + pos);
	}
  
	protected override void OnClick (object sender, InfoEventArgs<int> e)
	{

		if(e.data == 1)
			owner.ChangeState<UnitState>();

		else if(e.data == 2) 
			owner.ChangeState<AbilityTargetState>();
			//insert voiceline
		
		else if(tiles.Contains(owner.currentTile))
			owner.ChangeState<MoveSequenceState>();
	}
}