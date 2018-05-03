using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDamage : ABuff
{

	public DoubleDamage ()
	{
		Name = "DoubleDamage";
	
	}

	public override void SetBuff (Player player)
	{
		Debug.Log ("DoubleDamage::Name");

	}

	public override void RemoveBuff (Player player)
	{
		Debug.Log ("DOubleDamage::BuffOff");
	}

	//	protected override void GetBuff (playerControl player)
	//	{
	//
	//	}

}
