using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 1;

	private Vector3 dir;

	void Start () {
		
	}
	
	void Update () {
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		dir = (new Vector3 (h, 0, v)).normalized;
	}

	void FixedUpdate () {
		GetComponent<Rigidbody> ().MovePosition (transform.position + transform.TransformDirection (dir) * speed * Time.deltaTime);
	}
}
