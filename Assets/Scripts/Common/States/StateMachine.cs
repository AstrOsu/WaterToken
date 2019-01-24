using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour 
{
	public virtual State CurrentState
	{
		get { return current; }
		set { Transition (value); }
	}
	protected State current;
	protected bool inTransition;
	public virtual T GetState<T> () where T : State
	{
		T target = GetComponent<T>();
		if (target == null)
			target = gameObject.AddComponent<T>();
		return target;
	}
	
	public virtual void ChangeState<T> () where T : State
	{
		CurrentState = GetState<T>();
	}
	protected virtual void Transition (State s)
	{
		if (current == s || inTransition)
			return;
		inTransition = true;
		
		if (current != null)
			current.Exit();
		
		current = s;
		
		if (current != null)
			current.Enter();
		
		inTransition = false;
	}
}