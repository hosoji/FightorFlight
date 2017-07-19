using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CARD_Inhaler : Card {

	const CardType type = CardType.POSSESSION_CARD;

	public float modValue;


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
		GetCardEffect ();
	}

	void GetCardEffect(){
		GameManager.meterMod = GameManager.GetMeterMod (modValue);
	}


}
