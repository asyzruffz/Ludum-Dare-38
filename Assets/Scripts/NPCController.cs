using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour {

	public float speed = 1;

	private Vector3 dir;

	void Start () {
		float angle = Random.Range (0, 360);
		transform.Rotate (0, angle, 0);
		dir = Vector3.forward;
	}
	
	void Update () {

	}

	void FixedUpdate () {
		GetComponent<Rigidbody> ().MovePosition (transform.position + transform.TransformDirection (dir) * speed * Time.deltaTime);
	}
}
