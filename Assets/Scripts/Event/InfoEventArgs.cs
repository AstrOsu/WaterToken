using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
public class InfoEventArgs<T> : EventArgs 
{
	public T data;
  
	public InfoEventArgs() 
	{
		data = default(T);
	}
  
	public InfoEventArgs (T incoming)
	{
		this.data = incoming;
	}
}