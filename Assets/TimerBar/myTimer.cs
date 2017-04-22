using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class myTimer : MonoBehaviour {
    public float theTimer = 10;
    private Text timerText;

	// Use this for initialization
	void Start () {
        timerText = GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update () {
        if (theTimer >= 0)
        {
            theTimer -= Time.deltaTime;
            timerText.text = theTimer.ToString("f0");
        }

    }
}
