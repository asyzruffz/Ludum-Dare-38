using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaction : MonoBehaviour {

	public float respondDuration = 2;
	public GameObject speech;

	private NPCController controller;
	private float waitTimer = 0;

	void Start () {
		controller = GetComponent<NPCController> ();
	}
	
	void Update () {
		if (!controller.moving) {
			waitTimer += Time.deltaTime;
			if (waitTimer >= respondDuration) {
				float awayAngle = Random.Range(90.0f, 270.0f);
				transform.Rotate (Vector3.up, awayAngle);
				speech.SetActive (false);
				controller.moving = true;
				waitTimer = 0;
			}
		}
	}

	public void ReactTowards (Vector3 pos) {
		controller.moving = false;
		speech.SetActive (true);
		transform.rotation = Quaternion.LookRotation (pos - transform.position, transform.up);
	}

	void Blink() {
		transform.position = -transform.position;
	}
}
