using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class NPCAttib : MonoBehaviour {

	public Transform[] bodyparts = new Transform[6];
	public Material[] bodyColor = new Material [5]; 
	public string ID ="";
	public int level = 5; //up to 15
	private int stage = 1; //up to 5 
	// Use this for initialization
	void Start () {
		int[] array = { 0, 1, 2, 3, 4};
		switch (level) {
			case 1:
			case 2:
			case 3:
			  	stage = 1;
			  break;
			case 4:
			case 5:
			case 6:
			  	stage = 2;
			  break;
			case 7:
			case 8:
			case 9:
			  	stage = 3;
			  break;
			case 10:
			case 11:
			case 12:
			  	stage = 4;
			  break;
			case 13:
			case 14:
			case 15:
			  	stage = 5;
			  break;
			default:
			    stage = 5;
			break;

		}
      	Shuffle(array);
      	// 0: Head, 1: Torso, 2: Left Leh, 3: Right Arm, 4: Left Arm, 5: Right Leg
        for (int i = 0; i < stage; i++) {
			bodyparts[i].GetComponent<MeshRenderer>().material=bodyColor[array[i]];
			ID = ID + array[i].ToString();
      	}
      	
      	if (stage == 3) 
      	{
			bodyparts[3].GetComponent<MeshRenderer>().material=bodyColor[array[1]];
			bodyparts[4].GetComponent<MeshRenderer>().material=bodyColor[array[1]];
      	}
      	else {
	      	for (int k = stage; k < 5; k++) {
				bodyparts[k].GetComponent<MeshRenderer>().material=bodyColor[array[stage-1]];
				ID = ID + array[stage-1].ToString();
	      	}
      	}
      	if (stage == 1) {
			bodyparts[5].GetComponent<MeshRenderer>().material=bodyColor[array[0]];
      	}
      	else if (stage == 2) {
			bodyparts[5].GetComponent<MeshRenderer>().material=bodyColor[array[1]];
      	}
      	else {
			bodyparts[5].GetComponent<MeshRenderer>().material=bodyColor[array[2]];
      	}
		
    }
	
	static System.Random _random = new System.Random();

	static void Shuffle<T>(T[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n; i++)
        {
            // NextDouble returns a random number between 0 and 1.
            // ... It is equivalent to Math.random() in Java.
            int r = i + (int)(_random.NextDouble() * (n - i));
            T t = array[r];
            array[r] = array[i];
            array[i] = t;
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
