using UnityEngine;

public class PlayerGuide : MonoBehaviour {

    public GameObject guide;

    private PlayerInteraction interaction;

    void Start () {
        interaction = GetComponent<PlayerInteraction> ();
    }
	
	void Update () {
        if (interaction.detecting) {
            guide.SetActive (true);
        } else {
            guide.SetActive (false);
        }
    }
}
