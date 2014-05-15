using UnityEngine;
using System.Collections;

public class KillZone : MonoBehaviour {

	GameObject cameraManager;

	// Use this for initialization
	void Start () {
		cameraManager = GameObject.Find ("$CameraManager");
	}
	
	void OnTriggerEnter(Collider obj) {
		if (obj.tag == "Player")
			Respawn(obj.gameObject);
		else 
			Destroy(obj.gameObject);

	}

	void Respawn(GameObject obj) {
		CameraManager script = cameraManager.GetComponent<CameraManager> ();
		int i = script.CurrentCamera;

		Vector3 position = script.TriggerZones [i].transform.position;
		Vector3 size = script.TriggerZones [i].transform.localScale;
		size.x = 0; size.z = 0;

		obj.transform.position = position + size;
	}
}
