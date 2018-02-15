using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour {

	public float MinutesPerSecond;

	private Quaternion StartRotation;

	// Use this for initialization
	void Start () {
		StartRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		float angleThisFrame = Time.deltaTime / 360 * MinutesPerSecond;
		transform.RotateAround (transform.position, Vector3.forward, angleThisFrame);
	}
}
