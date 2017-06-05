using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HUDManager : MonoBehaviour {

	public Image energyAmount;

	public GameObject compUnitObject;

	GameObject compUnitHolder;

	public Transform uiBase;

	public Color colorLow1, colorHigh1, colorLow2, colorHigh2, colorLow3, colorHigh3;

	Image compUnitImg;

	public List<GameObject> compSegments = new List<GameObject>();

	bool isPaused;
	int index;
	int composure;

	// Use this for initialization
	void Start (){

		compUnitHolder = GameObject.Find ("Composure Segments Holder");
		compUnitImg = compUnitObject.GetComponent<Image>();

		for (int i = 0; i < GameManager.composure; i++) {
			float mod = 1f;

			Vector3 pos = new Vector3 (uiBase.position.x + ((compUnitImg.rectTransform.rect.width * mod) * i), uiBase.position.y, uiBase.position.z);
			GameObject image = Instantiate (compUnitObject, pos, Quaternion.identity) as GameObject;


			image.transform.SetParent (compUnitHolder.transform);
			image.name = i.ToString (); 

			Image img = image.GetComponent<Image> ();
			img.color = new Color(1,1,1,0.2f);

			compSegments.Add (image);
		}

		StartCoroutine("SegmentMoveDown");

		
	}
	
	// Update is called once per frame
	void Update () {

//		print (index);
//		composure = GameManager.composure - 1;

	

		float energyFill = UtilScript.remapRange (GameManager.energy, 0, 20, 0, 1);
		energyAmount.fillAmount = energyFill;

		
	}
		

	public void RemoveSegment (int n){

		if (index >= (composure-n)) {
			StopAllCoroutines ();

			StartCoroutine ("SegmentMoveUp");

		}
		for (int i = 0; i < n; i++) {
			composure = GameManager.composure - 1;

			GameObject seg = compSegments[composure];
			compSegments.Remove (seg);
			Destroy (seg);
			GameManager.composure--;


		}
	}

	public void AddSegment (int n){
		for (int i = 0; i < n; i++) {
			composure = GameManager.composure - 1;

			GameObject seg = compSegments[composure];
//			int segNum = UtilScript.ConvertStringtoInt (seg.name);


			float mod = 1f;
			Vector3 pos = new Vector3 (seg.transform.position.x + ((compUnitImg.rectTransform.rect.width * mod) * 1), seg.transform.position.y, seg.transform.position.z);
			GameObject image = Instantiate (compUnitObject, pos, Quaternion.identity) as GameObject;
			image.transform.SetParent (compUnitHolder.transform);

			GameManager.composure++;
			image.name = (composure + 1).ToString();

			compSegments.Add (image);
		}
	}

	IEnumerator SegmentMoveUp(){

		for (int i = 1; i < compSegments.Count; i++) {

//			float mod = 1f/(i+1);
			float mod = (i+1)*0.01f;

			Image img = compSegments[i].GetComponent<Image> ();
			index = UtilScript.ConvertStringtoInt (img.name);

			if (composure > 17) {
				img.color = ChangeSegmentColor (i, 0, (float)(compSegments.Count - 1), colorLow1, colorHigh1);  
			} else if (composure > 10) {
				img.color = ChangeSegmentColor (i, 0, (float)(compSegments.Count - 1), colorLow2, colorHigh2);  
			} else {
				img.color = ChangeSegmentColor (i, 0, (float)(compSegments.Count - 1), colorLow3, colorHigh3);  
			}

			yield return new WaitForSeconds(mod);
			if (i < compSegments.Count - 1) {
				img.color = new Color(1,1,1,0.2f);
			} else {
				StartCoroutine ("SegmentMoveDown");
			}
		}

	}

	IEnumerator SegmentMoveDown(){
		composure = GameManager.composure - 1;


		for (int i = compSegments.Count-1; i > -1; i--) {
			

//			float mod = (i+1)*0.01f;

			Image img = compSegments[i].GetComponent<Image> ();
			index = UtilScript.ConvertStringtoInt (img.name);

			if (composure > 17) {
				img.color = ChangeSegmentColor (i, 0, (float)(composure), colorLow1, colorHigh1);  
			} else if (composure > 10) {
				img.color = ChangeSegmentColor (i, 0, (float)(composure), colorLow2, colorHigh2);  
			} else {
				img.color = ChangeSegmentColor (i, 0, (float)(composure), colorLow3, colorHigh3);  
			}
	
			yield return new WaitForSeconds(0.07f);
			if (i > 0) {
				img.color = new Color(1,1,1,0.2f);
			} else {
				
				if (composure > 1) {
					RemoveSegment (1);
				}
				StartCoroutine ("SegmentMoveUp");
			}
		}
	}

	public Color ChangeSegmentColor(int index, float min, float max, Color c1, Color c2){
		float colorChange = UtilScript.remapRange (index, min, max, 0, 1);
		Color lerpedColor = Color.LerpUnclamped(c1, c2, colorChange);
		return lerpedColor;

	}




}
