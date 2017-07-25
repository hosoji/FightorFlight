using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_EquipSlot : MonoBehaviour {

	Card card;

	UI_MeterManager hud ;
	GameObject gameManager;
	GameObject cardManager;

	bool coolDown = false;
	float amountcoolDown = 0f;
	void Start(){
		gameManager = GameObject.FindGameObjectWithTag ("GameManager");
		cardManager = GameObject.FindGameObjectWithTag ("CardManager");

		hud = gameManager.GetComponent<UI_MeterManager> ();


	}

	void Update(){


		


		if (coolDown) {
			
			if (card != null){

				card = GetComponentInChildren<Card> ();
				Image image = card.GetComponent<Image> (); 
				image.fillMethod = Image.FillMethod.Horizontal;
//				image.fillMethod =  Image.OriginHorizontal.Left;

				amountcoolDown = amountcoolDown + Time.deltaTime; 
				float newCoolDownTime = Mathf.Clamp01(UtilScript.remapRange (amountcoolDown, 0, GameManager.cooldownTime, 0,1 ));


				image.fillAmount = newCoolDownTime;
			}
		}
		
		
	}

	public bool SlotAvailable(){
		Card info = GetComponentInChildren<Card> ();

		if (info != null) {
			return false;
		} else {
			return true;
		}
	}

	public void RemoveCardfromSlot(){

		card = GetComponentInChildren<Card> ();
		if (card != null) {
			UI_CardLoader loader = cardManager.GetComponent<UI_CardLoader> ();

			card.mySlotState = Card.SlotState.CARD_SLOT;
			loader.DeactivateCard (card.gameObject, true);

		}
		
	}

	public void ActivateSlotFunction(){
		card = GetComponentInChildren<Card> ();
		if (card != null && !coolDown) {
			Debug.Log ("Card Name is: " + card.gameObject.name);

			if (card.myCardType == Card.CardType.ACTION_CARD) {
				int amount = card.useCost;

				if (GameManager.composure - amount > 0) {
					card.AccessAbility ();

					if (PlayerController.actionSuccessful) {
						hud.RemoveSegment (amount);
						StartCoroutine (Cooldown ());


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

	IEnumerator Cooldown(){
		
		coolDown = true;
		yield return new WaitForSeconds (GameManager.cooldownTime);
		coolDown = false;
		amountcoolDown = 0f;
		
	}

}
