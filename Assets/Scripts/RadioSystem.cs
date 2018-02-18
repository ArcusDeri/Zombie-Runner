using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioSystem : MonoBehaviour {

	public AudioClip InitialMessage;
	public AudioClip ReplyMessage;

	private AudioSource MyAudioSource;

	// Use this for initialization
	void Start () {
		MyAudioSource = GetComponent<AudioSource> ();
	}
	void OnMakeInitialHeliCall(){
		Debug.Log (name + " OnMakeInitialHeliCall");
		MyAudioSource.clip = InitialMessage;
		MyAudioSource.Play ();
		Invoke ("Reply",InitialMessage.length + 1f);
	}

	private void Reply(){
		MyAudioSource.clip = ReplyMessage;
		MyAudioSource.Play ();
		BroadcastMessage ("OnDispatchHelicopter");
	}
}
