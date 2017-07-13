using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CardLoader : MonoBehaviour {

	public static GameObject [] slots = new GameObject[3];

	GameObject[] cards = new GameObject[3];

	public int loadTime = 3;
	bool isLoading = false;

	GameObject drawnCard;

	public List <GameObject> deck = new List<GameObject>();
	public List <GameObject> hand = new List<GameObject>();
	public List <GameObject> pile = new List<GameObject>();
	public List <GameObject> equipped = new List<GameObject>();
	public List <GameObject> tempDeck = new List <GameObject> ();

	void Start(){
		for (int i = 0; i < slots.Length; i++) {
			int n = i + 1;
			string g = "Card Slot " + n.ToString ();
			slots [i] = GameObject.Find (g);
		}

		InitializeDeck ();		
	}

	void Update(){
		if (tempDeck.Count <= 0) {
//			LoadDeck ();
			ReloadDeck();
		}
	}


	public void DrawNewCards(){
		if (!isLoading) {
			StartCoroutine ("LoadCards");
		} else {
			Debug.Log ("Still Loading...");

			//Insert else code
		}
	}

	IEnumerator LoadCards(){


		for (int i = 0; i < slots.Length; i++) {

			Card card = slots [i].GetComponentInChildren<Card> ();
			if (card != null) {
				if (card.mySlotState == Card.SlotState.CARD_SLOT) {
					DeactivateCard (card.gameObject, true);
				}
			}
		}

		Debug.Log ("Loading");
		isLoading = true;

		//Insert Loading code

		yield return new WaitForSeconds (loadTime);

		isLoading = false;

		if (tempDeck.Count >= slots.Length) {
			for (int i = 0; i < slots.Length; i++) {

				int num = Random.Range (0, tempDeck.Count - 1);

				drawnCard = tempDeck [num];
				hand.Add (drawnCard);
				tempDeck.Remove (drawnCard);

//			cards [i] = Instantiate(drawnCard,slots [i].transform.position,Quaternion.identity)  as GameObject;
				cards [i] = drawnCard;
				RectTransform rectTransform = cards [i].GetComponent<RectTransform> ();
				cards [i].transform.SetParent (slots [i].transform, false);
				cards [i].SetActive (true);

			}
		} else {
//			print ("Not enough cards in Deck");

			for (int i = 0; i < tempDeck.Count + 1; i++) {

				int num = Random.Range (0, tempDeck.Count - 1);

				drawnCard = tempDeck [num];
				hand.Add (drawnCard);
				tempDeck.Remove (drawnCard);

				cards [i] = drawnCard;
				RectTransform rectTransform = cards [i].GetComponent<RectTransform> ();
				cards [i].transform.SetParent (slots [i].transform, false);
				cards [i].SetActive (true);

			}

			ReloadDeck ();
		}


		Debug.Log ("Loaded");

		//Insert New cards code

	}
		

	void ReloadDeck(){
		tempDeck.AddRange (pile);
		pile.Clear ();
	}

	public void AddtoCarry(GameObject card){
		equipped.Add(card);
		hand.Remove (card);
	}

	public void DeactivateCard(GameObject card, bool discarded){
		hand.Remove (card);
		card.SetActive (false);
		card.transform.position = transform.position;
		card.transform.SetParent (transform);

		if (discarded) {
			pile.Add (card);
		}
	}

	void InitializeDeck(){
		for (int i = 0; i < deck.Count; i++) {
			GameObject deckCard = Instantiate (deck [i], transform.position, Quaternion.identity);
			deckCard.transform.SetParent (transform);
			deckCard.SetActive (false);
			tempDeck.Add (deckCard);
		}
	}

}
