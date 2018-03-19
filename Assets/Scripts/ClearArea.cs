using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
		if (TimeSinceLastTrigger >= 1f && Time.realtimeSinceStartup > 30f && !IsDisplayed) {
			SendMessageUpwards ("OnFindClearArea");
			HUD.SetActive (true);
			IsDisplayed = true;
			Invoke ("UpdateMessage", 15f);
		}
	}

	void OnTriggerStay(Collider collider){
		if (collider.tag != "Player") {
			TimeSinceLastTrigger = 0f;
		}
	}

	void UpdateMessage(){
		var message = HUD.GetComponentInChildren<Text> ();
		message.text = "Wait for the helicopter and get into it when it arrives!"; 
		//HUD.SetActive (false);
	}
}
