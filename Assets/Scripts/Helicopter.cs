using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {

	public AudioClip CallSound;

	private bool IsCalled = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("CallHeli") && !IsCalled) {
			IsCalled = true;
			Debug.Log("Helicopter called.");
		}
	}
}
