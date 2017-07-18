using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CARD_Blank : Card {

	const CardType type = CardType.BLANK_CARD;


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

	}



}
