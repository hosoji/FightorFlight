using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilScript : MonoBehaviour {

	public static float remapRange(float oldValue, float oldMin, float oldMax, float newMin, float newMax )
	{
		float newValue = 0;
		float oldRange = (oldMax - oldMin);
		float newRange = (newMax - newMin);
		newValue = (((oldValue - oldMin) * newRange) / oldRange) + newMin;
		return newValue;


	}

	public static int ConvertStringtoInt(string s){
		int num;
		int.TryParse (s, out num);

		return num;
	}

	public static void AlignRectTransformToParent( RectTransform rectTransform){
		rectTransform.localPosition = new Vector3(0f, 0f, 0f);
		rectTransform.localRotation = Quaternion.identity;
		rectTransform.localScale = new Vector3(1f, 1f, 1f);
		
	}



}
