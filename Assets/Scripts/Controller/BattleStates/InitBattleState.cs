using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitBattleState : BattleState 
{
	public override void Enter ()
	{
		base.Enter ();
		StartCoroutine(Init());
	}
	IEnumerator Init ()
	{
		board.Load( levelData );
		//Debug.Log("test");
		//Debug.Log(string.Format ("({0},{1})", levelData.tiles[0], levelData.tiles));
		Point p = new Point((int)levelData.tiles[0][0], (int)levelData.tiles[0][0]);
		SelectTile(p);
		yield return null;
		owner.ChangeState<MoveTargetState>();
	}
}