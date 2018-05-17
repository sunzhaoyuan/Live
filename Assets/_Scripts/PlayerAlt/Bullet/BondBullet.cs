using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BondBullet : ABullet
{
    protected override void Update()
    {
        Damage = 0f;
        Speed = 100f;
    }
}
