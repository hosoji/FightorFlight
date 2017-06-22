using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INTRCTN_Discard : MonoBehaviour {

	Card card;
	UI_CardPanel panel;
	UI_MeterManager mm ;
	UI_EnergyManager em;

	void Start(){
		GameObject gameManager = GameObject.FindGameObjectWithTag ("GameManager");

		panel = GetComponentInParent<UI_CardPanel> ();
		mm = gameManager.GetComponent<UI_MeterManager> ();
		em = gameManager.GetComponent<UI_EnergyManager> ();

	}

	public void Discard(){
		int n = UI_CardPanel.slotNum - 1;
		card = UI_CardLoader.slots[n].GetComponentInChildren<Card> ();

		int amount = card.discardValue;

		if (GameManager.composure + amount <= GameManager.maxValue) {
			mm.AddSegment (amount);
//			em.RemoveSegment (amount);

			Destroy (card.gameObject);

			panel.DisablePanel ();

		} else {
			if (GameManager.composure < GameManager.maxValue) {
				mm.AddSegment (GameManager.maxValue - GameManager.composure);
//				em.RemoveSegment (GameManager.maxValue - GameManager.composure);

				Destroy (card.gameObject);

				panel.DisablePanel ();

			} else {
				print ("Composure full");
			}

		}


	}

	public void DiscardPanelInfo(){
		int n = UI_CardPanel.slotNum - 1;
		card = UI_CardLoader.slots[n].GetComponentInChildren<Card> ();

		Sprite sprite = card.discard;

		panel.SetPanelImage (sprite);
	}

}
