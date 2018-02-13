using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour {

	private Camera MyEyes;
	private float DefaultFOV;

	// Use this for initialization
	void Start () {
		MyEyes = GetComponent<Camera> ();
		DefaultFOV = MyEyes.fieldOfView;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Zoom")) {
			MyEyes.fieldOfView = DefaultFOV / 1.5f;
		} else {
			MyEyes.fieldOfView = DefaultFOV;
		}
	}
}
