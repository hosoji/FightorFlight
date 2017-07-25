using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CARD_Search : Card {

	const CardType type = CardType.ACTION_CARD;


	void Start () {
		SetUp ();
	}

	protected override void SetUp (){
		base.SetUp ();
	}

	protected override void Update (){
		base.Update ();
	}

	protected override void CardAbility (){
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
//		PlayerController control = player.GetComponent<PlayerController> ();
//
		Vector3 fwd = player.transform.TransformDirection(Vector3.forward); 

		RaycastHit hit;

		Searchable search;
		Transform t;


		if (Physics.Raycast (player.transform.position, fwd, out hit, GameManager.gridSize)) { 
			
			search = hit.transform.gameObject.GetComponent<Searchable> ();
			t = hit.transform;
			if (search != null) {
				if (loader.searchables.Count > 0) {
					loader.CheckBlankCard ();
					if (loader.blankFound) {
						loader.ReplaceBlankCard ();
						search.DisableSearchable ();
						loader.blankFound = false;

					} else {
						print ("No Blank Card in Hand");
					}
					//Search code here
					Debug.Log ("Object is searchable");
				}
			} else {
				print ("Search found nothing.");
			}

		} else {
			print ("Raycast found nothing");
		}

		PlayerController.actionSuccessful = true;

	}



}
