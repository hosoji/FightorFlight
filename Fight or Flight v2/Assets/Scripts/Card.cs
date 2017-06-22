using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour {


	Image cardImage;

	public Sprite use, discard, energize, carry;

	GameObject gameManager;

	UI_MeterManager hud;
	
	protected float energy = GameManager.energy;

	protected int composure = GameManager.composure;

	public int discardValue;
	public float energyValue;
	public int useCost;
	public int equipCost;

	public int slotSize;

	public Sprite sprite1, sprite2;

	public enum SlotState{
		CARD_SLOT,
		EQUIP_SLOT,
	}

	public SlotState mySlotState;

	void Start(){
		SetUp ();

	}

	protected virtual void SetUp(){

		mySlotState = SlotState.CARD_SLOT;



		gameManager = GameObject.Find ("GameManager");

		hud = gameManager.GetComponent<UI_MeterManager> ();

		cardImage = GetComponent<Image> ();

	}

	protected virtual void Update(){
		RectTransform rectTransform = GetComponent<RectTransform> ();

		float w = 184f;
		float h = 56f;

		// For getting UI object to parent's position 
		if (rectTransform != null) {
			UtilScript.AlignRectTransformToParent (rectTransform);
		}

		if (mySlotState == SlotState.CARD_SLOT) {
			cardImage.sprite = sprite1;
		} else {
			cardImage.sprite = sprite2;
			rectTransform.sizeDelta = new Vector2(w,h);
		}
	}

//	protected virtual void OnMouseOver(){

//	}

	public void AccessAbility(){
		CardAbility ();
	}

	protected virtual void CardAbility(){
	}

}
