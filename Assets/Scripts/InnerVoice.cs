using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerVoice : MonoBehaviour {

	public AudioClip WhatHappened;
	public AudioClip GoodLandingArea;

	private AudioSource MyAudioSource;

	// Use this for initialization
	void Start () {
		MyAudioSource = GetComponent<AudioSource> ();
		MyAudioSource.clip = WhatHappened;
		MyAudioSource.Play ();
	}
	
	void OnFindClearArea(){
		Debug.Log (name + " OnFindClearArea");
		MyAudioSource.clip = GoodLandingArea;
		MyAudioSource.Play ();

		Invoke ("CallHeli", GoodLandingArea.length + 1f);
	}

	void CallHeli(){
		SendMessageUpwards ("OnMakeInitialHeliCall");
	}
}
