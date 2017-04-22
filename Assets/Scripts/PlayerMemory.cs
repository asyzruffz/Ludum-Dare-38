using UnityEngine;

public class PlayerMemory : MonoBehaviour {

	public bool retainingMemory;
	public string idRemembered;

	public void Remember (string id) {
		idRemembered = id;
		retainingMemory = true;
	}

	public bool Recall (string id) {
		if (idRemembered == id) {
			retainingMemory = false;
			idRemembered = "";
			return true;
		}

		return false;
	}
}
