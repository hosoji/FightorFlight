using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public Transform target;

	public float offSetX, offSetZ;

	//      Camera
	//		float offSetX = -3;
	//		float offSetZ = -4.5f;


	void Update () {
		if (target != null) {
			transform.position = new Vector3 (target.position.x + offSetX, transform.position.y, target.position.z + offSetZ);
		}
	}




}
