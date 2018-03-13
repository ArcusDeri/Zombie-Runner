using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Helicopter : MonoBehaviour {

	private bool IsCalled = false;
	private Transform LandingPosition;
	private float DistanceToFly;
	private float FlightSpeed = 120f;

	void OnDispatchHelicopter(){
		if (!IsCalled) {
			Debug.Log ("Helicopter called.");
			LandingPosition = GameObject.FindGameObjectWithTag("LandingArea").transform;
			IsCalled = true;
		}
	}

	void Update(){
		if (IsCalled) {
			DistanceToFly = Vector3.Distance (transform.position, LandingPosition.transform.position);
			Vector3 newPosition = new Vector3();
			if (DistanceToFly < 300)
				FlightSpeed = 15;
			if (DistanceToFly > 1) {
				newPosition = Vector3.MoveTowards (transform.position, LandingPosition.transform.position, FlightSpeed * Time.deltaTime);
				transform.LookAt (LandingPosition.transform);
				if (DistanceToFly > 150)
					newPosition.y = 120;
				else {
					var rotation = transform.eulerAngles;
					rotation.x = 0;
					transform.eulerAngles = rotation;
				}
				transform.position = newPosition;
			}
		}
		if (DistanceToFly <= 20 && IsCalled) {
			Debug.Log ("Helicopter arrived!");
		}
	}

	void OnTriggerEnter(Collider collider){
		if (collider.tag == "Player") {
			PlayerPrefs.SetFloat ("LastScore",Time.timeSinceLevelLoad);
			SceneManager.LoadScene ("Win", LoadSceneMode.Single);
		}
	}
}
