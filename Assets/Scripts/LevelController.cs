using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

	public GameObject player;
	public int currentGameLvl = 1;
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit ();
		}
	}

	public void NextLevel () {
		currentGameLvl++;

		if (currentGameLvl > 10) {
			GameOver ();
			return;
		}

		foreach (Transform t in transform) {
			NPCAttrib attributes = t.GetComponent<NPCAttrib> ();
			if (attributes) {
				attributes.level = currentGameLvl;
				attributes.Recolour ();
			}
		}
	}

	public void GameOver () {
		GetComponent<CameraSwitch> ().Toggle ();
        GetComponent<UIManager> ().SetGameOverDisplay (true);
	}

    public void Restart () {
        SceneManager.LoadScene (0);
    }
}
