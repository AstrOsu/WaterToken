﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityTargetState : BattleState 
{
	List<Tile> tiles;
	Unit unit;
	AbilityRange ar;
	private int arNum = 1;

	public override void Enter ()
	{
		base.Enter ();
		unit = owner.currentUnit;
		ar = unit.attackRange1;
		SelectTiles();
		//if (ar.directionOriented)
		//RefreshSecondaryStatPanel(pos);
	}
	public override void Exit ()
	{
		base.Exit ();
		board.DeSelectTiles(tiles);
		//statPanelController.HidePrimary();
		//statPanelController.HideSecondary();
	}

	protected override void OnMove (object sender, InfoEventArgs<Point> e)
	{
		if (ar.directionOriented)
			ChangeDirection(e.data);
		else
			SelectTile(e.data + pos);
	}
	protected override void OnKey (object sender, InfoEventArgs<int> e)
	{
		if(e.data == 0)
		{	
			NextAr();
			board.DeSelectTiles(tiles);
			tiles.Clear();
			SelectTiles();
		}

		else if (e.data == 1)
			owner.ChangeState<MoveTargetState>();

	}
  
  	protected override void OnClick (object sender, InfoEventArgs<int> e)
  	{
		if (e.data == 1)
			owner.ChangeState<UnitState>();
		
		else if (e.data == 0 && tiles.Contains(owner.currentTile) && owner.currentTile.gameObject != null)
		{
			List<Tile> args = new List<Tile>{unit.tile};
			args.Add(owner.currentTile);
			//turn.hasUnitActed = true;
			//if (turn.hasUnitMoved)
			//	turn.lockMove = true;
			ar.Attack(args, owner.currentUnit);
			owner.ChangeState<UnitState>();
		}
  	}
	void ChangeDirection (Point p)
	{
		Directions dir = board.GetTile(p).GetDirection(unit.tile);
		if (unit.dir != dir)
		{
			board.DeSelectTiles(tiles);
			unit.dir = dir;
			unit.Match();
			SelectTiles();
		}
	}
	void SelectTiles ()
	{
		tiles = ar.GetTilesInRange(board);
		Debug.Log(tiles.Count);
		board.SelectTiles(tiles, 2);
	}

	void NextAr()
	{
		if(arNum == 1)
		{
			arNum = 2;
			ar = unit.attackRange2;
		}
		else
		{
			arNum = 1;
			ar = unit.attackRange1;
		}
	}
}