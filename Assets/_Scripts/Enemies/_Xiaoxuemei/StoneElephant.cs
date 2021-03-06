﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneElephant : AEnemy
{

	// Need a field for Buff

	public StoneElephant ()
	{
		Name = "StoneElephant";
		MaxHP = 500f;
		CurrentState = State.IDLE;
		Buff = new StoneSkin ();
	}

	protected override void Awake ()
	{
		base.Awake ();
		deadAnimDuration = 1.458f;
		IsAnimator = false;
		Skills = new Dictionary<string, List<ASkill>> {
			{ "close", new List<ASkill>{ new RinoStab ()  } } 
		};
	}


}

