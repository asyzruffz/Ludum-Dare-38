using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

	public GameObject player;
	public int currentGameLvl = 1;

	void Start () {
		
	}
	
	void Update () {

	}

	public void NextLevel () {
		currentGameLvl++;

		if (currentGameLvl > 10) {
			GameOver ();
			return;
		}

		foreach (Transform t in transform) {
			NPCAttrib attributes = t.GetComponent<NPCAttrib> ();
			if (attributes) {
				attributes.level = currentGameLvl;
				attributes.Recolour ();
			}
		}
	}

	public void GameOver () {
		GetComponent<CameraSwitch> ().Toggle ();
	}
}
