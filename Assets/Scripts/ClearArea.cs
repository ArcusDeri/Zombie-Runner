using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearArea : MonoBehaviour {

	public float TimeSinceLastTrigger = 0f;

	private GameObject HUD;
	private bool IsDisplayed = false;

	// Use this for initialization
	void Start () {
		HUD = GameObject.Find ("HUD");
		HUD.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		TimeSinceLastTrigger += Time.deltaTime;
		if (TimeSinceLastTrigger >= 1f && Time.realtimeSinceStartup > 10f && !IsDisplayed) {
			SendMessageUpwards ("OnFindClearArea");
			HUD.SetActive (true);
			IsDisplayed = true;
			Invoke ("HideMessage", 10f);
		}
	}

	void OnTriggerStay(Collider collider){
		if (collider.tag != "Player") {
			TimeSinceLastTrigger = 0f;
			HUD.SetActive (false);
		}
	}

	void HideMessage(){
		HUD.SetActive (false);
	}
}
