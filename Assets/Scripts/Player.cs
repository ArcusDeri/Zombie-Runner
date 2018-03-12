using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public Transform PlayerSpawnPoints;
	public bool RespawnRandomly = false;
	public GameObject LandingAreaPrefab;

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
		Invoke ("DropFlare", 3f);
	}

	void DropFlare(){
		Instantiate (LandingAreaPrefab, transform.position, transform.rotation);
	}

	void OnTriggerEnter(Collider collider){
		if (collider.tag == "Zombie") {
			SceneManager.LoadScene ("GameOver", LoadSceneMode.Single);
		}
	}
}
