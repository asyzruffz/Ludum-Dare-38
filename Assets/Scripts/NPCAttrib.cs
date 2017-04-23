using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class NPCAttrib : MonoBehaviour {

	public Transform[] bodyparts = new Transform[6];
	public ColourPalette bodyColours;
	public string ID = "";
	public int level = 1; //up to 15
	
	private Material[] colours;

	void Start () {
		colours = bodyColours.colours;
		
		// bodyparts - 0: Head, 1: Torso, 2: Left Leg, 3: Right Arm, 4: Left Arm, 5: Right Leg
		
		Recolour ();
    }
	
	public void Recolour () {
		ID = "";
		int[] array = new int[colours.Length];
		for (int i = 0; i < array.Length; i++) {
			array[i] = i;
		}
		Shuffle (array);
		
		switch (level) {
			case 1:
				// stage 1
				SetHeadColour (array[0]);
				SetBodyColour (array[0]);
				SetLegColour (array[0]);
				SetArmColour (array[0]);
				break;
			case 2:
			case 3:
				// stage 2
				SetHeadColour (array[0]);
				SetBodyColour (array[1]);
				SetLegColour (array[1]);
				SetArmColour (array[1]);
				break;
			case 4:
			case 5:
				// stage 3
				SetHeadColour (array[0]);
				SetBodyColour (array[1]);
				SetLegColour (array[2]);
				SetArmColour (array[1]);
				break;
			case 6:
			case 7:
				// stage 4
				SetHeadColour (array[0]);
				SetBodyColour (array[1]);
				SetLegColour (array[3]);
				SetArmColour (array[2]);
				break;
			case 8:
			case 9:
			case 10:
			default:
				// stage 5
				SetHeadColour (array[0]);
				SetBodyColour (array[1]);
				SetLegColour (array[4]);
				SetArmColour (array[2], array[3]);
				break;
		}
	}
	
	void SetHeadColour (int colIndex) {
		bodyparts[0].GetComponent<MeshRenderer>().material = colours[colIndex];
		ID = ID + colIndex.ToString ();
	}
	
	void SetBodyColour (int colIndex) {
		bodyparts[1].GetComponent<MeshRenderer>().material = colours[colIndex];
		ID = ID + colIndex.ToString ();
	}

	void SetLegColour (int colIndex) {
		bodyparts[2].GetComponent<MeshRenderer> ().material = colours[colIndex];
		bodyparts[5].GetComponent<MeshRenderer> ().material = colours[colIndex];
		ID = ID + colIndex.ToString ();
	}

	void SetArmColour (int colIndex) {
		bodyparts[3].GetComponent<MeshRenderer>().material = colours[colIndex];
		bodyparts[4].GetComponent<MeshRenderer>().material = colours[colIndex];
		ID = ID + colIndex.ToString () + colIndex.ToString ();
	}

	void SetArmColour (int colIndex1, int colIndex2) {
		bodyparts[3].GetComponent<MeshRenderer> ().material = colours[colIndex1];
		bodyparts[4].GetComponent<MeshRenderer> ().material = colours[colIndex2];
		ID = ID + colIndex1.ToString () + colIndex2.ToString ();
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
}
