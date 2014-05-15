using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	public static int TotalPlayers;
	public int Players;

	public Transform[] CameraLocations;
	public GameObject[] TriggerZones;

	[HideInInspector]
	public int CurrentCamera = 0;
	int CamerasUnlocked = 1;

	void Start() {
		Camera.main.transform.position = CameraLocations [CurrentCamera].position;
		TotalPlayers = Players;
	}

	// Update is called once per frame
	void Update () {
		int zone = 0;
		int mostPlayers = 0;
		for (int i = 0; i < TriggerZones.Length; i++) {
			int presentPlayers = TriggerZones [i].GetComponent<Triggered> ().PlayersPresent ();
			if (presentPlayers > mostPlayers) {
				mostPlayers = presentPlayers;
				zone = i;
			}

			if (presentPlayers == TotalPlayers) {
				CamerasUnlocked = i;
				print(CamerasUnlocked);
			}
		}

		if (mostPlayers > ((float)TotalPlayers / 2.0f) && zone <= CamerasUnlocked) {
			CurrentCamera = zone;
			Camera.main.transform.position = CameraLocations [CurrentCamera].transform.position;
		}
	}
}
