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
		//SelectTile(new Point(10,10));
		//SelectionIndicator.localPosition = board.tiles[new Point(10,10)].center;
		//Debug.Log("test");
		//Debug.Log(string.Format ("({0},{1})", levelData.tiles[0], levelData.tiles));
		SpawnTestUnits(false);
		SpawnTestUnits(true);
		yield return null;
		owner.ChangeState<UnitState>();
	}

	void SpawnTestUnits (bool isGood)
	{
		int x = 0;
		if(!isGood)
			x = 12;

		for (int i = 0; i < 3; ++i)
		{
			GameObject theDude = isGood ? Instantiate(owner.heroPrefab) as GameObject : Instantiate(owner.villianPrefab) as GameObject;
			theDude.transform.parent = owner.transform;
			Point p = new Point(11+i, i + x);
			Unit unit = theDude.GetComponent<Unit>();
			unit.Place(board.GetTile(p));
			unit.Match();
			Movement m = theDude.AddComponent(typeof(Walk)) as Movement;
			m.range = 12 - i;
			m.jumpHeight = 4 + (2*i);
			unit.isGood = isGood;

			AbilityRange a1;
			if(isGood)
				a1 = theDude.AddComponent(typeof(MeleeRange)) as AbilityRange;
			else
				a1 = theDude.AddComponent(typeof(MeleeReach)) as AbilityRange;
			unit.attackRange1 = a1;

			a1 = theDude.AddComponent(typeof(InfiniteRange)) as AbilityRange;
			unit.attackRange2 = a1;
			units.Add(unit);
		}
	}
}