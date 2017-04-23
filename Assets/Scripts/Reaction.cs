using UnityEngine;
using UnityEngine.UI;

public class Reaction : MonoBehaviour {

	public enum SpeechType {
		PlsRememberMe,
		WrongPerson,
		FoundYou
	}

	public float respondDuration = 2;
	public GameObject speech;
	public Text dialog;

	private NPCController controller;
	private float waitTimer = 0;
	private bool needToBlink;
	private bool needToNextLvl;

	void Start () {
		controller = GetComponent<NPCController> ();
	}
	
	void Update () {
		if (!controller.moving) {
			waitTimer += Time.deltaTime;
			if (waitTimer >= respondDuration) {
				waitTimer = 0;
				if (needToBlink) {
					Blink ();
				}
				if (needToNextLvl) {
					needToNextLvl = false;
					LevelController lvlCon = FindObjectOfType<LevelController> ();
					if (lvlCon) {
						lvlCon.NextLevel ();
					}
				}

				float awayAngle = Random.Range(90.0f, 270.0f);
				transform.Rotate (Vector3.up, awayAngle);
				speech.SetActive (false);
				controller.moving = true;
			}
		}
	}

	public bool IsReacting () {
		return waitTimer > 0;
	}

	public void ReactTowards (Vector3 pos, SpeechType speechType) {
		controller.moving = false;
		SetSpeech (speechType);
		transform.rotation = Quaternion.LookRotation (pos - transform.position, transform.up);
		needToBlink = (speechType == SpeechType.PlsRememberMe || speechType == SpeechType.FoundYou);
	}

	void Blink () {
		transform.position = -transform.position;
		needToBlink = false;
	}

	void SetSpeech (SpeechType speechType) {
		switch (speechType) {
			case SpeechType.PlsRememberMe:
				dialog.text = "See you again!";
				break;
			case SpeechType.WrongPerson:
				dialog.text = "Sorry, wrong person!";
				break;
			case SpeechType.FoundYou:
				dialog.text = "Found you!";
				needToNextLvl = true;
				break;
		}

		speech.SetActive (true);
	}
}
