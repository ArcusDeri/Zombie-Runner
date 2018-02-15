using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearArea : MonoBehaviour {

	public float TimeSinceLastTrigger = 0f;

	private GameObject HUD;

	// Use this for initialization
	void Start () {
		HUD = GameObject.Find ("HUD");
		HUD.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		TimeSinceLastTrigger += Time.deltaTime;
		if (TimeSinceLastTrigger >= 1f) {
			HUD.SetActive (true);
		}
	}

	void OnTriggerStay(){
		TimeSinceLastTrigger = 0f;
	}
}
