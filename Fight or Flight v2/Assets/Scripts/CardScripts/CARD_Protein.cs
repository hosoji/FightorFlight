using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CARD_Protein : Card {

	const CardType type = CardType.CONSUMABLE_CARD;

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

		int n = UI_CardPanel.slotNum - 1;

		if (GameManager.energy + energyValue <= GameManager.maxEnergy) {
			GameManager.energy = GameManager.energy + energyValue;
			PlayerController.actionSuccessful = true;

		} else {
			if (GameManager.energy < GameManager.maxEnergy) {

				GameManager.energy = GameManager.energy + (GameManager.maxEnergy - GameManager.energy);
				PlayerController.actionSuccessful = true;

			} else {
				Debug.Log ("Energy is Full");
				PlayerController.actionSuccessful = false;
			}

		}

	}

}
