using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Image gameTitle;
	public Button playButton;

	public void SetPlayButtonDisplay (bool enabled) {
		playButton.gameObject.SetActive (enabled);
	}

	public void SetTitleDisplay (bool enabled) {
		gameTitle.gameObject.SetActive (enabled);
	}
}
