using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidObstacle : MonoBehaviour {

    public float turnRate = 1;
    public float distance = 1;
    public float width = 0.5f;
    public Vector3 offset;

    [ShowOnly]
    public bool detectRight;
    [ShowOnly]
    public bool detectLeft;

    private Vector3 rotatedOffset;
    private Vector3 dirRight = Vector3.forward;
    private Vector3 dirLeft = Vector3.forward;
    private bool turning;
    private int turnDir;
    private float timer = 0;

    void Start () {
		
	}
	
	void FixedUpdate () {
        rotatedOffset = transform.TransformDirection (offset);
        dirRight = transform.TransformDirection (new Vector3 (width, 0, distance));
        dirLeft = transform.TransformDirection (new Vector3 (-width, 0, distance));
        
        detectRight = Physics.Raycast (transform.position + rotatedOffset, dirRight.normalized, dirRight.magnitude) ||
                      Physics.Raycast (transform.position + rotatedOffset + transform.right * width, transform.forward, distance);
        detectLeft = Physics.Raycast (transform.position + rotatedOffset, dirLeft.normalized, dirLeft.magnitude) ||
                     Physics.Raycast (transform.position + rotatedOffset + transform.right * -width, transform.forward, distance);

        // don't turn while speaking
        turning = turning && !GetComponent<Reaction> ().IsReacting ();

        if (turning) {
            transform.Rotate (transform.up, turnRate * turnDir);

            // stop turning when it's clear
            if (!detectRight && !detectLeft) {
                turning = false;
                timer = 0;
            }

            // to prevent continuous turning, change direction after 4 seconds
            timer += Time.fixedDeltaTime;
            if (timer >= 4) {
                turnDir = -turnDir;
                timer = 0;
            }
        } else {
            turning = (detectRight || detectLeft);
            turnDir = detectRight ? 1 : detectLeft ? -1 : 0;
        }
    }

    void OnDrawGizmos () {
        Gizmos.color = detectRight ? Color.green : Color.red;
        Gizmos.DrawLine (transform.position + rotatedOffset, transform.position + rotatedOffset + dirRight);
        Gizmos.DrawLine (transform.position + rotatedOffset + (transform.right * width), transform.position + rotatedOffset + (transform.right * width) + (transform.forward * distance));

        Gizmos.color = detectLeft ? Color.green : Color.red;
        Gizmos.DrawLine (transform.position + rotatedOffset, transform.position + rotatedOffset + dirLeft);
        Gizmos.DrawLine (transform.position + rotatedOffset + (transform.right * -width), transform.position + rotatedOffset + (transform.right * -width) + (transform.forward * distance));
    }
}
