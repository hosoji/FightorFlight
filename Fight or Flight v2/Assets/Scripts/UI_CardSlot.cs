using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CardSlot : MonoBehaviour {

	UI_CardPanel panel;
	public GameObject infoPanel;

	// Use this for initialization
	void Start () {
		panel = infoPanel.GetComponent<UI_CardPanel> ();	
	}


	public void GetCardInfo(){
		Card card = GetComponentInChildren<Card> ();
		if (card != null) {
			Debug.Log ("Card Name is: " + card.gameObject.name);
			infoPanel.SetActive (true);

			panel.SetPanelImage (card.use);

			switch (card.myCardType) {
				case Card.CardType.ACTION_CARD:
					panel.EnableCarry (true);
					panel.EnableUse (true);
					panel.EnableDiscard (true);
					panel.EnableEnergize (true);
					break;

				case Card.CardType.CONSUMABLE_CARD:
					panel.EnableCarry (false);
					panel.EnableUse (true);
					panel.EnableDiscard (true);
					panel.EnableEnergize (false);
					break;

				case Card.CardType.BLANK_CARD:
					panel.EnableCarry (false);
					panel.EnableUse (false);
					panel.EnableDiscard (false);
					panel.EnableEnergize (false);
					break;

				case Card.CardType.POSSESSION_CARD:
					panel.EnableCarry (true);
					panel.EnableUse (false);
					panel.EnableDiscard (true);
					panel.EnableEnergize (false);
					break;

			}
				

		} else {
			Debug.Log ("No Card Selected");
			infoPanel.SetActive (false);
		}
	}

}
