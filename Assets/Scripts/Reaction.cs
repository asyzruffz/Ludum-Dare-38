using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaction : MonoBehaviour {

	public float respondDuration = 2;

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
				transform.Rotate (transform.up, awayAngle);
				controller.moving = true;
			}
		}
	}

	public void ReactTowards (Vector3 pos) {
		controller.moving = false;
		transform.rotation = Quaternion.LookRotation (pos - transform.position, transform.up);
	}
}
