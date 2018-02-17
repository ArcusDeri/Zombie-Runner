using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Helicopter MyHelicopter;
	public Transform PlayerSpawnPoints;
	public bool RespawnRandomly = false;
	public AudioClip WhatHappened;

	private Transform[] SpawnPoints;
	private bool LastToggle = false;
	private AudioSource InnerVoice;

	// Use this for initialization
	void Start () {
		SpawnPoints = PlayerSpawnPoints.GetComponentsInChildren<Transform> ();
		var audioSources = GetComponents<AudioSource> ();
		foreach (var audioSource in audioSources) {
			if (audioSource.priority == 1)
				InnerVoice = audioSource;
		}
		InnerVoice.clip = WhatHappened;
		InnerVoice.Play ();
	}

	void Update(){
		if (LastToggle != RespawnRandomly) {
			Respawn ();
			RespawnRandomly = false;
		}
	}

	private void Respawn(){
		int i = Random.Range (1, SpawnPoints.Length);
		transform.position = SpawnPoints [i].transform.position;
	}

	void OnFindClearArea(){
		MyHelicopter.Call ();
		//TODO:Deploy a flare
		//TODO:Spawn zombies
	}
}
