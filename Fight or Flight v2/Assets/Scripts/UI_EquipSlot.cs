using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_EquipSlot : MonoBehaviour {

	UI_MeterManager hud ;

	void Start(){
		GameObject gameManager = GameObject.FindGameObjectWithTag ("GameManager");

		hud = gameManager.GetComponent<UI_MeterManager> ();
	}

	public bool SlotAvailable(){
		Card info = GetComponentInChildren<Card> ();

		if (info != null) {
			return false;
		} else {
			return true;
		}
	}

	public void ActivateSlotFunction(){
		Card card = GetComponentInChildren<Card> ();
		if (card != null) {
			Debug.Log ("Card Name is: " + card.gameObject.name);

			if (card.myCardType == Card.CardType.ACTION_CARD) {
				int amount = card.useCost;

				if (GameManager.composure - amount > 0) {
					card.AccessAbility ();

					if (PlayerController.actionSuccessful) {
						hud.RemoveSegment (amount);

						PlayerController.actionSuccessful = false;
					}

				} else {

					print ("Not Enough Composure");

				}
			} else {
				Debug.Log ("Not an Action Card");
			}

		} else {
			Debug.Log ("No Card Selected");

		}

	}

}
