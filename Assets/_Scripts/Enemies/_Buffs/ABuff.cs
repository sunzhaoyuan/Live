using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ABuff
{

	public string Name;

	public abstract void SetBuff (playerControl player);

	public abstract void RemoveBuff (playerControl player);

	//	protected abstract void GetBuff (playerControl player);
}
