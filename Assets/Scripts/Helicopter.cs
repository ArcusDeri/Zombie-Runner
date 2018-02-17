using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {

	public AudioClip CallSound;

	private bool IsCalled = false;
	private AudioSource MyAudioSource;
	private Rigidbody MyRigidBody;

	// Use this for initialization
	void Start () {
		MyAudioSource = GetComponent<AudioSource> ();
		MyRigidBody = GetComponent<Rigidbody> ();
	}

	public void Call(){
		if (!IsCalled) {
			IsCalled = true;
			Debug.Log ("Helicopter called.");
			MyAudioSource.clip = CallSound;
			MyAudioSource.Play ();
			MyRigidBody.velocity = new Vector3 (0, 0, 50f);
		}
	}
}
