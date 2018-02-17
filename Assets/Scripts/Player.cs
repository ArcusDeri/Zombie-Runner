using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Helicopter MyHelicopter;
	public Transform PlayerSpawnPoints;
	public bool RespawnRandomly = false;

	private Transform[] SpawnPoints;
	private bool LastToggle = false;

	// Use this for initialization
	void Start () {
		SpawnPoints = PlayerSpawnPoints.GetComponentsInChildren<Transform> ();	
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
