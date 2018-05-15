using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyBuff : ABuff
{

	public EmptyBuff ()
	{
		Name = "EmptyBuff";
	}

	public override void SetBuff (Player player)
	{
	}

	public override void RemoveBuff (Player player)
	{
	}

	//	protected abstract void GetBuff (playerControl player);
}