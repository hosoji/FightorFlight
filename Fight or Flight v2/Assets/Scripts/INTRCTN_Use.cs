using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INTRCTN_Use : MonoBehaviour {

	Card card;
	UI_CardPanel panel;
	UI_MeterManager hud ;

	void Start(){
		GameObject gameManager = GameObject.FindGameObjectWithTag ("GameManager");

		hud = gameManager.GetComponent<UI_MeterManager> ();
		panel = GetComponentInParent<UI_CardPanel> ();


	}

	public void Use(){
		int n = UI_CardPanel.slotNum - 1;
		card = UI_CardLoader.slots[n].GetComponentInChildren<Card> ();

		int amount = card.useCost;

		if (GameManager.composure - amount > 0) {
			card.AccessAbility ();

			if (PlayerController.actionSuccessful) {
				hud.RemoveSegment (amount);

				panel.DisablePanel ();
				PlayerController.actionSuccessful = false;
			}

		} else {

			print ("Not Enough Composure");

		}

	}

	public void UsePanelInfo(){
		int n = UI_CardPanel.slotNum - 1;
		card = UI_CardLoader.slots[n].GetComponentInChildren<Card> ();

		Sprite sprite = card.use;

		panel.SetPanelImage (sprite);
	}
}
