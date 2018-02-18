using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {

	private bool IsCalled = false;
	private Rigidbody MyRigidBody;

	// Use this for initialization
	void Start () {
		MyRigidBody = GetComponent<Rigidbody> ();
	}

	void OnDispatchHelicopter(){
		if (!IsCalled) {
			Debug.Log ("Helicopter called.");
			MyRigidBody.velocity = new Vector3 (0, 0, 50f);
			IsCalled = true;
		}
	}
}
