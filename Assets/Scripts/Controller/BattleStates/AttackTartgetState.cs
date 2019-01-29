using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTargetState : BattleState 
{
	List<Tile> tiles;
	public override void Enter ()
	{
		base.Enter ();
		
		AbilityRange ar = owner.currentUnit.GetComponent<AbilityRange>();
		tiles = ar.GetTilesInRange(board);
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

		else if(e.data == 2) {}
			//insert voiceline
		
		//else if(tiles.Contains(owner.currentTile))
		//	owner.ChangeState<MoveSequenceState>();
	}
}