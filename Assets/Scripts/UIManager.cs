using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Button playButton;

	public void SetPlayButtonDisplay (bool enabled) {
		playButton.gameObject.SetActive (enabled);
	}
}
