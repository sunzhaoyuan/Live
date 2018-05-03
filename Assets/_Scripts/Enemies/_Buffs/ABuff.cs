using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ABuff
{

	public string Name;

	public abstract void SetBuff (Player player);

	public abstract void RemoveBuff (Player player);

	//	protected abstract void GetBuff (playerControl player);
}
