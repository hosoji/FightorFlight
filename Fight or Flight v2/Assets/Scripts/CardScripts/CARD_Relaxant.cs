using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CARD_Relaxant : Card {

	const CardType type = CardType.CONSUMABLE_CARD;

	public int rechargeAmount = 18;


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

		if (GameManager.composure + rechargeAmount <= GameManager.maxValue) {
			hud.AddSegment (rechargeAmount);
			PlayerController.actionSuccessful = true;


		} else {
			if (GameManager.composure < GameManager.maxValue) {
				hud.AddSegment (GameManager.maxValue - GameManager.composure);
				PlayerController.actionSuccessful = true;


			} else {
				print ("Composure full");
				PlayerController.actionSuccessful = false;
			}

		}

	}

}
