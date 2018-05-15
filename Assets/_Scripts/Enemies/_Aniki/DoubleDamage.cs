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
        player.Buff = this;
	}

	public override void RemoveBuff (Player player)
	{
        player.Buff = new EmptyBuff();
	}
}
