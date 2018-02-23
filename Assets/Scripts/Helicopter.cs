using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {

	private bool IsCalled = false;
	private Rigidbody MyRigidBody;
	private Transform LandingPosition;
	private float DistanceToFly;

	// Use this for initialization
	void Start () {
		MyRigidBody = GetComponent<Rigidbody> ();
	}

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
			transform.position = Vector3.MoveTowards (transform.position, LandingPosition.transform.position, 50f * Time.deltaTime);
			Debug.Log (DistanceToFly);
			transform.LookAt (LandingPosition.transform);
		}
		if (DistanceToFly <= 20 && IsCalled) {
			Debug.Log ("Helicopter arrived!");
		}
	}
}
