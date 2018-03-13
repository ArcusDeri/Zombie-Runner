using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScoreDisplay : MonoBehaviour {

	public Text View;

	// Use this for initialization
	void Start () {
		var winScore = PlayerPrefs.GetFloat ("LastScore");
		View.text = winScore.ToString() + " seconds.";
	}
}
