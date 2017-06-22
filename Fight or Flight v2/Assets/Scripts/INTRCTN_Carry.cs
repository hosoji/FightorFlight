using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class INTRCTN_Carry : MonoBehaviour {
	
	Card card;
	UI_CardPanel panel;
	UI_MeterManager hud ;

	void Start(){
		
		GameObject gameManager = GameObject.FindGameObjectWithTag ("GameManager");


		hud = gameManager.GetComponent<UI_MeterManager> ();
		panel = GetComponentInParent<UI_CardPanel> ();


	}

	public void Carry(){



		int amount = card.equipCost;

		int slotSize = card.slotSize;

		int n = UI_CardPanel.slotNum - 1;
		card = UI_CardLoader.slots [n].GetComponentInChildren<Card> ();

		GameObject[] equipSlots = GameObject.FindGameObjectsWithTag ("EquipSlot");

		for (int i = equipSlots.Length; i > 0; i--) {
			UI_EquipSlot slot = equipSlots [equipSlots.Length - i].GetComponent<UI_EquipSlot> ();

			if (slot.SlotAvailable ()) {
				
				if (GameManager.composure - amount > 0) {
					hud.RemoveSegment (amount);
				} else {
					print ("Not enough composure");
				}

				card.gameObject.transform.SetParent (equipSlots [equipSlots.Length - i].transform, false);

				card.mySlotState = Card.SlotState.EQUIP_SLOT;

				panel.DisablePanel ();
				break;
			}
					



		}
	}

	public void CarryPanelInfo(){
		int n = UI_CardPanel.slotNum - 1;
		card = UI_CardLoader.slots[n].GetComponentInChildren<Card> ();

		Sprite sprite = card.carry;

		panel.SetPanelImage (sprite);
	}

}
