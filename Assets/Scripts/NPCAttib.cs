using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class NPCAttib : MonoBehaviour {

	public Transform[] bodyparts = new Transform[6];
	public Material[] bodyColor = new Material [5]; 
	public string ID ="";
	// Use this for initialization
	void Start () {

  	  int[] array = { 0, 1, 2, 3, 4};
      Shuffle(array);
        for (int i = 0; i < 5; i++) 
      {
		bodyparts[i].GetComponent<MeshRenderer>().material=bodyColor[array[i]];
		ID = ID + array[i].ToString();
      }
		bodyparts[5].GetComponent<MeshRenderer>().material=bodyColor[array[4]];
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
