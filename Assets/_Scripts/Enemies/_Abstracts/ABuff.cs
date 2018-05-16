using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABuff
{

	public string Name;

    public void SetBuff(Player player)
    {
        player.Buff = this;
    }

    public void RemoveBuff(Player player)
    {
        player.Buff = new EmptyBuff();
    }

    //	protected abstract void GetBuff (playerControl player);
}
