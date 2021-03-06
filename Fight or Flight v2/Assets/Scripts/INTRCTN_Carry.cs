﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class INTRCTN_Carry : MonoBehaviour {
	
	Card card;
	UI_CardPanel panel;
	UI_CardLoader loader;
	UI_MeterManager hud ;

	void Start(){
		
		GameObject gameManager = GameObject.FindGameObjectWithTag ("GameManager");
		GameObject cardManager = GameObject.FindGameObjectWithTag ("CardManager");

		loader = cardManager.GetComponent<UI_CardLoader> ();
		hud = gameManager.GetComponent<UI_MeterManager> ();
		panel = GetComponentInParent<UI_CardPanel> ();


	}

	public void Carry(){

		int amount = card.equipCost;

		int n = UI_CardPanel.slotNum - 1;
		card = UI_CardLoader.slots [n].GetComponentInChildren<Card> ();

		GameObject[] equipSlots = GameObject.FindGameObjectsWithTag ("EquipSlot");


		for (int i = equipSlots.Length; i > 0; i--) {
			UI_EquipSlot slot = equipSlots [equipSlots.Length - i].GetComponent<UI_EquipSlot> ();

			if (slot.SlotAvailable ()) {
				
				if (GameManager.composure - amount > 0) {
					hud.RemoveSegment (amount);

					loader.AddtoCarry (card.gameObject);

					card.gameObject.transform.SetParent (equipSlots [equipSlots.Length - i].transform, false);

					card.mySlotState = Card.SlotState.EQUIP_SLOT;
				} else {
					print ("Not enough composure");
				}

				panel.DisablePanel ();
				break;
			}
	
		}

		if (card.myCardType == Card.CardType.POSSESSION_CARD) {
			card.AccessAbility ();
		}
	}

	public void CarryPanelInfo(){
		int n = UI_CardPanel.slotNum - 1;
		card = UI_CardLoader.slots[n].GetComponentInChildren<Card> ();

		Sprite sprite = card.carry;

		panel.SetPanelImage (sprite);
	}


	public void CheckCardType(){


		if (card.myCardType == Card.CardType.ACTION_CARD) {
			this.gameObject.SetActive (true);
		} else if (card.myCardType == Card.CardType.CONSUMABLE_CARD) {
			this.gameObject.SetActive (false);
		} else if (card.myCardType == Card.CardType.POSSESSION_CARD) {
			this.gameObject.SetActive (true);
		} else if (card.myCardType == Card.CardType.BLANK_CARD) {
			this.gameObject.SetActive (false);
		} else {
			this.gameObject.SetActive(false);
		}	


	}


}
