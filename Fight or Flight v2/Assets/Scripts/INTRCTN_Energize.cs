using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INTRCTN_Energize : MonoBehaviour {

	Card card;
	UI_CardPanel panel;
	UI_CardLoader loader;
	UI_MeterManager hud ;

	void Start(){
		GameObject gameManager = GameObject.FindGameObjectWithTag ("GameManager");
		GameObject cardManager = GameObject.FindGameObjectWithTag ("CardManager");

		hud = gameManager.GetComponent<UI_MeterManager> ();
		panel = GetComponentInParent<UI_CardPanel> ();
		loader = cardManager.GetComponent<UI_CardLoader> ();

	}

	public void Energize(){
		int n = UI_CardPanel.slotNum - 1;
		card = UI_CardLoader.slots[n].GetComponentInChildren<Card> ();

		float amount = card.energyValue;

		if (GameManager.energy + amount <= GameManager.maxEnergy) {
			GameManager.energy = GameManager.energy + amount;

			loader.DeactivateCard (card.gameObject,true);
//			Destroy (card.gameObject);

			panel.DisablePanel ();
		} else {
			if (GameManager.energy < GameManager.maxEnergy) {
				
				GameManager.energy = GameManager.energy + (GameManager.maxEnergy - GameManager.energy);
				loader.DeactivateCard (card.gameObject,true);
//				Destroy (card.gameObject);
				panel.DisablePanel ();
			} else {
				Debug.Log ("Energy is Full");
			}

		}

	}

	public void EnergizePanelInfo(){
		int n = UI_CardPanel.slotNum - 1;
		card = UI_CardLoader.slots[n].GetComponentInChildren<Card> ();

		Sprite sprite = card.energize;

		panel.SetPanelImage (sprite);
	}



}
