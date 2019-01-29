using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteRange : AbilityRange 
{
	public override List<Tile> GetTilesInRange (Board board)
	{
		return new List<Tile>(board.tiles.Values);
	}

	public override void Attack(List<Tile> tiles, Unit target)
	{
		Debug.Log("Entering");
		Tile from = tiles[0], to = tiles[1];
		Unit u = GetComponentInParent<Unit>();//from.gameObject.GetComponent<Unit>();
		//Unit target = to.gameObject.GetComponent<Unit>();

		Vector3 offset; //= new Vector3(0,2,0);

		//StartCoroutine(WalkTo(from.center + offset));
		//u.transform.localPosition = to.center + offset;


		switch (target.dir)
		{
			case Directions.North:
				offset = new Vector3(0,0,1);
				break;
			case Directions.South:
				offset = new Vector3(0,0,1);
				break;
			case Directions.East:
				offset = new Vector3(1,0,0);
				break;
			case Directions.West:
				offset = new Vector3(-1,0,0);
				break;
			default:
				offset = new Vector3(0,0,0);
				break;
		}
		StartCoroutine(WalkTo(from.center, to.center + offset));
	}

	IEnumerator WalkTo (Vector3 from, Vector3 target)
	{
		Debug.Log("ok it's here");
		Tweener tweener = transform.MoveTo(from + new Vector3(0,3,0), 2f, EasingEquations.Linear);
		while (tweener != null)
			yield return null;

		tweener = transform.MoveTo(target + new Vector3(0,3,0), 3f, EasingEquations.Linear);
		while (tweener != null)
			yield return null;

		tweener = transform.MoveTo(target, 5f, EasingEquations.Linear);
		while (tweener != null)
			yield return null;
	}
}