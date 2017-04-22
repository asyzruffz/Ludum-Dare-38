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
		int[] array = new int[colours.Length];
		for (int i = 0; i < array.Length; i++) {
			array[i] = i;
		}
		Shuffle (array);
		
		switch (level) {
			case 1:
			case 2:
			case 3:
				// stage 1
				SetHeadColour (colours[array[0]]);
				SetBodyColour (colours[array[0]]);
				SetArmColour (colours[array[0]]);
				SetLegColour (colours[array[0]]);
				break;
			case 4:
			case 5:
			case 6:
				// stage 2
				SetHeadColour (colours[array[0]]);
				SetBodyColour (colours[array[1]]);
				SetArmColour (colours[array[1]]);
				SetLegColour (colours[array[1]]);
				break;
			case 7:
			case 8:
			case 9:
				// stage 3
				SetHeadColour (colours[array[0]]);
				SetBodyColour (colours[array[1]]);
				SetArmColour (colours[array[1]]);
				SetLegColour (colours[array[2]]);
				break;
			case 10:
			case 11:
			case 12:
				// stage 4
				SetHeadColour (colours[array[0]]);
				SetBodyColour (colours[array[1]]);
				SetArmColour (colours[array[2]]);
				SetLegColour (colours[array[3]]);
				break;
			case 13:
			case 14:
			case 15:
			default:
				// stage 5
				SetHeadColour (colours[array[0]]);
				SetBodyColour (colours[array[1]]);
				bodyparts[3].GetComponent<MeshRenderer>().material = colours[array[2]];
				bodyparts[4].GetComponent<MeshRenderer>().material = colours[array[3]];
				SetLegColour (colours[array[4]]);
				break;
		}
	}
	
	void SetHeadColour (Material col) {
		bodyparts[0].GetComponent<MeshRenderer>().material = col;
	}
	
	void SetBodyColour (Material col) {
		bodyparts[1].GetComponent<MeshRenderer>().material = col;
	}
	
	void SetArmColour (Material col) {
		bodyparts[3].GetComponent<MeshRenderer>().material = col;
		bodyparts[4].GetComponent<MeshRenderer>().material = col;
	}
	
	void SetLegColour (Material col) {
		bodyparts[2].GetComponent<MeshRenderer>().material = col;
		bodyparts[5].GetComponent<MeshRenderer>().material = col;
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
