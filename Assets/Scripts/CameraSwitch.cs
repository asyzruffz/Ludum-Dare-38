using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {

	public Camera[] cams;

	private int currentIndex = -1;

	void Start () {
		if (cams.Length > 0) {
			currentIndex = 0;
		}

		Switching ();
	}
	
	public void Toggle () {
		if (currentIndex >= 0) {
			currentIndex++;
			currentIndex = currentIndex % cams.Length;
			Switching ();
		}
	}

	void Switching () {
		for (int i = 0; i < cams.Length; i++) {
			cams[i].gameObject.SetActive (i == currentIndex);
		}
	}
}
