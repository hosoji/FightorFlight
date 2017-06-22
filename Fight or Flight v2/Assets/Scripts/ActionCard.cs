﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCard : Card {



	// Use this for initialization
	void Start () {
		base.SetUp ();
	}

	protected override void Update ()
	{
		base.Update ();
	}

	protected override void CardAbility(){

		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		PlayerController control = player.GetComponent<PlayerController> ();

		control.MoveMultipleUnits (2);

	}
}
