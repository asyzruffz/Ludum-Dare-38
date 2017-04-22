using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 1;

	private Vector3 dir;

	void Start () {
		
	}
	
	void Update () {
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		dir = (new Vector3 (h, 0, v)).normalized;
		if(Mathf.Abs(h) > 0) {
			//transform.Rotate(0, Mathf.Cos (localDir.x) * 90, 0);
		}

		PlayerInteraction interaction = GetComponent<PlayerInteraction> ();
		if (Input.GetButtonDown("Jump") && interaction.detecting) {
			interaction.detectTarget.GetComponent<Reaction> ().ReactTowards (transform.position);
			Debug.Log ("Interacting " + interaction.detectTarget.name);
		}
	}

	void FixedUpdate () {
		Vector3 localDir = transform.TransformDirection (dir);
		GetComponent<Rigidbody> ().MovePosition (transform.position + localDir * speed * Time.deltaTime);
	}
}
