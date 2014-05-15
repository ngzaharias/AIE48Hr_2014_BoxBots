using UnityEngine;
using System.Collections;

public class Grounded : MonoBehaviour {

	public bool ground = false;

	//void OnTriggerEnter(Collider obj) {
	//	if (obj.transform != transform.parent)
	//		ground=true;
	//}
	//
	//void OnTriggerExit(Collider obj) {
	//	if (obj.transform != transform.parent)
	//		ground=false;
	//}

	void FixedUpdate() {
		ground = false;
	}

	void OnTriggerStay(Collider obj) {
		if (obj.transform != transform.parent)
			ground=true;
	}
}
