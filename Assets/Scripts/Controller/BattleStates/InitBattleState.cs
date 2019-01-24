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
		SpawnTestUnits(false);
		SpawnTestUnits(true);
		yield return null;
		owner.ChangeState<MoveTargetState>();
	}

	void SpawnTestUnits (bool isGood)
	{
		int x = 0;
		if(!isGood)
			x = 13;

		for (int i = 0; i < 3; ++i)
		{
			GameObject theDude = isGood ? Instantiate(owner.heroPrefab) as GameObject : Instantiate(owner.villianPrefab) as GameObject;
			Point p = new Point((int)levelData.tiles[i + x].x, (int)levelData.tiles[i + (x*17)].z);
			Unit unit = theDude.GetComponent<Unit>();
			unit.Place(board.GetTile(p));
			unit.Match();
			Movement m = theDude.AddComponent(typeof(Walk)) as Movement;
			m.range = 7 - i;
			m.jumpHeight = 2 + i;
			owner.currentUnit = theDude.GetComponent<Unit>();
			unit.isGood = isGood;
			units.Add(unit);
		}
	}
}