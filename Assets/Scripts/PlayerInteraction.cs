using UnityEngine;

public class PlayerInteraction : MonoBehaviour {

	public bool detecting;
	public Transform target;

	public LayerMask interactMask;
	public Vector3 offset;
	public float distance = 1;

	private Vector3 rotatedOffset;
	
	void Update () {
		rotatedOffset = transform.TransformDirection (offset);
		RaycastHit hit;
		detecting = Physics.Raycast (transform.position + rotatedOffset, transform.forward, out hit, distance, interactMask);
		target = detecting ? hit.collider.transform.parent : null;
	}

	void OnDrawGizmos () {
		Gizmos.color = detecting ? Color.green : Color.red;
		Gizmos.DrawLine (transform.position + rotatedOffset, transform.position + rotatedOffset + transform.forward * distance);
	}
}
