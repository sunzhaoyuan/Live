using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyBuff : ABuff
{

	public EmptyBuff ()
	{
		Name = "EmptyBuff";
	}

	public override void SetBuff (playerControl player)
	{
	}

	public override void RemoveBuff (playerControl player)
	{
	}

	//	protected abstract void GetBuff (playerControl player);
}