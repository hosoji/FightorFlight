using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour {


	Image cardImage;

	public Sprite use, discard, energize, carry;

	protected GameObject gameManager;
	protected GameObject cardManager;


	RectTransform rectTransform;

	protected UI_MeterManager hud;



	protected UI_CardLoader loader;
	
	protected float energy = GameManager.energy;

	protected int composure = GameManager.composure;

	public int discardValue;
	public float energyValue;
	public int useCost;
	public int equipCost;

	public Sprite cardSprite, equipSprite;

	public enum SlotState{
		CARD_SLOT,
		EQUIP_SLOT,
	}

	public enum CardType{
		ACTION_CARD,
		CONSUMABLE_CARD,
		POSSESSION_CARD,
		BLANK_CARD,
		PANIC_CARD,
	}

	public SlotState mySlotState;

	public CardType myCardType;


	void Awake(){
		SetUp ();

	}

	protected virtual void SetUp(){

		mySlotState = SlotState.CARD_SLOT;
		rectTransform = GetComponent<RectTransform> ();

		cardManager = GameObject.FindGameObjectWithTag ("CardManager");

		gameManager = GameObject.FindGameObjectWithTag ("GameManager");


		hud = gameManager.GetComponent<UI_MeterManager> ();

		loader = cardManager.GetComponent<UI_CardLoader> ();

		cardImage = GetComponent<Image> ();



	}

	protected virtual void Update(){

		float w = 184f;
		float h = 56f;

		if (mySlotState == SlotState.CARD_SLOT) {
			cardImage.sprite = cardSprite;
		} else {
			cardImage.sprite = equipSprite;
			rectTransform.sizeDelta = new Vector2(w,h);
		}
	}
		

	public void AccessAbility(){
		CardAbility ();
	}
		

	protected virtual void CardAbility(){
	}


}
