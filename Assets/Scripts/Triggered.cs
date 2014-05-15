using UnityEngine;
using System.Collections;

public class Triggered : MonoBehaviour {

	private int Present = 0;

	void OnTriggerEnter(Collider obj) {
		if (obj.tag == "Player")
			Present++;
	}

	void OnTriggerExit(Collider obj) {
		if (obj.tag == "Player")
			Present--;
	}

	public int PlayersPresent() {
		return Present;
	}
}
