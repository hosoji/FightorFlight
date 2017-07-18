using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CARD_ClimbOver : Card {

	const CardType type = CardType.ACTION_CARD;


	void Start () {
		SetUp ();
	}

	protected override void SetUp (){
		base.SetUp ();
	}

	protected override void Update (){
		base.Update ();
	}

	protected override void CardAbility (){
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		PlayerController control = player.GetComponent<PlayerController> ();

		control.MoveMultipleUnits (2);
	}



}
