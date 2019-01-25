using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : Turn 
{
	protected BattleController owner;
	protected virtual void Awake ()
	{
		owner = GetComponent<BattleController>();
	}
	void SpawnUnits (bool isGood)
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
			unit.Place(owner.board.GetTile(p));
			unit.Match();
			Movement m = theDude.AddComponent(typeof(Walk)) as Movement;
			m.range = 12 - i;
			m.jumpHeight = 4 + (2*i);
			unit.isGood = isGood;
			owner.units.Add(unit);
		}
	}
}
