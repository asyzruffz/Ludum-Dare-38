using UnityEngine;

public class CameraFacingBillboard : MonoBehaviour {

    // Let the rotation to always face the main camera
    void Update () {
        transform.LookAt (transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
    }
}
