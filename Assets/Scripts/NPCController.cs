using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour {

	public float speed = 1;
	public bool moving;

	private Vector3 dir;

	void Start () {
		float angle = Random.Range (0, 360);
		transform.Rotate (0, angle, 0);
		dir = Vector3.forward;
		moving = true;
	}
	
	void Update () {

	}

	void FixedUpdate () {
		if (moving) {
			GetComponent<Rigidbody> ().MovePosition (transform.position + transform.TransformDirection (dir) * speed * Time.deltaTime);
		}
	}
}
