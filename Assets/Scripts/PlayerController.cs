using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public GameObject guide;

    public float walkSpeed = 1;
	public float turnSpeed = 1;

	private Vector3 dir;

	void Start () {
		
	}
	
	void Update () {
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		dir = (new Vector3 (h, 0, v)).normalized;
		if(Mathf.Abs(h) > 0) {
			transform.Rotate(0, Mathf.Asin (dir.x) * Mathf.Rad2Deg * turnSpeed * 0.01f, 0);
		}

		PlayerInteraction interaction = GetComponent<PlayerInteraction> ();
            if (interaction.detecting)
            {
                guide.SetActive(true);
            }
            else
            {
                guide.SetActive(false);
            }

            if (Input.GetButtonDown("Jump") && interaction.detecting) {
			PlayerMemory memory = GetComponent<PlayerMemory> ();

			Debug.Log ("Interacting " + interaction.target.name);
			Transform target = interaction.target;
			Reaction.SpeechType speak;
			if (memory.retainingMemory) {
				if (memory.Recall (target.GetComponent<NPCAttrib> ().ID)) {
					speak = Reaction.SpeechType.FoundYou;
				} else {
					speak = Reaction.SpeechType.WrongPerson;
				}
			} else {
				memory.Remember (target.GetComponent<NPCAttrib> ().ID);
				speak = Reaction.SpeechType.PlsRememberMe;
			}
			target.GetComponent<Reaction> ().ReactTowards (transform.position, speak);
		}
	}

	void FixedUpdate () {
		Vector3 localDir = transform.TransformDirection (Vector3.forward * dir.z);
		GetComponent<Rigidbody> ().MovePosition (transform.position + localDir * walkSpeed * Time.deltaTime);
	}
}
