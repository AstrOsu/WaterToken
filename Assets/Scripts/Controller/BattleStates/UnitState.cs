using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitState : BattleState 
{
	protected override void OnMove (object sender, InfoEventArgs<Point> e)
	{
		SelectTile(e.data + pos);
	}

	protected override void OnClick (object sender, InfoEventArgs<int> e)
	{
		if (e.data == 1)
			return; //Insert menu here

		GameObject content = owner.currentTile.content;
		if (content != null)
		{
			owner.currentUnit = content.GetComponent<Unit>();
			owner.ChangeState<MoveTargetState>();
		}
	}
}