using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class NPCAttrib : MonoBehaviour {

	public Transform[] bodyparts = new Transform[6];
	public ColourPalette bodyColours;
	public string ID = "";
	
	private Material[] colours;

	void Start () {
		colours = bodyColours.colours;

		int[] array = new int[colours.Length];
		for (int i = 0; i < array.Length; i++) {
			array[i] = i;
		}
		Shuffle (array);

		for (int i = 0; i < bodyparts.Length - 1; i++) {
			bodyparts[i].GetComponent<MeshRenderer>().material = colours[array[i]];
			ID = ID + array[i].ToString();
		}
		bodyparts[bodyparts.Length - 1].GetComponent<MeshRenderer>().material = colours[array[colours.Length - 1]];
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
